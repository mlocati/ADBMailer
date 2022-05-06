using System.ComponentModel;
using System.Diagnostics;
using System.IO.Compression;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ADBMailer
{
    internal sealed class Updater
    {
        public class TokenRequiredException : Exception
        { }

        public class TokenInvalidException : Exception
        { }

        public class UpdaterScript : IDisposable
        {
            private bool Disposed = false;
            private bool Executed = false;
            private readonly FileInfo BatchFile;
            private readonly FileInfo MsiFile;

            public UpdaterScript(FileInfo batchFile, FileInfo msiFile)
            {
                this.BatchFile = batchFile;
                this.MsiFile = msiFile;
            }

            public bool Execute()
            {
                if (this.Disposed)
                {
                    throw new ObjectDisposedException(nameof(UpdaterScript));
                }
                var psi = new ProcessStartInfo()
                {
                    FileName = this.BatchFile.FullName,
                    UseShellExecute = true,
                    Verb = "runas",
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                };
                try
                {
                    var proc = Process.Start(psi);
                    if (proc == null)
                    {
                        throw new Exception("Errore durante l'avvio dell'aggiornamento");
                    }
                }
                catch (Win32Exception x)
                {
                    if (x.NativeErrorCode != 1223 /* ERROR_CANCELLED */ )
                    {
                        return false;
                    }
                    throw;
                }

                this.Executed = true;
                return true;
            }

            public void Dispose()
            {
                if (this.Disposed)
                {
                    return;
                }
                GC.SuppressFinalize(this);
                if (this.Executed == false)
                {
                    try { this.BatchFile.Delete(); } catch { }
                    try { this.MsiFile.Delete(); } catch { }
                }
                this.Disposed = true;
            }
        }

        public delegate FileInfo Downloader(Uri url);

        private const string GITHUB_OWNER = "mlocati";

        private const string GITHUB_PROJECT = "ADBMailer";

        private const string GITHUB_RELEASE_FILE_ZIP = "ADBMailer.zip";

        private const string GITHUB_RELEASE_FILE_MSI = "ADBMailer.msi";
        private const string PRODUCT_CODE = "{D6696FAA-A2FA-4686-902F-A3DAE9DBA877}";

        private const string BATCONTENT_TEMPLATE = @"@ECHO OFF
TIMEOUT /T 3 /NOBREAK >NUL
START """" /WAIT ""<MSIEXEC>"" /uninstall <PRODUCT_CODE> /qb
IF errorlevel 1 GOTO :autodestruct
START """" /WAIT ""<MSIEXEC>"" /i ""<NEWMSIFILE>"" /passive TARGETDIR=""<INSTALLDIR>""
IF errorlevel 1 GOTO :autodestruct
START """" ""<INSTALLDIR>\ADBMailer.exe""

:autodestruct
DEL /Q ""<NEWMSIFILE>""
START /B """" ""%ComSpec%"" /C DEL /Q ""%~f0""
";

        public class ReleaseVersion
        {
            public readonly Version Version;
            public readonly Uri DownloadURL;
            private readonly Downloader Downloader;

            public ReleaseVersion(Version version, Uri downloadURL, Downloader downloader)
            {
                this.Version = version;
                this.DownloadURL = downloadURL;
                this.Downloader = downloader;
            }

            public FileInfo Download()
            {
                return this.Downloader(this.DownloadURL);
            }
        }

        private class JsonVersion
        {
            public class Asset
            {
                [JsonPropertyName("url")]
                public Uri? DownloadUrl { get; set; }

                [JsonPropertyName("name")]
                public string? Name { get; set; }

                [JsonPropertyName("size")]
                public uint? Size { get; set; }

                [JsonPropertyName("created_at")]
                public DateTime? CreaedAt { get; set; }
            }

            [JsonPropertyName("tag_name")]
            public string? TagName { get; set; }

            [JsonPropertyName("assets")]
            public Asset[]? Assets { get; set; }
        }

        private readonly string GithubToken;

        public Updater()
            : this("")
        { }

        public Updater(string githubToken)
        {
            this.GithubToken = githubToken;
        }

        public ReleaseVersion GetLatestVersion()
        {
            return this.GithubToken.Length == 0 ? this.GetLatestVersionUnauthenticated() : this.GetLatestVersionAuthenticated();
        }

        private ReleaseVersion GetLatestVersionUnauthenticated()
        {
            using var client = new HttpClient(new HttpClientHandler
            {
                AllowAutoRedirect = false,
                MaxAutomaticRedirections = 5,
            });
            using var request = new HttpRequestMessage(HttpMethod.Get, $"https://github.com/{GITHUB_OWNER}/{GITHUB_PROJECT}/releases/latest/download/{GITHUB_RELEASE_FILE_ZIP}");
            using var response = client.Send(request);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new TokenRequiredException();
            }
            if (response.StatusCode < (HttpStatusCode)300)
            {
                throw new Exception($"Risposta non valida dal server ({(int)response.StatusCode}): {GetResponseText(response)}");
            }
            if (response.StatusCode >= (HttpStatusCode)400)
            {
                throw new Exception($"Risposta non valida dal server ({(int)response.StatusCode}): {GetResponseText(response)}");
            }
            var location = response.Headers.Location;
            if (location == null)
            {
                throw new Exception($"Risposta non valida dal server ({(int)response.StatusCode}): {GetResponseText(response)}");
            }
            var locationString = location.ToString();
            var suffix = "/" + GITHUB_RELEASE_FILE_ZIP;
            if (!locationString.EndsWith(suffix))
            {
                throw new Exception($"Risposta non valida dal server ({response.StatusCode}): {location}");
            }
            locationString = locationString[..^suffix.Length];
            var p = locationString.LastIndexOf('/');
            if (p < 0)
            {
                throw new Exception($"Risposta non valida dal server ({response.StatusCode}): {location}");
            }
            locationString = locationString[(p + 1)..];
            var version = Version.Parse(locationString);
            return new ReleaseVersion(version, location, this.DownloadUnauthenticated);
        }

        private ReleaseVersion GetLatestVersionAuthenticated()
        {
            using var client = new HttpClient(new HttpClientHandler
            {
                AllowAutoRedirect = true,
                MaxAutomaticRedirections = 5,
            });
            using var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.github.com/repos/{GITHUB_OWNER}/{GITHUB_PROJECT}/releases/latest");
            request.Headers.Authorization = new AuthenticationHeaderValue("token", this.GithubToken);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            if (request.Headers.UserAgent.Count == 0)
            {
                request.Headers.UserAgent.ParseAdd("ADBMailer");
            }
            using var response = client.Send(request);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new TokenInvalidException();
            }
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Risposta non valida dal server ({(int)response.StatusCode}): {GetResponseText(response)}");
            }
            var contentFetcher = response.Content.ReadAsStringAsync();
            contentFetcher.Wait();
            var json = contentFetcher.Result;
            var versionInfo = JsonSerializer.Deserialize<JsonVersion>(json);
            if (versionInfo == null || string.IsNullOrEmpty(versionInfo.TagName) || versionInfo.Assets == null)
            {
                throw new Exception($"Risposta non valida dal server ({(int)response.StatusCode}):\n{json}");
            }
            var asset = versionInfo.Assets.FirstOrDefault(a => GITHUB_RELEASE_FILE_ZIP.Equals(a?.Name, StringComparison.OrdinalIgnoreCase));
            if (asset?.DownloadUrl == null)
            {
                throw new Exception($"Risposta non valida dal server ({(int)response.StatusCode}):\n{json}");
            }
            var version = Version.Parse(versionInfo.TagName);
            return new ReleaseVersion(version, asset.DownloadUrl, this.DownloadAuthenticated);
        }

        private FileInfo DownloadUnauthenticated(Uri url)
        {
            using var client = new HttpClient(new HttpClientHandler
            {
                AllowAutoRedirect = true,
                MaxAutomaticRedirections = 5,
            });
            using var request = new HttpRequestMessage(HttpMethod.Get, url);
            using var response = client.Send(request);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Risposta non valida dal server ({(int)response.StatusCode}): {GetResponseText(response)}");
            }
            string zipFile = Program.Temp.GenerateNewFileName("zip");
            using (var fs = new FileStream(zipFile, FileMode.CreateNew))
            {
                response.Content.CopyToAsync(fs).Wait();
            }
            return new FileInfo(zipFile);
        }

        private FileInfo DownloadAuthenticated(Uri zipUrl)
        {
            using var client = new HttpClient(new HttpClientHandler
            {
                AllowAutoRedirect = true,
                MaxAutomaticRedirections = 5,
            });
            using var request = new HttpRequestMessage(HttpMethod.Get, zipUrl.AbsoluteUri);
            request.Headers.Authorization = new AuthenticationHeaderValue("token", this.GithubToken);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/octet-stream"));
            if (request.Headers.UserAgent.Count == 0)
            {
                request.Headers.UserAgent.ParseAdd("ADBMailer");
            }
            using var response = client.Send(request);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Risposta non valida dal server ({(int)response.StatusCode}): {GetResponseText(response)}");
            }
            string zipFile = Program.Temp.GenerateNewFileName("zip");
            using (var fs = new FileStream(zipFile, FileMode.CreateNew))
            {
                response.Content.CopyToAsync(fs).Wait();
            }
            return new FileInfo(zipFile);
        }

        private static string GetResponseText(HttpResponseMessage response)
        {
            try
            {
                foreach (var ct in response.Content.Headers.GetValues("Content-Type"))
                {
                    if (!string.IsNullOrEmpty(ct) && (ct.Equals("text", StringComparison.InvariantCultureIgnoreCase) || ct.StartsWith("text/", StringComparison.InvariantCultureIgnoreCase)))
                    {
                        var contentGetter = response.Content.ReadAsStringAsync();
                        contentGetter.Wait();
                        return contentGetter.Result;
                    }
                }
            }
            catch
            {
                ;
            }
            return response.StatusCode.ToString();
        }

        public static UpdaterScript BuildUpdateScript(FileInfo zipFile)
        {
            FileInfo? msiFile = null;
            using var zip = ZipFile.OpenRead(zipFile.FullName);
            foreach (var zipEntry in zip.Entries)
            {
                var entryName = zipEntry.Name.TrimStart('/', '\\');
                if (GITHUB_RELEASE_FILE_MSI.Equals(entryName, StringComparison.InvariantCultureIgnoreCase))
                {
                    var msiFilePath = Program.Temp.GenerateNewFileName("msi");
                    zipEntry.ExtractToFile(msiFilePath);
                    msiFile = new FileInfo(msiFilePath);
                    break;
                }
            }
            if (msiFile == null)
            {
                throw new Exception($"Impossibile trovare il file {GITHUB_RELEASE_FILE_MSI} nell'archivio scaricato");
            }
            try
            {
                var msiExecPath = Path.Combine(Environment.SystemDirectory, "msiexec.exe");
                if (!File.Exists(msiExecPath))
                {
                    throw new FileNotFoundException($"Impossibile trovare il file {msiExecPath}", msiExecPath);
                }
                var tmp = Path.GetFullPath(Path.GetTempPath());
                if (!Directory.Exists(tmp))
                {
                    Directory.CreateDirectory(tmp);
                }
                var tempMSI = "";
                var tempBAT = "";
                for (var i = 0; ; i++)
                {
                    tempMSI = Path.Combine(tmp, $"ADBMailer{i}.msi");
                    tempBAT = Path.Combine(tmp, $"ADBMailer{i}.bat");
                    if (!File.Exists(tempMSI) && !Directory.Exists(tempMSI) && !File.Exists(tempBAT) && !Directory.Exists(tempBAT))
                    {
                        break;
                    }
                }
                var batContent = BATCONTENT_TEMPLATE
                    .Replace("\r\n", "\n")
                    .Replace("\r", "\n")
                    .Replace("\n", Environment.NewLine)
                    .Replace("<MSIEXEC>", msiExecPath)
                    .Replace("<PRODUCT_CODE>", PRODUCT_CODE)
                    .Replace("<NEWMSIFILE>", tempMSI)
                    .Replace("<INSTALLDIR>", GetInstallDir())
                ;
                File.WriteAllText(tempBAT, batContent);
                try
                {
                    msiFile.MoveTo(tempMSI);
                    msiFile = null;
                }
                catch
                {
                    try { File.Delete(tempBAT); } catch { }
                    throw;
                }
                return new UpdaterScript(new FileInfo(tempBAT), new FileInfo(tempMSI));
            }
            finally
            {
                if (msiFile != null)
                {
                    msiFile.Delete();
                }
            }
        }

        private static string GetInstallDir()
        {
            var dir = "";
            var exe = Assembly.GetEntryAssembly()?.Location;
            if (!string.IsNullOrEmpty(exe))
            {
                dir = Path.GetDirectoryName(exe);
            }
            if (string.IsNullOrEmpty(dir))
            {
                throw new Exception("Impossibile determinare il percorso dell'eseguibile.");
            }
            return dir;
        }
    }
}