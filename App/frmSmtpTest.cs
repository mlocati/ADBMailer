using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using System.ComponentModel;

namespace ADBMailer
{
    public partial class frmSmtpTest : Form
    {
        private readonly SmtpConfig _smtpConfig;

        private class SendingParams
        {
            public readonly MailboxAddress From;
            public readonly MailboxAddress To;

            public SendingParams(MailboxAddress from, MailboxAddress to)
            {
                this.From = from;
                this.To = to;
            }
        }

        public frmSmtpTest(SmtpConfig smtpConfig)
        {
            InitializeComponent();
            if (Program.ExeIcon != null)
            {
                this.Icon = Program.ExeIcon;
            }
            this._smtpConfig = smtpConfig;
            if (this._smtpConfig.DefaultSender != null)
            {
                this.tbxSender.Text = this._smtpConfig.DefaultSender.ToString();
            }
            var prev = Options.LastTestRecipient;
            if (prev != null)
            {
                this.tbxRecipient.Text = prev.ToString();
            }
        }

        private void frmSmtpTest_Shown(object sender, EventArgs e)
        {
            if (this.tbxSender.Text == "")
            {
                this.tbxSender.Focus();
            }
            else
            {
                this.tbxRecipient.Focus();
            }
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            if (this.bgwSend.IsBusy)
            {
                return;
            }
            var sFrom = this.tbxSender.Text.Trim();
            if (sFrom == "")
            {
                MessageBox.Show(this, "Specificare il mittente dell'email di prova.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbxSender.Focus();
                return;
            }
            MailboxAddress? from = MailService.GetAddressFromString(sFrom, out string reason);
            if (from == null)
            {
                MessageBox.Show(this, $"Il mittente dell'email di prova non è valido:{Environment.NewLine}{reason}", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbxSender.Focus();
                return;
            }
            var sTo = this.tbxRecipient.Text.Trim();
            if (sTo == "")
            {
                MessageBox.Show(this, "Specificare il destinatario dell'email di prova.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbxRecipient.Focus();
                return;
            }
            MailboxAddress? to = MailService.GetAddressFromString(sTo, out reason);
            if (to == null)
            {
                MessageBox.Show(this, $"Il destinatario dell'email di prova non è valido:{Environment.NewLine}{reason}", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbxRecipient.Focus();
                return;
            }
            Options.LastTestRecipient = to;
            this.tbxResult.Clear();
            this.Cursor = Cursors.AppStarting;
            this.btnSendEmail.Enabled = this.btnClose.Enabled = false;
            this.bgwSend.RunWorkerAsync(new SendingParams(from, to));
        }

        private void bgwSend_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (e.Argument is not SendingParams sendingParams)
                {
                    throw new InvalidOperationException();
                }
                this.bgwSend.ReportProgress(-1, "Creazione messaggio...");
                var message = new MimeMessage();
                message.From.Add(sendingParams.From);
                message.To.Add(sendingParams.To);
                var now = DateTime.Now;
                message.Subject = $"Email di prova di ADBMailer delle {now.Hour:D2}:{now.Minute:D2}:{now.Second:D2}";
                message.Body = new TextPart(TextFormat.Plain)
                {
                    Text = String.Join("\n", new String[] {
                        $"Se questa email è stata ricevuta, la configuazione dovrebbe essere corretta.",
                        "",
                        "Parametri utilizzati:",
                        $"- server        : {this._smtpConfig.Host}",
                        $"- porta         : {this._smtpConfig.Port}",
                        $"- sicurezza     : {SmtpConfig.SecurityAttribute.GetDisplayName(this._smtpConfig.Security)}",
                        $"- autenticazione: {SmtpConfig.AuthenticationAttribute.GetDisplayName(this._smtpConfig.Authentication)}",
                        $"- nome utente   : {this._smtpConfig.Username}",
                        $"",
                    })
                };
                this.bgwSend.ReportProgress(-1, "Connessione al server...");
                using (var client = this._smtpConfig.CreateClient())
                {
                    this.bgwSend.ReportProgress(-1, $"Protocollo SSL: {client.SslProtocol}");
                    this.bgwSend.ReportProgress(-1, $"Funzionalità: {client.Capabilities}");
                    if (client.Capabilities.HasFlag(SmtpCapabilities.Size))
                    {
                        this.bgwSend.ReportProgress(-1, $"Dimensione massima messaggi: {client.MaxSize}");
                    }
                    try
                    {
                        this.bgwSend.ReportProgress(-1, "Invio del messaggio...");
                        client.Send(message);
                    }
                    finally
                    {
                        try
                        {
                            client.Disconnect(true);
                        }
                        catch { }
                    }
                }
                this.bgwSend.ReportProgress(-1, "Messaggio inviato correttamente.");
            }
            catch (Exception x)
            {
                this.bgwSend.ReportProgress(-1, $"ERRORE!{Environment.NewLine}{Environment.NewLine}{x.Message}");
            }
        }

        private void bgwSend_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var text = e.UserState as string;
            if (!string.IsNullOrEmpty(text))
            {
                this.tbxResult.AppendText(text + Environment.NewLine);
            }
        }

        private void bgwSend_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Cursor = Cursors.Default;
            this.btnSendEmail.Enabled = this.btnClose.Enabled = true;
        }

        private void frmSmtpTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.bgwSend.IsBusy)
            {
                e.Cancel = true;
            }
        }
    }
}