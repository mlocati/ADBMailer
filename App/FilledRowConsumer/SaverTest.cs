using System.Diagnostics;

namespace ADBMailer.FilledRowConsumer
{
    internal class SaverTest : IFilledRowConsumer
    {
        private class FileToBeDeleted : IDisposable
        {
            private string FileName;

            public FileToBeDeleted(string filename)
            {
                this.FileName = filename;
            }

            public void Dispose()
            {
                if (this.FileName.Length > 0)
                {
                    try { File.Delete(this.FileName); } catch { }
                    this.FileName = "";
                }
            }
        }

        private readonly int _forceDataRow;
        public int? ForceDataRow => this._forceDataRow;

        public bool UseRecipients => false;

        public bool GeneratesPermamentFiles => false;

        public bool UsePDFFilename => true;

        public string ProcessingWindowTitle => "Generazione PDF di test";

        public SaverTest(int testExcelDataRow)
        {
            this._forceDataRow = testExcelDataRow;
        }

        public IFilledRowConsumer.Result Process(FieldFiller.Result filled, byte[] pdfBytes, IFilledRowConsumer.StatusAdvancer statusAdvancer)
        {
            var tempPdf = Program.Temp.GenerateNewFileName("pdf");
            File.WriteAllBytes(tempPdf, pdfBytes);
            statusAdvancer("Apertura PDF di test...");
            using (var process = new Process())
            {
                process.StartInfo = new ProcessStartInfo()
                {
                    FileName = tempPdf,
                    UseShellExecute = true,
                    Verb = "open",
                    WindowStyle = ProcessWindowStyle.Maximized,
                };
                process.Start();
            }
            statusAdvancer("Fatto.");
            return new IFilledRowConsumer.Result(new FileToBeDeleted(tempPdf));
        }
    }
}