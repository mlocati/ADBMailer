namespace ADBMailer
{
    internal class VolatileDirectory : IDisposable
    {
        private const string LOCK_FILENAME = ".lock";
        private string DirectoryPath = "";
        private FileStream? FileLock = null;
        private long Counter = 0L;

        public VolatileDirectory()
        {
            var tmp = Path.GetFullPath(Path.GetTempPath());
            if (!Directory.Exists(tmp))
            {
                Directory.CreateDirectory(tmp);
            }
            for (var i = 0; i < int.MaxValue; i++)
            {
                var myPath = Path.Combine(tmp, $"ADBMailer-{i}");
                var myLock = AcquireLock(myPath);
                if (myLock != null)
                {
                    this.DirectoryPath = myPath;
                    this.FileLock = myLock;
                    return;
                }
            }
            throw new Exception("Impossibile inizializzare la cartella temporanea");
        }

        public string GenerateNewFileName(string extension)
        {
            extension = extension.TrimStart('.');
            if (extension.Length > 0)
            {
                extension = "." + extension;
            }
            var result = Path.Combine(this.DirectoryPath, this.Counter.ToString() + extension);
            this.Counter++;
            return result;
        }

        public DirectoryInfo CreateNewEmptyDirectory()
        {
            var result = Path.Combine(this.DirectoryPath, this.Counter.ToString());
            this.Counter++;
            return Directory.CreateDirectory(result);
        }

        public void Dispose()
        {
            if (this.FileLock != null)
            {
                try { this.FileLock.Close(); } catch { }
                try { this.FileLock.Dispose(); } catch { }
                this.FileLock = null;
            }
            if (this.DirectoryPath.Length > 0)
            {
                try { Directory.Delete(this.DirectoryPath, true); } catch { }
                this.DirectoryPath = "";
            }
        }

        private static FileStream? AcquireLock(string path)
        {
            if (File.Exists(path))
            {
                return null;
            }
            if (Directory.Exists(path))
            {
                try
                {
                    var lockFilePath = Path.Combine(path, LOCK_FILENAME);
                    if (File.Exists(lockFilePath))
                    {
                        File.Delete(lockFilePath);
                    }
                    Directory.Delete(path, true);
                }
                catch
                {
                    return null;
                }
            }
            var di = Directory.CreateDirectory(path);
            try
            {
                var lockFile = Path.Combine(path, LOCK_FILENAME);
                return File.Open(lockFile, FileMode.CreateNew, FileAccess.Write, FileShare.Read);
            }
            catch
            {
                try { di.Delete(true); } catch { }
                return null;
            }
        }
    }
}