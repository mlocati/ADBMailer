using System.Diagnostics;
using System.Web;
using unoidl.com.sun.star.bridge;
using unoidl.com.sun.star.frame;
using unoidl.com.sun.star.lang;
using unoidl.com.sun.star.uno;
using uno;
using uno.util;
using unoidl.com.sun.star.beans;
using Exception = System.Exception;

/// <see cref="https://wiki.openoffice.org/wiki/Documentation/DevGuide/ProUNO/CLI/Writing_Client_Programs"/>
namespace ADBMailer.WordConverter
{
    internal class WithLibreOffice : IWordConverter
    {
        private readonly Process LibreOfficeProcess;
        private readonly XComponentLoader ComponentLoader;

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
            GetFileURLFromSystemPath(sofficeComPath);
            var pipeName = "ADBMailer" + Guid.NewGuid().ToString().Replace("-", "").Replace("{", "").Replace("}", "");
            ConfigureEnvironment(sofficeComPath);
            var process = StartLibreOffice(sofficeComPath, pipeName);
            XComponentLoader componentLoader;
            try
            {
                componentLoader = OpenPipe(sofficeComPath, pipeName);
            }
            catch
            {
                try { process.Kill(); } catch { }
                try { process.Dispose(); } catch { }
                throw;
            }
            this.LibreOfficeProcess = process;
            this.ComponentLoader = componentLoader;
        }

        public byte[] ConvertToPDF(string docFile)
        {
            var openProps = new PropertyValue[]
            {
                new PropertyValue() { Name = "Hidden", Value = new Any(true)},
                new PropertyValue() { Name = "ReadOnly", Value = new Any(true)},
            };
            var component = this.ComponentLoader.loadComponentFromURL(
                GetFileURLFromSystemPath(docFile),
                "_blank",
                0,
                openProps
            );
            var filterData = new PropertyValue[]
            {
                new PropertyValue() { Name = "UseLosslessCompression", Value = new Any(false)},
                new PropertyValue() { Name = "Quality", Value = new Any(90)},
                new PropertyValue() { Name = "ReduceImageResolution", Value = new Any(true)},
                new PropertyValue() { Name = "MaxImageResolution", Value = new Any(300)},
                new PropertyValue() { Name = "ExportBookmarks", Value = new Any(false)},
            };
            var propertyValues = new PropertyValue[]
            {
                new PropertyValue() { Name = "FilterName", Value = new Any("writer_pdf_Export")},
                new PropertyValue { Name = "Overwrite", Value = new Any(true) },
                new PropertyValue() { Name = "FilterData", Value = new Any(PolymorphicType.GetType(typeof(PropertyValue[]), "unoidl.com.sun.star.beans.PropertyValue[]"), filterData) }
            };
            var pdfFile = Program.Temp.GenerateNewFileName("pdf");
            ((XStorable)component).storeToURL(GetFileURLFromSystemPath(pdfFile), propertyValues);
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
            try { this.LibreOfficeProcess.Kill(); } catch { }
            try { this.LibreOfficeProcess.Dispose(); } catch { }
        }

        private static void ConfigureEnvironment(string sofficeComPath)
        {
            var dir = new FileInfo(sofficeComPath).Directory?.FullName.TrimEnd(Path.DirectorySeparatorChar);
            if (dir == null)
            {
                throw new InvalidOperationException();
            }
            Environment.SetEnvironmentVariable("UNO_PATH", dir, EnvironmentVariableTarget.Process);
            Environment.SetEnvironmentVariable("URE_BOOTSTRAP", "vnd.sun.star.pathname:" + Path.Combine(dir, "fundamental.ini"), EnvironmentVariableTarget.Process);
            var path = (Environment.GetEnvironmentVariable("PATH") ?? "").Trim(Path.PathSeparator);
            var quotedPath = $"{Path.PathSeparator}{path}{Path.PathSeparator}";
            if (!quotedPath.Contains($"{Path.PathSeparator}{dir}{Path.PathSeparator}", StringComparison.OrdinalIgnoreCase) && !quotedPath.Contains($"{Path.PathSeparator}{dir}{Path.DirectorySeparatorChar}{Path.PathSeparator}", StringComparison.OrdinalIgnoreCase))
            {
                Environment.SetEnvironmentVariable("PATH", $"{dir}{Path.PathSeparator}{path}".TrimEnd(Path.PathSeparator), EnvironmentVariableTarget.Process);
            }
        }

        private static Process StartLibreOffice(string sofficeComPath, string pipeName)
        {
            var psi = new ProcessStartInfo()
            {
                FileName = sofficeComPath,
                ArgumentList =
                {
                    "--nologo",
                    //"--nodefault",
                    "--headless",
                    "--invisible",
                    "--nocrashreport",
                    "--norestore",
                    "-nolockcheck",
                    $"--accept=pipe,name={pipeName};urp;StarOffice.ComponentContex",
                },
                CreateNoWindow = true,
                ErrorDialog = false,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden,
            };
            var process = Process.Start(psi);
            if (process == null)
            {
                throw new Exception("Impossibile avviare il processo di creazione del file PDF");
            }
            return process;
        }

        private static XComponentLoader OpenPipe(string sofficeComPath, string pipeName)
        {
            var dir = new FileInfo(sofficeComPath).Directory;
            if (dir == null)
            {
                throw new InvalidOperationException();
            }
            var localContext = Bootstrap.defaultBootstrap_InitialComponentContext();
            var serviceManager = localContext.getServiceManager();
            var urlResolver = (XUnoUrlResolver)serviceManager.createInstanceWithContext("com.sun.star.bridge.UnoUrlResolver", localContext);
            var maxRetries = 20;
            for (int retry = 0; ; retry++)
            {
                try
                {
                    if (urlResolver.resolve($"uno:pipe,name={pipeName};urp;StarOffice.ComponentContext") is XComponentContext remoteContext)
                    {
                        if (remoteContext.getServiceManager() is XMultiServiceFactory remoteFactory)
                        {
                            if (remoteFactory.createInstance("com.sun.star.frame.Desktop") is XComponentLoader componentLoader)
                            {
                                return componentLoader;
                            }
                        }
                    }
                }
                catch (Exception x)
                {
                    if (retry == maxRetries || !x.Message.Contains("couldn't connect to pipe"))
                    {
                        throw;
                    }
                }
                Thread.Sleep(100);
            }
        }

        private static string GetFileURLFromSystemPath(string path)
        {
            return GetFileURLFromSystemPath("file:///", path);
        }

        private static string GetFileURLFromSystemPath(string prefix, string path)
        {
            return HttpUtility.UrlPathEncode(prefix + path.Replace(Path.DirectorySeparatorChar, '/'));
        }
    }
}