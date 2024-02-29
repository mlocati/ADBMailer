using DocumentFormat.OpenXml.Packaging;
using MimeKit;
using OfficeOpenXml;

namespace ADBMailer
{
    public class FieldFiller : IDisposable
    {
        public sealed class Result : IDisposable
        {
            private bool _disposed = false;
            public readonly int ExcelRow;
            public readonly MailboxAddress[]? Recipients;
            public readonly string? PDFFileName;
            public readonly string FilledWordDocument;

            public Result(int excelRow, MailboxAddress[]? recipients, string? pdfFilename, string filledWordDocument)
            {
                this.ExcelRow = excelRow;
                this.Recipients = recipients;
                this.PDFFileName = pdfFilename;
                this.FilledWordDocument = filledWordDocument;
            }

            public void Dispose()
            {
                if (!this._disposed)
                {
                    try { File.Delete(this.FilledWordDocument); } catch { }
                    this._disposed = true;
                }
            }
        }

        public delegate void WarningsListener(string warning, int excelRow, int? excelColumn);

        private readonly string ExcelFile = "";
        private readonly string WordFile = "";
        private readonly Mapping Mapping;
        private ExcelPackage ExcelPackage;
        private ExcelWorksheet ExcelSheet;
        private ExcelSheetRange _excelRange;

        public ExcelSheetRange ExcelRange
        {
            get => this._excelRange;
        }

        private WordprocessingDocument WordDocument;
        private MainDocumentPart WordDocumentPart;

        public FieldFiller(string sourceExcelFile, string sourceWordFile, bool requireRecipients, Mapping? configuredMapping)
        {
            try
            {
                this.ExcelFile = Program.Temp.GenerateNewFileName("xlsx");
                File.Copy(sourceExcelFile, this.ExcelFile, false);
                this.WordFile = Program.Temp.GenerateNewFileName("docx");
                File.Copy(sourceWordFile, this.WordFile, false);
                this.OpenExcelFile();
                if (this.ExcelPackage == null || this.ExcelSheet == null || this._excelRange == null) throw new InvalidOperationException();
                this.OpenWordFile();
                if (this.WordDocument == null || this.WordDocumentPart == null) throw new InvalidOperationException();
                var excelHeaders = new ExcelMapper().GetColumnHeaders(sourceExcelFile, this.ExcelSheet);
                var wordFields = new WordMapper(Options.GeneratePdfLocale).GetFields(sourceWordFile, this.WordDocumentPart);
                this.Mapping = new Mapping(excelHeaders, wordFields, configuredMapping);
                if (configuredMapping == null)
                {
                    this.Mapping.AutoAssociate();
                }
                this.CheckMapping(requireRecipients);
            }
            catch
            {
                this.Dispose();
                throw;
            }
        }

        public void Dispose()
        {
            if (this.ExcelSheet != null)
            {
                try { this.ExcelSheet.Dispose(); } catch { }
            }
            if (this.ExcelPackage != null)
            {
                try { this.ExcelPackage.Dispose(); } catch { }
            }
            if (!string.IsNullOrEmpty(this.ExcelFile))
            {
                try { File.Delete(this.ExcelFile); } catch { }
            }
            if (this.WordDocument != null)
            {
                try { this.WordDocument.Close(); } catch { }
                try { this.WordDocument.Dispose(); } catch { }
            }
            if (!string.IsNullOrEmpty(this.WordFile))
            {
                try { File.Delete(this.WordFile); } catch { }
            }
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Result> Fill(FilledRowConsumer.IFilledRowConsumer forConsumer)
        {
            return this.Fill(forConsumer, null);
        }

        public IEnumerable<Result> Fill(FilledRowConsumer.IFilledRowConsumer forConsumer, WarningsListener? warningsListener)
        {
            for (var excelRow = this.ExcelRange.FirstDataRow; excelRow <= this.ExcelRange.LastDataRow; excelRow++)
            {
                var result = this.Fill(excelRow, forConsumer, warningsListener);
                if (result != null)
                {
                    yield return result;
                }
            }
        }

        public Result? Fill(int excelRow, FilledRowConsumer.IFilledRowConsumer forConsumer, WarningsListener? warningsListener)
        {
            if (this.IsRowEmpty(excelRow))
            {
                warningsListener?.Invoke("Riga vuota.", excelRow, null);
                return null;
            }
            MailboxAddress[]? recipients;
            if (forConsumer.UseRecipients)
            {
                recipients = this.ExtractRecipients(excelRow, warningsListener);
                if (recipients == null)
                {
                    return null;
                }
            }
            else
            {
                recipients = null;
            }
            string? pdfFilename;
            if (forConsumer.UsePDFFilename)
            {
                pdfFilename = this.ExtractPDFFilename(excelRow, warningsListener);
                if (pdfFilename == null)
                {
                    return null;
                }
            }
            else
            {
                pdfFilename = null;
            }
            var filledWordDocument = this.FillPlaceholders(excelRow, warningsListener);
            if (filledWordDocument.Length == 0)
            {
                return null;
            }
            return new Result(excelRow, recipients, pdfFilename, filledWordDocument);
        }

        private bool IsRowEmpty(int excelRow)
        {
            for (var excelColumn = this.ExcelRange.FirstColumn; excelColumn <= this.ExcelRange.LastColumn; excelColumn++)
            {
                if (!ExcelSheetRange.IsCellEmpty(this.ExcelSheet, excelRow, excelColumn))
                {
                    return false;
                }
            }
            return true;
        }

        private MailboxAddress[]? ExtractRecipients(int excelRow, WarningsListener? warningsListener)
        {
            var result = new List<MailboxAddress>(this.Mapping.RecipientFields.Length);
            foreach (var field in this.Mapping.RecipientFields)
            {
                string? rawAddress = null;
                try
                {
                    var cell = this.ExcelSheet.Cells[excelRow, field.Column];
                    if (cell != null)
                    {
                        rawAddress = cell.GetValue<string>();
                        if (rawAddress != null)
                        {
                            rawAddress = rawAddress.Trim();
                        }
                    }
                }
                catch
                {
                }
                if (string.IsNullOrEmpty(rawAddress))
                {
                    continue;
                }
                var address = MailService.GetAddressFromString(rawAddress, out string reason);
                if (address == null)
                {
                    warningsListener?.Invoke($"L'indirizzo email {rawAddress} non è valido:{Environment.NewLine}{reason}", excelRow, field.Column);
                    continue;
                }
                result.Add(address);
            }
            if (result.Count == 0)
            {
                warningsListener?.Invoke("Nessun indirizzo email trovato.", excelRow, null);
                return null;
            }
            return result.ToArray();
        }

        private string? ExtractPDFFilename(int excelRow, WarningsListener? _)
        {
            string? rawPDFFilename = null;
            if (this.Mapping.PDFFilenameField != null)
            {
                try
                {
                    var cell = this.ExcelSheet.Cells[excelRow, this.Mapping.PDFFilenameField.Column];
                    if (cell != null)
                    {
                        rawPDFFilename = cell.GetValue<string>();
                        if (rawPDFFilename != null)
                        {
                            rawPDFFilename = rawPDFFilename.Trim();
                        }
                    }
                }
                catch { }
            }
            return string.IsNullOrEmpty(rawPDFFilename) ? "" : rawPDFFilename;
        }

        private string FillPlaceholders(int excelRow, WarningsListener? warningsListener)
        {
            var newDocFilename = Program.Temp.GenerateNewFileName(".docx");
            var ok = false;
            using (var newDoc = (WordprocessingDocument)this.WordDocument.Clone(newDocFilename, true, new OpenSettings() { AutoSave = false }))
            {
                try
                {
                    var mainDocumentPart = newDoc.MainDocumentPart;
                    if (mainDocumentPart == null)
                    {
                        warningsListener?.Invoke("Errore durante la creazione del nuovo documento di Word", excelRow, null);
                    }
                    else
                    {
                        foreach (var field in this.Mapping.WordFields)
                        {
                            this.FillPlaceholders(excelRow, field, mainDocumentPart, warningsListener);
                        }
                        newDoc.Save();
                        ok = true;
                    }
                }
                finally
                {
                    try { newDoc.Close(); } catch { }
                }
            }
            if (!ok)
            {
                try { File.Delete(newDocFilename); } catch { }
                return "";
            }
            return newDocFilename;
        }

        private void FillPlaceholders(int excelRow, WordMapper.Field wordField, MainDocumentPart mainDocumentPart, WarningsListener? warningsListener)
        {
            var excelField = this.Mapping.SelectedWordFields[wordField.Name];
            if (excelField == null) throw new InvalidOperationException();
            foreach (var kv in wordField.Placeholders)
            {
                this.FillPlaceholder(excelRow, excelField.Column, kv.Key, kv.Value, mainDocumentPart, warningsListener);
            }
        }

        private void FillPlaceholder(int excelRow, int excelColumn, string placeholder, ValueFormatter.IValueFormatter formatter, MainDocumentPart mainDocumentPart, WarningsListener? _)
        {
            string value = "";
            try
            {
                var cell = this.ExcelSheet.Cells[excelRow, excelColumn];
                if (cell != null)
                {
                    value = formatter.Format(cell);
                }
            }
            catch
            {
            }
            WordMapper.ReplacePlaceholder(mainDocumentPart, placeholder, value);
        }

        private void OpenExcelFile()
        {
            var fileInfo = new FileInfo(this.ExcelFile);
            if (!fileInfo.Exists)
            {
                throw new Exception($"Impossibile trovare il documento di Excel {this.ExcelFile}");
            }
            this.ExcelPackage = new ExcelPackage(fileInfo);
            if (this.ExcelPackage.Workbook.Worksheets.Count < 1)
            {
                throw new Exception($"Il documento di Excel {this.ExcelFile} non contiene alcun foglio");
            }
            this.ExcelSheet = this.ExcelPackage.Workbook.Worksheets[0];
            if (this.ExcelSheet.Dimension == null)
            {
                throw new Exception($"Il foglio nel documento di Excel {this.ExcelFile} è vuoto");
            }
            this._excelRange = new ExcelSheetRange(this.ExcelSheet);
        }

        private void OpenWordFile()
        {
            var fileInfo = new FileInfo(this.WordFile);
            if (!fileInfo.Exists)
            {
                throw new Exception($"Impossibile trovare il documento di Word {this.WordFile}");
            }
            this.WordDocument = WordprocessingDocument.Open(this.WordFile, false, new OpenSettings() { AutoSave = false });
            var wordDomentPart = this.WordDocument.MainDocumentPart;
            if (wordDomentPart == null)
            {
                throw new Exception($"Il documento di Word {this.WordFile} non contiene la parte principale del documento");
            }
            this.WordDocumentPart = wordDomentPart;
        }

        private void CheckMapping(bool requireRecipients)
        {
            if (requireRecipients)
            {
                if (this.Mapping.RecipientFields.Length == 0)
                {
                    throw new Exception($"Non è stato possibile rilevare automaticamente le colonne di Excel contenenti gli indirizzi email dei destinatari.{Environment.NewLine}È necessario mappare i campi manualmente.");
                }
            }
            foreach (var kv in this.Mapping.SelectedWordFields)
            {
                if (kv.Value == null)
                {
                    throw new Exception($"Non è stato possibile rilevare automaticamente la colonna di Excel corrispondente al campo di Word {kv.Key}.{Environment.NewLine}È necessario mappare i campi manualmente.");
                }
            }
        }
    }
}