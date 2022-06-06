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
            var pdfFilenameBase = PDFFileName.BuildPDFFileName(filled, true, false);
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
    }
}