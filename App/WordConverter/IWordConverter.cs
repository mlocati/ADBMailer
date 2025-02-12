namespace ADBMailer.WordConverter
{
    internal interface IWordConverter : IDisposable
    {
        public enum PDFQuality : int
        {
            PreferSizeOverQuality = 1,
            PreferQualityOverSize = 2,
        }

        public byte[] ConvertToPDF(string docFile, PDFQuality quality);
    }
}