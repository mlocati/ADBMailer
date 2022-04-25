using MailKit.Net.Smtp;
using MimeKit;

namespace ADBMailer
{
    internal class MailSender : IDisposable
    {
        private readonly SmtpConfig SmtpConfig;
        private SmtpClient SmtpClient;
        private uint _numRetries = 2;

        public uint NumRetries
        {
            get { return this._numRetries; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("NumRetries");
                }
                this._numRetries = value;
            }
        }

        public MailSender(SmtpConfig smtpConfig)
        {
            this.SmtpConfig = smtpConfig;
            this.SmtpClient = smtpConfig.CreateClient();
        }

        public void Send(MimeMessage message)
        {
            for (int i = 1; i < this.NumRetries; i++)
            {
                try
                {
                    this.SmtpClient.Send(message);
                    return;
                }
                catch (ArgumentNullException) { throw; }
                catch (InvalidOperationException) { throw; }
                catch { }
                this.CloseClient();
                this.SmtpClient = this.SmtpConfig.CreateClient();
            }
            this.SmtpClient.Send(message);
        }

        private void CloseClient()
        {
            try
            {
                if (this.SmtpClient.IsConnected)
                {
                    this.SmtpClient.Disconnect(true);
                }
            }
            catch { }
        }

        public void Dispose()
        {
            this.CloseClient();
        }
    }
}