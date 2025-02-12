using System.Diagnostics;

namespace ADBMailer.WordConverter
{
    internal class WithLibreOffice : IWordConverter
    {
        private readonly string SofficeComPath;

        public WithLibreOffice(string sofficeComPath)
        {
            if (sofficeComPath.Length == 0)
            {
                throw new Exception("Il percorso di LibreOffice non è configurato.");
            }
            if (!File.Exists(sofficeComPath))
            {
                throw new Exception($"Il percorso di LibreOffice configurato ({sofficeComPath}) non è valido.");
            }
            this.SofficeComPath = sofficeComPath;
        }

        public byte[] ConvertToPDF(string docFile, IWordConverter.PDFQuality quality)
        {
            string stdOut;
            string stdErr;
            var tempDir = Program.Temp.CreateNewEmptyDirectory();
            try
            {
                var psi = new ProcessStartInfo()
                {
                    FileName = this.SofficeComPath,
                    ArgumentList = {
                            "--headless",
                            "--norestore",
                            "--nolockcheck",
                            "--nologo",
                            "--convert-to",
                            "pdf",
                            docFile,
                            "--outdir",
                            tempDir.FullName,
                        },
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    ErrorDialog = false,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                };
                var process = Process.Start(psi) ?? throw new Exception("Impossibile avviare il processo di creazione del file PDF");
                try
                {
                    process.WaitForExit();
                    stdOut = process.StandardOutput.ReadToEnd().Trim();
                    stdErr = process.StandardError.ReadToEnd().Trim();
                    if (process.ExitCode != 0)
                    {
                        throw new Exception($"Errore durante la creazione del file PDF:{Environment.NewLine}{stdOut}{Environment.NewLine}{stdErr}");
                    }
                }
                finally
                {
                    try { process.Dispose(); } catch { }
                }
                var pdfFile = Path.Combine(tempDir.FullName, Path.ChangeExtension(Path.GetFileName(docFile), "pdf"));
                if (!File.Exists(pdfFile))
                {
                    throw new Exception($"Errore durante la creazione del file PDF:{Environment.NewLine}{stdOut}{Environment.NewLine}{stdErr}");
                }
                return File.ReadAllBytes(pdfFile);
            }
            finally
            {
                try { tempDir.Delete(true); } catch { }
            }
        }

        public void Dispose()
        {
        }
    }
}