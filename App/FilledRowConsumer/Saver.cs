using System.Text;
using System.Text.RegularExpressions;

namespace ADBMailer.FilledRowConsumer
{
    internal class Saver : IFilledRowConsumer
    {
        public int? ForceDataRow => null;

        public bool UseRecipients => false;

        public bool GeneratesPermamentFiles => true;

        public bool UsePDFFilename => true;

        public string ProcessingWindowTitle => "Generazione PDF";

        private readonly DirectoryInfo DestinationDirectory;

        public Saver(DirectoryInfo destinationDirectory)
        {
            this.DestinationDirectory = destinationDirectory;
        }

        public IFilledRowConsumer.Result Process(FieldFiller.Result filled, byte[] pdfBytes, IFilledRowConsumer.StatusAdvancer statusAdvancer)
        {
            var pdfFilenameBase = FixPDFFilename(filled.PDFFileName);
            if (pdfFilenameBase.Length == 0)
            {
                pdfFilenameBase = $"SenzaNome{filled.ExcelRow}";
            }
            string pdfFilename;
            string fullPdfFilename;
            for (var i = 0; ; i++)
            {
                pdfFilename = pdfFilenameBase + (i == 0 ? "" : $"-{i}") + ".pdf";
                fullPdfFilename = Path.Combine(this.DestinationDirectory.FullName, pdfFilename);
                if (!File.Exists(fullPdfFilename) && !Directory.Exists(fullPdfFilename))
                {
                    break;
                }
            }
            File.WriteAllBytes(fullPdfFilename, pdfBytes);
            statusAdvancer($"PDF salvato con nome {pdfFilename}");
            return new IFilledRowConsumer.Result(new FileInfo(fullPdfFilename));
        }

        private static Regex? _fixPDFFilenameRegex = null;

        private static Regex FixPDFFilenameRegex
        {
            get
            {
                if (_fixPDFFilenameRegex != null)
                {
                    return _fixPDFFilenameRegex;
                }
                var pattern = new StringBuilder("[");
                pattern.Append(Regex.Escape("-"));
                foreach (var c in Path.GetInvalidFileNameChars())
                {
                    pattern.Append(Regex.Escape(c.ToString()));
                }
                pattern.Append("]+");
                return _fixPDFFilenameRegex = new Regex(pattern.ToString(), RegexOptions.CultureInvariant | RegexOptions.Compiled);
            }
        }

        private static string FixPDFFilename(string? raw)
        {
            if (string.IsNullOrEmpty(raw))
            {
                return "";
            }
            return FixPDFFilenameRegex.Replace(raw, "-").Trim('-');
        }
    }
}