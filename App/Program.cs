using System.Diagnostics;
using System.Reflection;

namespace ADBMailer
{
    internal static class Program
    {
        public static VolatileDirectory? _temp = null;

        public static VolatileDirectory Temp
        {
            get
            {
                if (_temp == null)
                {
                    _temp = new VolatileDirectory();
                }
                return _temp;
            }
        }

        private static Icon? _exeIcon = null;
        private static bool _exeIconExtracted = false;

        private static Version? _version = null;
        private static bool _versionExtracted = false;

        [STAThread]
        private static void Main()
        {
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            try
            {
                Application.Run(new frmMain());
            }
            finally
            {
                if (_temp != null)
                {
                    _temp.Dispose();
                    _temp = null;
                }
            }
        }

        public static Icon? ExeIcon
        {
            get
            {
                if (_exeIconExtracted)
                {
                    return _exeIcon;
                }
                try
                {
                    var process = Process.GetCurrentProcess();
                    var module = process.MainModule;
                    if (module != null)
                    {
                        var exeName = module.FileName;
                        if (!string.IsNullOrEmpty(exeName))
                        {
                            _exeIcon = Icon.ExtractAssociatedIcon(exeName);
                        }
                    }
                }
                catch { }
                _exeIconExtracted = true;
                return _exeIcon;
            }
        }

        public static Version? Version
        {
            get
            {
                if (_versionExtracted)
                {
                    return _version;
                }
                try
                {
                    _version = Assembly.GetExecutingAssembly().GetName().Version;
                }
                catch { }
                _versionExtracted = true;
                return _version;
            }
        }
    }
}