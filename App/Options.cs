using Microsoft.Win32;
using MimeKit;
using System.Configuration;
using System.Globalization;

namespace ADBMailer
{
    internal static class Options
    {
        private const string DEFAULT_LAST_PDFNAMEFIELD = "socio";
        public const string GENERATEPDFWITH_MICROSOFTWORD = "Microsoft Word";
        public const string GENERATEPDFWITH_LIBREOFFICE = "LibreOffice";
        private const string KEY_LAST_EXCELFILES_DIR = "ExcelFilesDirectory";
        private const string KEY_LAST_WORDFILES_DIR = "WordFilesDirectory";
        private const string KEY_LAST_PDFOUTPUT_DIR = "LastPdfOutputDirectory";
        private const string KEY_LAST_TESTRECIPIENT = "LastTestRecipient";
        private const string KEY_LAST_PDFNAMEFIELD = "LastPdfNameField";
        private const string KEY_KEY_GENERATELOCALE = "GeneratePdfLocale";
        private const string KEY_GENERATEPDFWITH = "GeneratePdfWith";
        private const string KEY_LIBREOFFICE_SOFFICECOMPATH = "LibreOfficeSofficePath";
        private const string KEY_SMTP_DEFAULTSENDER = "SmtpDefaultSender";
        private const string KEY_SMTP_HOST = "SmtpHost";
        private const string KEY_SMTP_PORT = "SmtpPort";
        private const string KEY_SMTP_SECURITY = "SmtpSecurity";
        private const string KEY_SMTP_AUTHENTICATION = "SmtpAuthentication";
        private const string KEY_SMTP_USERNAME = "SmtpUsername";
        private const string KEY_SMTP_PASSWORD = "SmtpPassword";
        private const string KEY_SMTP_HELODOMAIN = "SmtpHeloDomain";
        private const string KEY_GITHUB_TOKEN = "GithubToken";

        private static Configuration? _configFile = null;

        private static Configuration ConfigFile
        {
            get
            {
                if (_configFile == null)
                {
                    lock (typeof(Options))
                    {
                        if (_configFile == null)
                        {
                            var configFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ADBMailer", "options.config");
                            var fileMap = new ExeConfigurationFileMap
                            {
                                ExeConfigFilename = configFilePath
                            };
                            var configFile = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                            _configFile = configFile;
                        }
                    }
                }
                return _configFile;
            }
        }

        private static KeyValueConfigurationCollection ConfigSettings
        {
            get => ConfigFile.AppSettings.Settings;
        }

        public static CultureInfo GeneratePdfLocale
        {
            get
            {
                var name = GetSettings(KEY_KEY_GENERATELOCALE);
                if (name.Length > 0)
                {
                    try
                    {
                        return CultureInfo.GetCultureInfo(name);
                    }
                    catch { }
                }
                return CultureInfo.CurrentCulture;
            }
            set => SaveSetting(KEY_KEY_GENERATELOCALE, value.Name);
        }

        public static string GeneratePdfWith
        {
            get
            {
                var value = GetSettings(KEY_GENERATEPDFWITH);
                return value switch
                {
                    GENERATEPDFWITH_LIBREOFFICE or GENERATEPDFWITH_MICROSOFTWORD => value,
                    _ => GENERATEPDFWITH_MICROSOFTWORD,
                };
            }
            set => SaveSetting(KEY_GENERATEPDFWITH, value);
        }

        public static string LibreOfficeSofficeComPath
        {
            get
            {
                var path = GetSettings(KEY_LIBREOFFICE_SOFFICECOMPATH);
                if (!string.IsNullOrEmpty(path))
                {
                    return path;
                }
                path = FindSofficeCom();
                if (path.Length > 0)
                {
                    SaveSetting(KEY_LIBREOFFICE_SOFFICECOMPATH, path);
                }
                return path;
            }
            set => SaveSetting(KEY_LIBREOFFICE_SOFFICECOMPATH, value);
        }

        public static string ExcelFilesDirectory
        {
            get => ResolveExistingDirectory(GetSettings(KEY_LAST_EXCELFILES_DIR));
            set => SaveSetting(KEY_LAST_EXCELFILES_DIR, value);
        }

        public static string WordFilesDirectory
        {
            get => ResolveExistingDirectory(GetSettings(KEY_LAST_WORDFILES_DIR));
            set => SaveSetting(KEY_LAST_WORDFILES_DIR, value);
        }

        public static string PdfOutputDirectory
        {
            get => ResolveExistingDirectory(GetSettings(KEY_LAST_PDFOUTPUT_DIR));
            set => SaveSetting(KEY_LAST_PDFOUTPUT_DIR, value);
        }

        public static MailboxAddress? LastTestRecipient
        {
            get => MailService.ParseString(GetSettings(KEY_LAST_TESTRECIPIENT));
            set => SaveSetting(KEY_LAST_TESTRECIPIENT, value == null ? "" : value.ToString());
        }

        public static string LastPdfNameField
        {
            get
            {
                var result = GetSettings(KEY_LAST_PDFNAMEFIELD);
                return result.Length == 0 ? DEFAULT_LAST_PDFNAMEFIELD : result;
            }
            set => SaveSetting(KEY_LAST_PDFNAMEFIELD, value == null ? "" : value.ToString());
        }

        private static SmtpConfig? _smtp = null;

        public static SmtpConfig Smtp
        {
            get
            {
                if (_smtp != null)
                {
                    return _smtp;
                }
                var sPort = GetSettings(KEY_SMTP_PORT).Trim();
                if (sPort == "" || !int.TryParse(sPort, out int port) || port < 1 || port > 65535)
                {
                    port = 587;
                }
                var sSecurity = GetSettings(KEY_SMTP_SECURITY).Trim();
                SmtpConfig.Securities security;
                try
                {
                    if (sSecurity == "" || !Enum.TryParse(sSecurity, out security) || !Enum.IsDefined(typeof(SmtpConfig.Securities), security))
                    {
                        security = SmtpConfig.Securities.Auto;
                    }
                }
                catch
                {
                    security = SmtpConfig.Securities.Auto;
                }
                var sAuthentication = GetSettings(KEY_SMTP_AUTHENTICATION).Trim();
                SmtpConfig.Authentications authentication;
                try
                {
                    if (sAuthentication == "" || !Enum.TryParse(sAuthentication, out authentication) || !Enum.IsDefined(typeof(SmtpConfig.Authentications), authentication))
                    {
                        authentication = SmtpConfig.Authentications.Login;
                    }
                }
                catch
                {
                    authentication = SmtpConfig.Authentications.Login;
                }
                var smtpConfig = new SmtpConfig(
                    MailService.ParseString(GetSettings(KEY_SMTP_DEFAULTSENDER)),
                    GetSettings(KEY_SMTP_HOST).Trim(),
                    port,
                    security,
                    authentication,
                    GetSettings(KEY_SMTP_USERNAME).Trim(),
                    GetSettings(KEY_SMTP_PASSWORD),
                    GetSettings(KEY_SMTP_HELODOMAIN).Trim()
                );
                _smtp = smtpConfig;
                return _smtp;
            }
            set
            {
                SaveSetting(KEY_SMTP_DEFAULTSENDER, value.DefaultSender == null ? "" : value.DefaultSender.ToString());
                SaveSetting(KEY_SMTP_HOST, value.Host);
                SaveSetting(KEY_SMTP_PORT, value.Port.ToString());
                SaveSetting(KEY_SMTP_SECURITY, value.Security.ToString());
                SaveSetting(KEY_SMTP_AUTHENTICATION, value.Authentication.ToString());
                SaveSetting(KEY_SMTP_USERNAME, value.Username);
                SaveSetting(KEY_SMTP_PASSWORD, value.Password);
                SaveSetting(KEY_SMTP_HELODOMAIN, value.HeloDomain);
                _smtp = value;
            }
        }

        public static string GitHubToken
        {
            get => GetSettings(KEY_GITHUB_TOKEN);
            set => SaveSetting(KEY_GITHUB_TOKEN, value);
        }

        private static string GetSettings(string key)
        {
            var saved = ConfigSettings[key];
            return saved == null ? "" : saved.Value;
        }

        private static void SaveSetting(string key, string value)
        {
            if (value.Length == 0)
            {
                if (ConfigSettings[key] == null)
                {
                    return;
                }
                ConfigSettings.Remove(key);
            }
            else
            {
                var oldValue = ConfigSettings[key];
                if (oldValue == null)
                {
                    ConfigSettings.Add(key, value);
                }
                else if (oldValue.Value == value)
                {
                    return;
                }
                else
                {
                    ConfigSettings[key].Value = value;
                }
            }
            ConfigFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(ConfigFile.AppSettings.SectionInformation.Name);
        }

        private static string ResolveExistingDirectory(string path)
        {
            try
            {
                if (string.IsNullOrEmpty(path))
                {
                    return path;
                }

                for (DirectoryInfo? di = new(path); di != null; di = di.Parent)
                {
                    if (di.Exists)
                    {
                        return di.FullName;
                    }
                }
            }
            catch { }
            return "";
        }

        private static string FindSofficeCom()
        {
            try
            {
                var regValue = Registry.GetValue(@$"{Registry.LocalMachine.Name}\SOFTWARE\Classes\SOFTWARE\LibreOffice\LibreOffice", "Path", null) as string;
                if (!string.IsNullOrEmpty(regValue))
                {
                    var bin = Path.Combine(regValue, @"program\soffice.com");
                    if (File.Exists(bin))
                    {
                        return bin;
                    }
                }
            }
            catch
            {
            }
            return "";
        }
    }
}