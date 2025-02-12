namespace ADBMailer.WordConverter
{
    internal class WithMicrosoftWord : IWordConverter
    {
        private MicrosoftWordApp? _app = null;

        private MicrosoftWordApp App
        {
            get => this._app ??= new MicrosoftWordApp();
        }

        public byte[] ConvertToPDF(string docFile, IWordConverter.PDFQuality quality)
        {
            using var document = this.App.Open(docFile);
            var pdfFile = Program.Temp.GenerateNewFileName("pdf");
            document.ConvertToPDF(pdfFile, quality);
            try
            {
                return File.ReadAllBytes(pdfFile);
            }
            finally
            {
                try { File.Delete(pdfFile); } catch { }
            }
        }

        public void Dispose()
        {
            if (this._app != null)
            {
                try { this._app.Dispose(); } catch { }
                this._app = null;
            }
        }
    }
}