using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace ADBMailer
{
    public class SmtpConfig
    {
        [AttributeUsage(AttributeTargets.Field)]
        public class SecurityAttribute : Attribute
        {
            public readonly string DisplayName;
            public readonly SecureSocketOptions ActualValue;

            public SecurityAttribute(string displayName, SecureSocketOptions actualValue)
            {
                this.DisplayName = displayName;
                this.ActualValue = actualValue;
            }

            private static Type? _enumType = null;

            private static Type EnumType
            {
                get => _enumType ??= typeof(Securities);
            }

            private static SecurityAttribute? GetFor(Securities value)
            {
                var enumType = EnumType;
                var valueName = Enum.GetName(enumType, value);
                if (valueName == null)
                {
                    return null;
                }
                var valueField = enumType.GetField(valueName);
                if (valueField == null)
                {
                    return null;
                }
                return valueField.GetCustomAttributes(false).OfType<SecurityAttribute>().SingleOrDefault();
            }

            public static string GetDisplayName(Securities security)
            {
                var attr = GetFor(security);
                return attr == null ? security.ToString() : attr.DisplayName;
            }

            public static SecureSocketOptions GetActualValue(Securities security)
            {
                var attr = GetFor(security);
                if (attr == null)
                {
                    throw new Exception("Valore di sicurezza non valido");
                }
                return attr.ActualValue;
            }
        }

        public enum Securities
        {
            [Security("Nessuna", SecureSocketOptions.None)]
            None,

            [Security("Automatica", SecureSocketOptions.Auto)]
            Auto,

            [Security("SSL o TLS (immediatamente)", SecureSocketOptions.SslOnConnect)]
            SslOnConnect,

            [Security("STARTTLS (TLS subito dopo la connessione)", SecureSocketOptions.StartTls)]
            StartTls,

            [Security("STARTTLS (TLS subito dopo la connessione) se disponibile", SecureSocketOptions.StartTlsWhenAvailable)]
            StartTlsWhenAvailable
        }

        [AttributeUsage(AttributeTargets.Field)]
        public class AuthenticationAttribute : Attribute
        {
            public readonly string DisplayName;
            public readonly bool AskLoginPassword;

            public AuthenticationAttribute(string displayName, bool askLoginPassword)
            {
                this.DisplayName = displayName;
                this.AskLoginPassword = askLoginPassword;
            }

            private static Type? _enumType = null;

            private static Type EnumType
            {
                get => _enumType ??= typeof(Authentications);
            }

            private static AuthenticationAttribute? GetFor(Authentications value)
            {
                var enumType = EnumType;
                var valueName = Enum.GetName(enumType, value);
                if (valueName == null)
                {
                    return null;
                }
                var valueField = enumType.GetField(valueName);
                if (valueField == null)
                {
                    return null;
                }
                return valueField.GetCustomAttributes(false).OfType<AuthenticationAttribute>().SingleOrDefault();
            }

            public static string GetDisplayName(Authentications authentication)
            {
                var attr = GetFor(authentication);
                return attr == null ? authentication.ToString() : attr.DisplayName;
            }

            public static bool GetAskLoginPassword(Authentications authentication)
            {
                var attr = GetFor(authentication);
                return attr == null || attr.AskLoginPassword;
            }
        }

        public enum Authentications
        {
            [Authentication("Nessuna", false)]
            None,

            [Authentication("Login e password", true)]
            Login,
        }

        private delegate void Authenticator(SmtpClient client);

        public readonly MailboxAddress? DefaultSender;
        public readonly string Host;
        public readonly int Port;
        public readonly Securities Security;
        public readonly Authentications Authentication;
        public readonly string Username;
        public readonly string Password;
        public readonly string HeloDomain;

        public SmtpConfig(MailboxAddress? defaultSender, string host, int port, Securities security, Authentications authentication, string username, string password, string heloDomain)
        {
            this.DefaultSender = defaultSender;
            this.Host = host;
            this.Port = port;
            this.Security = security;
            this.Authentication = authentication;
            this.Username = username;
            this.Password = password;
            this.HeloDomain = heloDomain;
        }

        public SmtpClient CreateClient()
        {
            var client = new SmtpClient();
            if (this.Host == "")
            {
                throw new Exception("Il servizio di invio delle email non è configurato (manca il nome del server).");
            }
            Authenticator? authenticator = null;
            switch (this.Authentication)
            {
                case Authentications.None:
                    break;

                case Authentications.Login:
                    if (this.Username == "")
                    {
                        throw new Exception("Il servizio di invio delle email non è configurato (manca il nome utente).");
                    }
                    authenticator = delegate (SmtpClient client)
                    {
                        client.Authenticate(this.Username, this.Password);
                    };
                    break;

                default:
                    throw new Exception("Il servizio di invio delle email non è configurato (manca la modalità di autenticazione).");
            }
            if (this.HeloDomain != "")
            {
                client.LocalDomain = this.HeloDomain;
            }
            try
            {
                client.Connect(this.Host, this.Port, SecurityAttribute.GetActualValue(this.Security));
            }
            catch (Exception x)
            {
                throw new Exception($"Errore durante la connessione al server che invia le email:{Environment.NewLine}{x.Message}", x);
            }
            if (authenticator != null)
            {
                try
                {
                    authenticator(client);
                }
                catch (Exception x)
                {
                    try
                    {
                        client.Disconnect(true);
                    }
                    catch { }
                    throw new Exception($"Errore durante l'autenticazione al server che invia le email:{Environment.NewLine}{x.Message}", x);
                }
            }
            return client;
        }
    }
}