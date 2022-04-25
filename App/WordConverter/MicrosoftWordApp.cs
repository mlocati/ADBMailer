using System.Reflection;

namespace ADBMailer.WordConverter
{
    internal class MicrosoftWordApp : IDisposable
    {
        // https://docs.microsoft.com/en-us/office/vba/api/word.wdsaveoptions
        private enum WdSaveOptions : int
        {
            wdDoNotSaveChanges = 0,
            wdPromptToSaveChanges = -2,
            wdSaveChanges = -1,
        }

        // https://docs.microsoft.com/en-us/office/vba/api/word.wdexportformat
        private enum WdExportFormat : int
        {
            wdExportFormatPDF = 17,
            wdExportFormatXPS = 18,
        }

        // https://docs.microsoft.com/en-us/office/vba/api/word.wdexportoptimizefor
        private enum WdExportOptimizeFor : int
        {
            wdExportOptimizeForOnScreen = 1,
            wdExportOptimizeForPrint = 0,
        }

        private readonly Type WordType;
        private readonly object Word;
        private readonly object WordDocuments;
        private readonly Type WordDocumentsType;
        private bool _disposed = false;

        public class Document : IDisposable
        {
            private readonly object Doc;
            private readonly Type DocType;
            private bool _disposed = false;

            public Document(object doc)
                : this(doc, doc.GetType())
            {
            }

            public Document(object doc, Type docType)
            {
                this.Doc = doc;
                this.DocType = docType;
            }

            public void ConvertToPDF(string pdfFile)
            {
                try
                {
                    // https://docs.microsoft.com/en-us/office/vba/api/word.document.exportasfixedformat
                    this.DocType.InvokeMember("ExportAsFixedFormat", BindingFlags.InvokeMethod | BindingFlags.Instance, null, this.Doc, new object[] {
                        // OutputFileName
                        pdfFile,
                        // ExportFormat
                        WdExportFormat.wdExportFormatPDF,
                        // OpenAfterExport
                        false,
                        // OptimizeFor
                        WdExportOptimizeFor.wdExportOptimizeForOnScreen,
                    });
                }
                catch (Exception x)
                {
                    throw new Exception($"Errore durante la conversione in PDF:{Environment.NewLine}{GetInnerException(x).Message}");
                }
            }

            public void Dispose()
            {
                if (!this._disposed)
                {
                    // https://docs.microsoft.com/en-us/office/vba/api/word.document.close(method)
                    try
                    {
                        this.DocType.InvokeMember("Close", BindingFlags.InvokeMethod | BindingFlags.Instance, null, this.Doc, new object[] {
                            // SaveChanges
                            WdSaveOptions.wdDoNotSaveChanges,
                        });
                    }
                    catch { }
                    this._disposed = true;
                }
                GC.SuppressFinalize(this);
            }
        }

        public MicrosoftWordApp()
        {
            var wordType = GetWordType();
            if (wordType == null)
            {
                throw new Exception("Microsoft Word non è installato.");
            }
            var word = Activator.CreateInstance(wordType);
            if (word == null)
            {
                throw new Exception("Impossibile avviare Microsoft Word");
            }
            try
            {
                // https://docs.microsoft.com/en-us/office/vba/api/word.application.visible
                wordType.InvokeMember("Visible", BindingFlags.SetProperty | BindingFlags.Instance, null, word, new object[] { false });
                // https://docs.microsoft.com/en-us/office/vba/api/word.application.documents
                var wordDocuments = wordType.InvokeMember("Documents", BindingFlags.GetProperty | BindingFlags.Instance, null, word, null);
                if (wordDocuments == null) throw new Exception("Impossibile ottenere l'oggetto Documents di Microsoft Word");
                var wordDocumentsType = wordDocuments.GetType();
                this.WordType = wordType;
                this.Word = word;
                this.WordDocuments = wordDocuments;
                this.WordDocumentsType = wordDocumentsType;
            }
            catch (Exception x)
            {
                try { QuitApp(wordType, word); } catch { }
                throw new Exception($"Errore l'avvio di Microsoft Word:{Environment.NewLine}{GetInnerException(x).Message}");
            }
        }

        public Document Open(string docFile)
        {
            try
            {
                // https://docs.microsoft.com/en-us/office/vba/api/word.documents.open
                var document = this.WordDocumentsType.InvokeMember("Open", BindingFlags.InvokeMethod | BindingFlags.Instance, null, this.WordDocuments, new object[] {
                    // FileName
                    docFile,
                    // ConfirmConversions
                    false,
                    // ReadOnly
                    true,
                    // AddToRecentFiles
                    false,
                });
                if (document == null)
                {
                    throw new Exception("Errore non specificato");
                }
                return new Document(document);
            }
            catch (Exception x)
            {
                throw new Exception($"Errore durante l'apertura del documento di Word:{Environment.NewLine}{GetInnerException(x).Message}");
            }
        }

        private static Type? GetWordType()
        {
            try
            {
                return Type.GetTypeFromProgID("Word.Application");
            }
            catch
            {
                return null;
            }
        }

        public static bool CheckAvailability()
        {
            return GetWordType() != null;
        }

        public void Dispose()
        {
            if (!this._disposed)
            {
                try { QuitApp(this.WordType, this.Word); } catch { }
                this._disposed = true;
            }
        }

        private static void QuitApp(Type type, object instance)
        {
            try
            {
                // https://docs.microsoft.com/en-us/office/vba/api/word.application.quit(method)
                type.InvokeMember("Quit", BindingFlags.InvokeMethod | BindingFlags.Instance, null, instance, new object[] {
                    // SaveChanges
                    WdSaveOptions.wdDoNotSaveChanges,
                });
            }
            catch (Exception x)
            {
                throw new Exception($"Errore durante la chiusura di Microsoft Word:{Environment.NewLine}{GetInnerException(x).Message}");
            }
        }

        private static Exception GetInnerException(Exception x)
        {
            while (x.InnerException != null)
            {
                x = x.InnerException;
            }
            return x;
        }
    }
}