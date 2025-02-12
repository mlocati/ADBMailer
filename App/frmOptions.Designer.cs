namespace ADBMailer
{
    partial class frmOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gbxSmtp = new GroupBox();
            cbxCheckCertificateRevocation = new CheckBox();
            tbxSmtpDefaultSender = new TextBox();
            lblSmtpDefaultSender = new Label();
            lnkSmtpTest = new LinkLabel();
            tbxSmtpHelo = new TextBox();
            lblSmtpHelo = new Label();
            tbxSmtpPassword = new TextBox();
            tbxSmtpUsername = new TextBox();
            lblSmtpPassword = new Label();
            lblSmtpUsername = new Label();
            cbxSmtpAuth = new ComboBox();
            lblSmtpAuth = new Label();
            cbxSmtpSecurity = new ComboBox();
            nudSmtpPort = new NumericUpDown();
            tbxSmtpHost = new TextBox();
            lblSmtpPort = new Label();
            lblSmtpSecurity = new Label();
            lblSmtpHost = new Label();
            btnCancel = new Button();
            btnSave = new Button();
            gbxPdfGeneration = new GroupBox();
            pnlConfigureSoffice = new Panel();
            lblPathSofficeCom = new Label();
            tbxPathSofficeCom = new TextBox();
            btnPathSofficeCom = new Button();
            lnkPathSofficeCom = new LinkLabel();
            cbxPdfGenerationLocale = new ComboBox();
            lblPdfGenerationLocale = new Label();
            cbxPdfGenerationWith = new ComboBox();
            lblPdfGenerationWith = new Label();
            ofdPathSofficeCom = new OpenFileDialog();
            lblPdfQuality = new Label();
            cbxPdfQuality = new ComboBox();
            gbxSmtp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSmtpPort).BeginInit();
            gbxPdfGeneration.SuspendLayout();
            pnlConfigureSoffice.SuspendLayout();
            SuspendLayout();
            // 
            // gbxSmtp
            // 
            gbxSmtp.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbxSmtp.Controls.Add(cbxCheckCertificateRevocation);
            gbxSmtp.Controls.Add(tbxSmtpDefaultSender);
            gbxSmtp.Controls.Add(lblSmtpDefaultSender);
            gbxSmtp.Controls.Add(lnkSmtpTest);
            gbxSmtp.Controls.Add(tbxSmtpHelo);
            gbxSmtp.Controls.Add(lblSmtpHelo);
            gbxSmtp.Controls.Add(tbxSmtpPassword);
            gbxSmtp.Controls.Add(tbxSmtpUsername);
            gbxSmtp.Controls.Add(lblSmtpPassword);
            gbxSmtp.Controls.Add(lblSmtpUsername);
            gbxSmtp.Controls.Add(cbxSmtpAuth);
            gbxSmtp.Controls.Add(lblSmtpAuth);
            gbxSmtp.Controls.Add(cbxSmtpSecurity);
            gbxSmtp.Controls.Add(nudSmtpPort);
            gbxSmtp.Controls.Add(tbxSmtpHost);
            gbxSmtp.Controls.Add(lblSmtpPort);
            gbxSmtp.Controls.Add(lblSmtpSecurity);
            gbxSmtp.Controls.Add(lblSmtpHost);
            gbxSmtp.Location = new Point(12, 178);
            gbxSmtp.Name = "gbxSmtp";
            gbxSmtp.Size = new Size(648, 263);
            gbxSmtp.TabIndex = 1;
            gbxSmtp.TabStop = false;
            gbxSmtp.Text = "Server invio email";
            // 
            // cbxCheckCertificateRevocation
            // 
            cbxCheckCertificateRevocation.AutoSize = true;
            cbxCheckCertificateRevocation.Location = new Point(141, 225);
            cbxCheckCertificateRevocation.Name = "cbxCheckCertificateRevocation";
            cbxCheckCertificateRevocation.Size = new Size(158, 19);
            cbxCheckCertificateRevocation.TabIndex = 16;
            cbxCheckCertificateRevocation.Text = "Verifica revoca certificato";
            cbxCheckCertificateRevocation.UseVisualStyleBackColor = true;
            // 
            // tbxSmtpDefaultSender
            // 
            tbxSmtpDefaultSender.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbxSmtpDefaultSender.Location = new Point(141, 22);
            tbxSmtpDefaultSender.Name = "tbxSmtpDefaultSender";
            tbxSmtpDefaultSender.PlaceholderText = "IndirizzoEmail oppure Nome <IndirizzoEmail>";
            tbxSmtpDefaultSender.Size = new Size(399, 23);
            tbxSmtpDefaultSender.TabIndex = 1;
            // 
            // lblSmtpDefaultSender
            // 
            lblSmtpDefaultSender.AutoSize = true;
            lblSmtpDefaultSender.Location = new Point(6, 25);
            lblSmtpDefaultSender.Name = "lblSmtpDefaultSender";
            lblSmtpDefaultSender.Size = new Size(113, 15);
            lblSmtpDefaultSender.TabIndex = 0;
            lblSmtpDefaultSender.Text = "Mittente predefinito";
            // 
            // lnkSmtpTest
            // 
            lnkSmtpTest.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lnkSmtpTest.AutoSize = true;
            lnkSmtpTest.Location = new Point(532, 244);
            lnkSmtpTest.Name = "lnkSmtpTest";
            lnkSmtpTest.Size = new Size(110, 15);
            lnkSmtpTest.TabIndex = 17;
            lnkSmtpTest.TabStop = true;
            lnkSmtpTest.Text = "Invia email di prova";
            lnkSmtpTest.LinkClicked += lnkSmtpTest_LinkClicked;
            // 
            // tbxSmtpHelo
            // 
            tbxSmtpHelo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbxSmtpHelo.Location = new Point(141, 196);
            tbxSmtpHelo.Name = "tbxSmtpHelo";
            tbxSmtpHelo.Size = new Size(399, 23);
            tbxSmtpHelo.TabIndex = 15;
            // 
            // lblSmtpHelo
            // 
            lblSmtpHelo.AutoSize = true;
            lblSmtpHelo.Location = new Point(6, 202);
            lblSmtpHelo.Name = "lblSmtpHelo";
            lblSmtpHelo.Size = new Size(121, 15);
            lblSmtpHelo.TabIndex = 14;
            lblSmtpHelo.Text = "Dominio HELO/EHLO";
            // 
            // tbxSmtpPassword
            // 
            tbxSmtpPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbxSmtpPassword.Location = new Point(141, 167);
            tbxSmtpPassword.Name = "tbxSmtpPassword";
            tbxSmtpPassword.PasswordChar = '*';
            tbxSmtpPassword.Size = new Size(399, 23);
            tbxSmtpPassword.TabIndex = 13;
            // 
            // tbxSmtpUsername
            // 
            tbxSmtpUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbxSmtpUsername.Location = new Point(141, 138);
            tbxSmtpUsername.Name = "tbxSmtpUsername";
            tbxSmtpUsername.Size = new Size(399, 23);
            tbxSmtpUsername.TabIndex = 11;
            // 
            // lblSmtpPassword
            // 
            lblSmtpPassword.AutoSize = true;
            lblSmtpPassword.Location = new Point(6, 170);
            lblSmtpPassword.Name = "lblSmtpPassword";
            lblSmtpPassword.Size = new Size(57, 15);
            lblSmtpPassword.TabIndex = 12;
            lblSmtpPassword.Text = "Password";
            // 
            // lblSmtpUsername
            // 
            lblSmtpUsername.AutoSize = true;
            lblSmtpUsername.Location = new Point(6, 141);
            lblSmtpUsername.Name = "lblSmtpUsername";
            lblSmtpUsername.Size = new Size(77, 15);
            lblSmtpUsername.TabIndex = 10;
            lblSmtpUsername.Text = "Nome utente";
            // 
            // cbxSmtpAuth
            // 
            cbxSmtpAuth.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbxSmtpAuth.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxSmtpAuth.FormattingEnabled = true;
            cbxSmtpAuth.Location = new Point(141, 109);
            cbxSmtpAuth.Name = "cbxSmtpAuth";
            cbxSmtpAuth.Size = new Size(399, 23);
            cbxSmtpAuth.TabIndex = 9;
            cbxSmtpAuth.SelectedIndexChanged += cbxSmtpAuth_SelectedIndexChanged;
            // 
            // lblSmtpAuth
            // 
            lblSmtpAuth.AutoSize = true;
            lblSmtpAuth.Location = new Point(6, 112);
            lblSmtpAuth.Name = "lblSmtpAuth";
            lblSmtpAuth.Size = new Size(129, 15);
            lblSmtpAuth.TabIndex = 8;
            lblSmtpAuth.Text = "Metodo autenticazione";
            // 
            // cbxSmtpSecurity
            // 
            cbxSmtpSecurity.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbxSmtpSecurity.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxSmtpSecurity.FormattingEnabled = true;
            cbxSmtpSecurity.Location = new Point(141, 80);
            cbxSmtpSecurity.Name = "cbxSmtpSecurity";
            cbxSmtpSecurity.Size = new Size(399, 23);
            cbxSmtpSecurity.TabIndex = 7;
            // 
            // nudSmtpPort
            // 
            nudSmtpPort.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nudSmtpPort.Location = new Point(587, 51);
            nudSmtpPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            nudSmtpPort.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSmtpPort.Name = "nudSmtpPort";
            nudSmtpPort.Size = new Size(55, 23);
            nudSmtpPort.TabIndex = 5;
            nudSmtpPort.Value = new decimal(new int[] { 65535, 0, 0, 0 });
            // 
            // tbxSmtpHost
            // 
            tbxSmtpHost.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbxSmtpHost.Location = new Point(141, 51);
            tbxSmtpHost.Name = "tbxSmtpHost";
            tbxSmtpHost.Size = new Size(399, 23);
            tbxSmtpHost.TabIndex = 3;
            // 
            // lblSmtpPort
            // 
            lblSmtpPort.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSmtpPort.AutoSize = true;
            lblSmtpPort.Location = new Point(546, 54);
            lblSmtpPort.Name = "lblSmtpPort";
            lblSmtpPort.Size = new Size(35, 15);
            lblSmtpPort.TabIndex = 4;
            lblSmtpPort.Text = "Porta";
            // 
            // lblSmtpSecurity
            // 
            lblSmtpSecurity.AutoSize = true;
            lblSmtpSecurity.Location = new Point(6, 83);
            lblSmtpSecurity.Name = "lblSmtpSecurity";
            lblSmtpSecurity.Size = new Size(124, 15);
            lblSmtpSecurity.TabIndex = 6;
            lblSmtpSecurity.Text = "Sicurezza connessione";
            // 
            // lblSmtpHost
            // 
            lblSmtpHost.AutoSize = true;
            lblSmtpHost.Location = new Point(6, 54);
            lblSmtpHost.Name = "lblSmtpHost";
            lblSmtpHost.Size = new Size(74, 15);
            lblSmtpHost.TabIndex = 2;
            lblSmtpHost.Text = "Nome server";
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(504, 453);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Annulla";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Location = new Point(585, 453);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 3;
            btnSave.Text = "Salva";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // gbxPdfGeneration
            // 
            gbxPdfGeneration.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbxPdfGeneration.Controls.Add(pnlConfigureSoffice);
            gbxPdfGeneration.Controls.Add(cbxPdfGenerationLocale);
            gbxPdfGeneration.Controls.Add(lblPdfGenerationLocale);
            gbxPdfGeneration.Controls.Add(cbxPdfQuality);
            gbxPdfGeneration.Controls.Add(lblPdfQuality);
            gbxPdfGeneration.Controls.Add(cbxPdfGenerationWith);
            gbxPdfGeneration.Controls.Add(lblPdfGenerationWith);
            gbxPdfGeneration.Location = new Point(12, 12);
            gbxPdfGeneration.Name = "gbxPdfGeneration";
            gbxPdfGeneration.Size = new Size(648, 160);
            gbxPdfGeneration.TabIndex = 0;
            gbxPdfGeneration.TabStop = false;
            gbxPdfGeneration.Text = "Generazione PDF";
            // 
            // pnlConfigureSoffice
            // 
            pnlConfigureSoffice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlConfigureSoffice.Controls.Add(lblPathSofficeCom);
            pnlConfigureSoffice.Controls.Add(tbxPathSofficeCom);
            pnlConfigureSoffice.Controls.Add(btnPathSofficeCom);
            pnlConfigureSoffice.Controls.Add(lnkPathSofficeCom);
            pnlConfigureSoffice.Location = new Point(6, 110);
            pnlConfigureSoffice.Margin = new Padding(0);
            pnlConfigureSoffice.Name = "pnlConfigureSoffice";
            pnlConfigureSoffice.Size = new Size(636, 38);
            pnlConfigureSoffice.TabIndex = 6;
            // 
            // lblPathSofficeCom
            // 
            lblPathSofficeCom.AutoSize = true;
            lblPathSofficeCom.Location = new Point(3, 4);
            lblPathSofficeCom.Name = "lblPathSofficeCom";
            lblPathSofficeCom.Size = new Size(127, 15);
            lblPathSofficeCom.TabIndex = 0;
            lblPathSofficeCom.Text = "Percorso di LibreOffice";
            // 
            // tbxPathSofficeCom
            // 
            tbxPathSofficeCom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbxPathSofficeCom.Location = new Point(136, 0);
            tbxPathSofficeCom.Name = "tbxPathSofficeCom";
            tbxPathSofficeCom.Size = new Size(398, 23);
            tbxPathSofficeCom.TabIndex = 1;
            // 
            // btnPathSofficeCom
            // 
            btnPathSofficeCom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPathSofficeCom.Location = new Point(540, 0);
            btnPathSofficeCom.Name = "btnPathSofficeCom";
            btnPathSofficeCom.Size = new Size(96, 23);
            btnPathSofficeCom.TabIndex = 2;
            btnPathSofficeCom.Text = "Sfoglia...";
            btnPathSofficeCom.UseVisualStyleBackColor = true;
            btnPathSofficeCom.Click += btnPathSofficeCom_Click;
            // 
            // lnkPathSofficeCom
            // 
            lnkPathSofficeCom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lnkPathSofficeCom.AutoSize = true;
            lnkPathSofficeCom.Location = new Point(490, 24);
            lnkPathSofficeCom.Name = "lnkPathSofficeCom";
            lnkPathSofficeCom.Size = new Size(44, 15);
            lnkPathSofficeCom.TabIndex = 3;
            lnkPathSofficeCom.TabStop = true;
            lnkPathSofficeCom.Text = "Scarica";
            lnkPathSofficeCom.TextAlign = ContentAlignment.TopRight;
            lnkPathSofficeCom.LinkClicked += lnkPathSofficeCom_LinkClicked;
            // 
            // cbxPdfGenerationLocale
            // 
            cbxPdfGenerationLocale.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbxPdfGenerationLocale.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbxPdfGenerationLocale.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbxPdfGenerationLocale.FormattingEnabled = true;
            cbxPdfGenerationLocale.Location = new Point(141, 22);
            cbxPdfGenerationLocale.Name = "cbxPdfGenerationLocale";
            cbxPdfGenerationLocale.Size = new Size(399, 23);
            cbxPdfGenerationLocale.TabIndex = 1;
            // 
            // lblPdfGenerationLocale
            // 
            lblPdfGenerationLocale.AutoSize = true;
            lblPdfGenerationLocale.Location = new Point(6, 25);
            lblPdfGenerationLocale.Name = "lblPdfGenerationLocale";
            lblPdfGenerationLocale.Size = new Size(90, 15);
            lblPdfGenerationLocale.TabIndex = 0;
            lblPdfGenerationLocale.Text = "Lingua da usare";
            // 
            // cbxPdfGenerationWith
            // 
            cbxPdfGenerationWith.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbxPdfGenerationWith.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxPdfGenerationWith.FormattingEnabled = true;
            cbxPdfGenerationWith.Location = new Point(141, 51);
            cbxPdfGenerationWith.Name = "cbxPdfGenerationWith";
            cbxPdfGenerationWith.Size = new Size(399, 23);
            cbxPdfGenerationWith.TabIndex = 3;
            cbxPdfGenerationWith.SelectedIndexChanged += cbxPdfGenerationWith_SelectedIndexChanged;
            // 
            // lblPdfGenerationWith
            // 
            lblPdfGenerationWith.AutoSize = true;
            lblPdfGenerationWith.Location = new Point(6, 54);
            lblPdfGenerationWith.Name = "lblPdfGenerationWith";
            lblPdfGenerationWith.Size = new Size(91, 15);
            lblPdfGenerationWith.TabIndex = 2;
            lblPdfGenerationWith.Text = "Genera PDF con";
            // 
            // ofdPathSofficeCom
            // 
            ofdPathSofficeCom.DefaultExt = "com";
            ofdPathSofficeCom.Filter = "Programma LibreOffice|soffice.com|Programmi|*.com;*.exe|Tutti i file|*.*\"";
            ofdPathSofficeCom.Title = "Posizione del programma LibreOffice";
            // 
            // lblPdfQuality
            // 
            lblPdfQuality.AutoSize = true;
            lblPdfQuality.Location = new Point(6, 83);
            lblPdfQuality.Name = "lblPdfQuality";
            lblPdfQuality.Size = new Size(69, 15);
            lblPdfQuality.TabIndex = 4;
            lblPdfQuality.Text = "Qualità PDF";
            // 
            // cbxPdfQuality
            // 
            cbxPdfQuality.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbxPdfQuality.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxPdfQuality.FormattingEnabled = true;
            cbxPdfQuality.Location = new Point(141, 80);
            cbxPdfQuality.Name = "cbxPdfQuality";
            cbxPdfQuality.Size = new Size(399, 23);
            cbxPdfQuality.TabIndex = 5;
            cbxPdfQuality.SelectedIndexChanged += cbxPdfGenerationWith_SelectedIndexChanged;
            // 
            // frmOptions
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(672, 488);
            Controls.Add(gbxPdfGeneration);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(gbxSmtp);
            MaximizeBox = false;
            MaximumSize = new Size(1500, 600);
            MinimumSize = new Size(400, 490);
            Name = "frmOptions";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ADBMailer - Opzioni";
            gbxSmtp.ResumeLayout(false);
            gbxSmtp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSmtpPort).EndInit();
            gbxPdfGeneration.ResumeLayout(false);
            gbxPdfGeneration.PerformLayout();
            pnlConfigureSoffice.ResumeLayout(false);
            pnlConfigureSoffice.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbxSmtp;
        private TextBox tbxSmtpHost;
        private Label lblSmtpHost;
        private Label lblSmtpPort;
        private NumericUpDown nudSmtpPort;
        private Label lblSmtpSecurity;
        private ComboBox cbxSmtpSecurity;
        private ComboBox cbxSmtpAuth;
        private Label lblSmtpAuth;
        private TextBox tbxSmtpPassword;
        private TextBox tbxSmtpUsername;
        private Label lblSmtpPassword;
        private Label lblSmtpUsername;
        private TextBox tbxSmtpHelo;
        private Label lblSmtpHelo;
        private Button btnCancel;
        private Button btnSave;
        private LinkLabel lnkSmtpTest;
        private TextBox tbxSmtpDefaultSender;
        private Label lblSmtpDefaultSender;
        private GroupBox gbxPdfGeneration;
        private Label lblPathSofficeCom;
        private TextBox tbxPathSofficeCom;
        private Button btnPathSofficeCom;
        private OpenFileDialog ofdPathSofficeCom;
        private LinkLabel lnkPathSofficeCom;
        private Label lblPdfGenerationWith;
        private ComboBox cbxPdfGenerationWith;
        private ComboBox cbxPdfGenerationLocale;
        private Label lblPdfGenerationLocale;
        private CheckBox cbxCheckCertificateRevocation;
        private Panel pnlConfigureSoffice;
        private ComboBox cbxPdfQuality;
        private Label lblPdfQuality;
    }
}