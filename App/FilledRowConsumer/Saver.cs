using System.Text;
using System.Text.RegularExpressions;

namespace ADBMailer.FilledRowConsumer
{
    internal class Saver : IFilledRowConsumer
    {
        public int? ForceDataRow => null;

        public bool UseRecipients => false;

        public bool GeneratesPermamentFiles => true;

        public bool UseMemberName => true;

        public string ProcessingWindowTitle => "Generazione PDF";

        private readonly DirectoryInfo DestinationDirectory;

        public Saver(DirectoryInfo destinationDirectory)
        {
            this.DestinationDirectory = destinationDirectory;
        }

        public IFilledRowConsumer.Result Process(FieldFiller.Result filled, byte[] pdfBytes, IFilledRowConsumer.StatusAdvancer statusAdvancer)
        {
            var memberName = FixMemberName(filled.MemberName);
            if (memberName.Length == 0)
            {
                memberName = $"SenzaNome{filled.ExcelRow}";
            }
            string pdfFilename;
            string fullPdfFilename;
            for (var i = 0; ; i++)
            {
                pdfFilename = memberName + (i == 0 ? "" : $"-{i}") + ".pdf";
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

        private static Regex? _fixMemberNameRegex = null;

        private static Regex FixMemberNameRegex
        {
            get
            {
                if (_fixMemberNameRegex != null)
                {
                    return _fixMemberNameRegex;
                }
                var pattern = new StringBuilder("[");
                pattern.Append(Regex.Escape("-"));
                foreach (var c in Path.GetInvalidFileNameChars())
                {
                    pattern.Append(Regex.Escape(c.ToString()));
                }
                pattern.Append("]+");
                return _fixMemberNameRegex = new Regex(pattern.ToString(), RegexOptions.CultureInvariant | RegexOptions.Compiled);
            }
        }

        private static string FixMemberName(string? raw)
        {
            if (string.IsNullOrEmpty(raw))
            {
                return "";
            }
            return FixMemberNameRegex.Replace(raw, "-").Trim('-');
        }
    }
}