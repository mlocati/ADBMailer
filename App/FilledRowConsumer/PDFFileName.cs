using System.Text;
using System.Text.RegularExpressions;

namespace ADBMailer.FilledRowConsumer
{
    internal static class PDFFileName
    {
        private static Regex? _fixPDFFilenameRegex = null;

        private static Regex FixPDFFilenameRegex
        {
            get
            {
                if (_fixPDFFilenameRegex != null)
                {
                    return _fixPDFFilenameRegex;
                }
                var pattern = new StringBuilder('[');
                pattern.Append(Regex.Escape("-"));
                foreach (var c in Path.GetInvalidFileNameChars())
                {
                    pattern.Append(Regex.Escape(c.ToString()));
                }
                pattern.Append("]+");
                return _fixPDFFilenameRegex = new Regex(pattern.ToString(), RegexOptions.CultureInvariant | RegexOptions.Compiled);
            }
        }

        private static string BuildPDFFileName(string? raw)
        {
            if (string.IsNullOrEmpty(raw))
            {
                return "";
            }
            return FixPDFFilenameRegex.Replace(raw, "-").Trim('-');
        }

        public static string BuildPDFFileName(FieldFiller.Result filled, bool progressive, bool withExtension)
        {
            var result = BuildPDFFileName(filled.PDFFileName);
            if (result.Length == 0)
            {
                result = progressive ? $"SenzaNome{filled.ExcelRow}" : "Documento";
            }
            return withExtension ? $"{result}.pdf" : result;
        }
    }
}