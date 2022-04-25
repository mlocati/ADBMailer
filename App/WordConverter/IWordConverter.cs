namespace ADBMailer.WordConverter
{
    internal interface IWordConverter : IDisposable
    {
        public byte[] ConvertToPDF(string docFile);
    }
}