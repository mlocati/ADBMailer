using MimeKit;
using System.Diagnostics;
using System.Globalization;

namespace ADBMailer
{
    public partial class frmOptions : Form
    {
        private class CultureInfoWrapper
        {
            public readonly CultureInfo Value;
            public readonly string Name;

            public CultureInfoWrapper(CultureInfo cultureInfo)
            {
                this.Value = cultureInfo;
                this.Name = cultureInfo.DisplayName;
            }

            public override string ToString()
            {
                return this.Name;
            }
        }

        private class SecurityWrapper
        {
            public readonly SmtpConfig.Securities Value;
            public readonly string Name;

            public SecurityWrapper(SmtpConfig.Securities value)
            {
                this.Value = value;
                this.Name = SmtpConfig.SecurityAttribute.GetDisplayName(value);
            }

            public override string ToString()
            {
                return this.Name;
            }
        }

        private class AuthentcationWrapper
        {
            public readonly SmtpConfig.Authentications Value;
            public readonly string Name;
            public readonly bool AskLoginAndPassword;

            public AuthentcationWrapper(SmtpConfig.Authentications value)
            {
                this.Value = value;
                this.Name = SmtpConfig.AuthenticationAttribute.GetDisplayName(value);
                this.AskLoginAndPassword = SmtpConfig.AuthenticationAttribute.GetAskLoginPassword(value);
            }

            public override string ToString()
            {
                return this.Name;
            }
        }

        public frmOptions()
        {
            InitializeComponent();
            if (Program.ExeIcon != null)
            {
                this.Icon = Program.ExeIcon;
            }
            this.cbxPdfGenerationWith.Items.AddRange(new string[] { Options.GENERATEPDFWITH_MICROSOFTWORD, Options.GENERATEPDFWITH_LIBREOFFICE });
            this.cbxPdfGenerationWith.SelectedItem = Options.GeneratePdfWith;

            this.tbxPathSofficeCom.Text = Options.LibreOfficeSofficeComPath;
            if (this.tbxPathSofficeCom.Text.Length > 0 && File.Exists(this.tbxPathSofficeCom.Text))
            {
                this.ofdPathSofficeCom.InitialDirectory = Path.GetDirectoryName(this.tbxPathSofficeCom.Text);
            }
            this.tbxSmtpDefaultSender.Text = Options.Smtp.DefaultSender == null ? "" : Options.Smtp.DefaultSender.ToString();
            this.tbxSmtpHost.Text = Options.Smtp.Host;
            this.nudSmtpPort.Value = Options.Smtp.Port;
            foreach (SmtpConfig.Securities value in Enum.GetValues(typeof(SmtpConfig.Securities)))
            {
                var wrapper = new SecurityWrapper(value);
                this.cbxSmtpSecurity.Items.Add(wrapper);
                if (wrapper.Value == Options.Smtp.Security)
                {
                    this.cbxSmtpSecurity.SelectedItem = wrapper;
                }
            }
            foreach (SmtpConfig.Authentications value in Enum.GetValues(typeof(SmtpConfig.Authentications)))
            {
                var wrapper = new AuthentcationWrapper(value);
                this.cbxSmtpAuth.Items.Add(wrapper);
                if (wrapper.Value == Options.Smtp.Authentication)
                {
                    this.cbxSmtpAuth.SelectedItem = wrapper;
                }
            }
            this.tbxSmtpUsername.Text = Options.Smtp.Username;
            this.tbxSmtpPassword.Text = Options.Smtp.Password;
            this.tbxSmtpHelo.Text = Options.Smtp.HeloDomain;
            this.cbxCheckCertificateRevocation.Checked = Options.Smtp.CheckCertificateRevocation;
            var cultureInfos = CultureInfo.GetCultures(System.Globalization.CultureTypes.AllCultures);
            List<CultureInfoWrapper> wrappedCultureInfos = new(cultureInfos.Length);
            CultureInfo currentCultureInfo = Options.GeneratePdfLocale;
            CultureInfoWrapper? currentWrappedCultureInfo = null;
            foreach (var cultureInfo in cultureInfos)
            {
                wrappedCultureInfos.Add(new CultureInfoWrapper(cultureInfo));
            }
            if (cultureInfos.Contains(currentCultureInfo))
            {
                foreach (var wrappedCultureInfo in wrappedCultureInfos)
                {
                    if (wrappedCultureInfo.Value.Equals(currentCultureInfo))
                    {
                        currentWrappedCultureInfo = wrappedCultureInfo;
                        break;
                    }
                }
            }
            else
            {
                currentWrappedCultureInfo = new CultureInfoWrapper(currentCultureInfo);
                wrappedCultureInfos.Add(currentWrappedCultureInfo);
            }
            wrappedCultureInfos.Sort(delegate (CultureInfoWrapper a, CultureInfoWrapper b)
            {
                return string.Compare(a.Name, b.Name, true);
            });
            this.cbxPdfGenerationLocale.Items.AddRange(wrappedCultureInfos.ToArray());
            this.cbxPdfGenerationLocale.SelectedItem = currentWrappedCultureInfo;
        }

        private void cbxSmtpAuth_SelectedIndexChanged(object sender, EventArgs e)
        {
            var askLoginPassword = this.cbxSmtpAuth.SelectedItem is AuthentcationWrapper authentication && authentication.AskLoginAndPassword;
            this.tbxSmtpPassword.Enabled = this.tbxSmtpUsername.Enabled = askLoginPassword;
        }

        private SmtpConfig? BuildSmtpConfig()
        {
            var sDefaultSender = this.tbxSmtpDefaultSender.Text.Trim();
            MailboxAddress? defaultSender = null;
            if (sDefaultSender != "")
            {
                defaultSender = MailService.ParseString(sDefaultSender, out string reason);
                if (defaultSender == null)
                {
                    MessageBox.Show(this, $"Il mittente predefinito non è valido:{Environment.NewLine}{reason}", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.tbxSmtpDefaultSender.Focus();
                    return null;
                }
            }

            var host = this.tbxSmtpHost.Text.Trim();
            if (host == "")
            {
                MessageBox.Show(this, "Specificare il server da usare per l'invio delle email.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbxSmtpHost.Focus();
                return null;
            }
            var port = (int)this.nudSmtpPort.Value;
            if (this.cbxSmtpSecurity.SelectedItem is not SecurityWrapper securityWrapper)
            {
                MessageBox.Show(this, "Specificare la sicurezza per la connessione al server per l'invio delle email.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cbxSmtpSecurity.Focus();
                return null;
            }
            if (this.cbxSmtpAuth.SelectedItem is not AuthentcationWrapper authenticationWrapper)
            {
                MessageBox.Show(this, "Specificare l'autenticazione al server per l'invio delle email.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cbxSmtpAuth.Focus();
                return null;
            }
            string username = "", password = "";
            if (authenticationWrapper.AskLoginAndPassword)
            {
                username = this.tbxSmtpUsername.Text.Trim();
                if (username == "")
                {
                    MessageBox.Show(this, "Specificare il nome utente per il server per l'invio delle email.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.tbxSmtpUsername.Focus();
                    return null;
                }
                password = this.tbxSmtpPassword.Text;
            }
            string heloDomain = this.tbxSmtpHelo.Text.Trim();
            return new SmtpConfig(
                defaultSender,
                host,
                port,
                securityWrapper.Value,
                authenticationWrapper.Value,
                username,
                password,
                heloDomain,
                this.cbxCheckCertificateRevocation.Checked
            );
        }

        private void lnkSmtpTest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var smtpConfig = this.BuildSmtpConfig();
            if (smtpConfig == null)
            {
                return;
            }
            using var form = new frmSmtpTest(smtpConfig);
            form.ShowDialog(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.cbxPdfGenerationLocale.SelectedItem is not CultureInfoWrapper wrappedCultureInfo)
            {
                MessageBox.Show(this, "Selezionare la lingua da usare quando si generanoi documenti PDF.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cbxPdfGenerationLocale.Focus();
                return;
            }
            string generatePdfWith = this.cbxPdfGenerationWith.SelectedItem as string ?? "";
            var sofficeBin = this.tbxPathSofficeCom.Text.Trim();
            switch (generatePdfWith)
            {
                case Options.GENERATEPDFWITH_MICROSOFTWORD:
                    if (!WordConverter.MicrosoftWordApp.CheckAvailability())
                    {
                        MessageBox.Show(this, "Microsoft Word non è installato. Installarlo o utilizzare un altro programma.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.cbxPdfGenerationWith.Focus();
                        return;
                    }
                    break;

                case Options.GENERATEPDFWITH_LIBREOFFICE:
                    if (sofficeBin.Length == 0)
                    {
                        MessageBox.Show(this, "Specificare il percorso di LibreOffice.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.tbxPathSofficeCom.Focus();
                        return;
                    }
                    if (!File.Exists(sofficeBin))
                    {
                        MessageBox.Show(this, "Il percorso di LibreOffice non è valido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.tbxPathSofficeCom.Focus();
                        return;
                    }
                    break;

                default:
                    MessageBox.Show(this, "Specificare il programma da usare per generare i PDF.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.cbxPdfGenerationWith.Focus();
                    return;
            }

            var smtpConfig = this.BuildSmtpConfig();
            if (smtpConfig == null)
            {
                return;
            }
            Options.GeneratePdfLocale = wrappedCultureInfo.Value;
            Options.GeneratePdfWith = generatePdfWith;
            Options.LibreOfficeSofficeComPath = sofficeBin;
            Options.Smtp = smtpConfig;
            this.DialogResult = DialogResult.OK;
        }

        private void btnPathSofficeCom_Click(object sender, EventArgs e)
        {
            if (this.ofdPathSofficeCom.ShowDialog(this) == DialogResult.OK)
            {
                this.tbxPathSofficeCom.Text = this.ofdPathSofficeCom.FileName;
            }
        }

        private void lnkPathSofficeCom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo("https://it.libreoffice.org/") { UseShellExecute = true });
            }
            catch (Exception x)
            {
                MessageBox.Show(this, x.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxPdfGenerationWith_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lnkPathSofficeCom.Visible = this.btnPathSofficeCom.Visible = this.tbxPathSofficeCom.Visible = this.lblPathSofficeCom.Visible = Options.GENERATEPDFWITH_LIBREOFFICE.Equals(this.cbxPdfGenerationWith.SelectedItem);
        }
    }
}