namespace ADBMailer.FilledRowConsumer
{
    public interface IFilledRowConsumer
    {
        public class Result
        {
            public readonly FileInfo? GeneratedFile;
            public readonly IDisposable? Disposable;

            public Result() :
                this(null, null)
            { }

            public Result(FileInfo generatedFile) :
                this(generatedFile, null)
            { }

            public Result(IDisposable disposable) :
                this(null, disposable)
            { }

            public Result(FileInfo? generatedFile, IDisposable? disposable)
            {
                this.GeneratedFile = generatedFile;
                this.Disposable = disposable;
            }
        }

        public delegate void StatusAdvancer(string status);

        public string ProcessingWindowTitle { get; }

        public int? ForceDataRow { get; }

        public bool UseRecipients { get; }

        public bool GeneratesPermamentFiles { get; }

        public bool UsePDFFilename { get; }

        public Result Process(FieldFiller.Result filled, byte[] pdfBytes, StatusAdvancer statusAdvancer);
    }
}