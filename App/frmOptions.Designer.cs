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
            this.gbxSmtp = new System.Windows.Forms.GroupBox();
            this.tbxSmtpDefaultSender = new System.Windows.Forms.TextBox();
            this.lblSmtpDefaultSender = new System.Windows.Forms.Label();
            this.lnkSmtpTest = new System.Windows.Forms.LinkLabel();
            this.tbxSmtpHelo = new System.Windows.Forms.TextBox();
            this.lblSmtpHelo = new System.Windows.Forms.Label();
            this.tbxSmtpPassword = new System.Windows.Forms.TextBox();
            this.tbxSmtpUsername = new System.Windows.Forms.TextBox();
            this.lblSmtpPassword = new System.Windows.Forms.Label();
            this.lblSmtpUsername = new System.Windows.Forms.Label();
            this.cbxSmtpAuth = new System.Windows.Forms.ComboBox();
            this.lblSmtpAuth = new System.Windows.Forms.Label();
            this.cbxSmtpSecurity = new System.Windows.Forms.ComboBox();
            this.nudSmtpPort = new System.Windows.Forms.NumericUpDown();
            this.tbxSmtpHost = new System.Windows.Forms.TextBox();
            this.lblSmtpPort = new System.Windows.Forms.Label();
            this.lblSmtpSecurity = new System.Windows.Forms.Label();
            this.lblSmtpHost = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbxPdfGeneration = new System.Windows.Forms.GroupBox();
            this.cbxPdfGenerationLocale = new System.Windows.Forms.ComboBox();
            this.lblPdfGenerationLocale = new System.Windows.Forms.Label();
            this.cbxPdfGenerationWith = new System.Windows.Forms.ComboBox();
            this.lblPdfGenerationWith = new System.Windows.Forms.Label();
            this.lnkPathSofficeCom = new System.Windows.Forms.LinkLabel();
            this.btnPathSofficeCom = new System.Windows.Forms.Button();
            this.tbxPathSofficeCom = new System.Windows.Forms.TextBox();
            this.lblPathSofficeCom = new System.Windows.Forms.Label();
            this.ofdPathSofficeCom = new System.Windows.Forms.OpenFileDialog();
            this.gbxSmtp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSmtpPort)).BeginInit();
            this.gbxPdfGeneration.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxSmtp
            // 
            this.gbxSmtp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxSmtp.Controls.Add(this.tbxSmtpDefaultSender);
            this.gbxSmtp.Controls.Add(this.lblSmtpDefaultSender);
            this.gbxSmtp.Controls.Add(this.lnkSmtpTest);
            this.gbxSmtp.Controls.Add(this.tbxSmtpHelo);
            this.gbxSmtp.Controls.Add(this.lblSmtpHelo);
            this.gbxSmtp.Controls.Add(this.tbxSmtpPassword);
            this.gbxSmtp.Controls.Add(this.tbxSmtpUsername);
            this.gbxSmtp.Controls.Add(this.lblSmtpPassword);
            this.gbxSmtp.Controls.Add(this.lblSmtpUsername);
            this.gbxSmtp.Controls.Add(this.cbxSmtpAuth);
            this.gbxSmtp.Controls.Add(this.lblSmtpAuth);
            this.gbxSmtp.Controls.Add(this.cbxSmtpSecurity);
            this.gbxSmtp.Controls.Add(this.nudSmtpPort);
            this.gbxSmtp.Controls.Add(this.tbxSmtpHost);
            this.gbxSmtp.Controls.Add(this.lblSmtpPort);
            this.gbxSmtp.Controls.Add(this.lblSmtpSecurity);
            this.gbxSmtp.Controls.Add(this.lblSmtpHost);
            this.gbxSmtp.Location = new System.Drawing.Point(12, 140);
            this.gbxSmtp.Name = "gbxSmtp";
            this.gbxSmtp.Size = new System.Drawing.Size(562, 260);
            this.gbxSmtp.TabIndex = 1;
            this.gbxSmtp.TabStop = false;
            this.gbxSmtp.Text = "Server invio email";
            // 
            // tbxSmtpDefaultSender
            // 
            this.tbxSmtpDefaultSender.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxSmtpDefaultSender.Location = new System.Drawing.Point(141, 22);
            this.tbxSmtpDefaultSender.Name = "tbxSmtpDefaultSender";
            this.tbxSmtpDefaultSender.PlaceholderText = "IndirizzoEmail oppure Nome <IndirizzoEmail>";
            this.tbxSmtpDefaultSender.Size = new System.Drawing.Size(313, 23);
            this.tbxSmtpDefaultSender.TabIndex = 1;
            // 
            // lblSmtpDefaultSender
            // 
            this.lblSmtpDefaultSender.AutoSize = true;
            this.lblSmtpDefaultSender.Location = new System.Drawing.Point(6, 25);
            this.lblSmtpDefaultSender.Name = "lblSmtpDefaultSender";
            this.lblSmtpDefaultSender.Size = new System.Drawing.Size(113, 15);
            this.lblSmtpDefaultSender.TabIndex = 0;
            this.lblSmtpDefaultSender.Text = "Mittente predefinito";
            // 
            // lnkSmtpTest
            // 
            this.lnkSmtpTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkSmtpTest.AutoSize = true;
            this.lnkSmtpTest.Location = new System.Drawing.Point(446, 241);
            this.lnkSmtpTest.Name = "lnkSmtpTest";
            this.lnkSmtpTest.Size = new System.Drawing.Size(110, 15);
            this.lnkSmtpTest.TabIndex = 16;
            this.lnkSmtpTest.TabStop = true;
            this.lnkSmtpTest.Text = "Invia email di prova";
            this.lnkSmtpTest.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSmtpTest_LinkClicked);
            // 
            // tbxSmtpHelo
            // 
            this.tbxSmtpHelo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxSmtpHelo.Location = new System.Drawing.Point(141, 196);
            this.tbxSmtpHelo.Name = "tbxSmtpHelo";
            this.tbxSmtpHelo.Size = new System.Drawing.Size(313, 23);
            this.tbxSmtpHelo.TabIndex = 15;
            // 
            // lblSmtpHelo
            // 
            this.lblSmtpHelo.AutoSize = true;
            this.lblSmtpHelo.Location = new System.Drawing.Point(6, 202);
            this.lblSmtpHelo.Name = "lblSmtpHelo";
            this.lblSmtpHelo.Size = new System.Drawing.Size(121, 15);
            this.lblSmtpHelo.TabIndex = 14;
            this.lblSmtpHelo.Text = "Dominio HELO/EHLO";
            // 
            // tbxSmtpPassword
            // 
            this.tbxSmtpPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxSmtpPassword.Location = new System.Drawing.Point(141, 167);
            this.tbxSmtpPassword.Name = "tbxSmtpPassword";
            this.tbxSmtpPassword.PasswordChar = '*';
            this.tbxSmtpPassword.Size = new System.Drawing.Size(313, 23);
            this.tbxSmtpPassword.TabIndex = 13;
            // 
            // tbxSmtpUsername
            // 
            this.tbxSmtpUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxSmtpUsername.Location = new System.Drawing.Point(141, 138);
            this.tbxSmtpUsername.Name = "tbxSmtpUsername";
            this.tbxSmtpUsername.Size = new System.Drawing.Size(313, 23);
            this.tbxSmtpUsername.TabIndex = 11;
            // 
            // lblSmtpPassword
            // 
            this.lblSmtpPassword.AutoSize = true;
            this.lblSmtpPassword.Location = new System.Drawing.Point(6, 170);
            this.lblSmtpPassword.Name = "lblSmtpPassword";
            this.lblSmtpPassword.Size = new System.Drawing.Size(57, 15);
            this.lblSmtpPassword.TabIndex = 12;
            this.lblSmtpPassword.Text = "Password";
            // 
            // lblSmtpUsername
            // 
            this.lblSmtpUsername.AutoSize = true;
            this.lblSmtpUsername.Location = new System.Drawing.Point(6, 141);
            this.lblSmtpUsername.Name = "lblSmtpUsername";
            this.lblSmtpUsername.Size = new System.Drawing.Size(77, 15);
            this.lblSmtpUsername.TabIndex = 10;
            this.lblSmtpUsername.Text = "Nome utente";
            // 
            // cbxSmtpAuth
            // 
            this.cbxSmtpAuth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxSmtpAuth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSmtpAuth.FormattingEnabled = true;
            this.cbxSmtpAuth.Location = new System.Drawing.Point(141, 109);
            this.cbxSmtpAuth.Name = "cbxSmtpAuth";
            this.cbxSmtpAuth.Size = new System.Drawing.Size(313, 23);
            this.cbxSmtpAuth.TabIndex = 9;
            this.cbxSmtpAuth.SelectedIndexChanged += new System.EventHandler(this.cbxSmtpAuth_SelectedIndexChanged);
            // 
            // lblSmtpAuth
            // 
            this.lblSmtpAuth.AutoSize = true;
            this.lblSmtpAuth.Location = new System.Drawing.Point(6, 112);
            this.lblSmtpAuth.Name = "lblSmtpAuth";
            this.lblSmtpAuth.Size = new System.Drawing.Size(129, 15);
            this.lblSmtpAuth.TabIndex = 8;
            this.lblSmtpAuth.Text = "Metodo autenticazione";
            // 
            // cbxSmtpSecurity
            // 
            this.cbxSmtpSecurity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxSmtpSecurity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSmtpSecurity.FormattingEnabled = true;
            this.cbxSmtpSecurity.Location = new System.Drawing.Point(141, 80);
            this.cbxSmtpSecurity.Name = "cbxSmtpSecurity";
            this.cbxSmtpSecurity.Size = new System.Drawing.Size(313, 23);
            this.cbxSmtpSecurity.TabIndex = 7;
            // 
            // nudSmtpPort
            // 
            this.nudSmtpPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudSmtpPort.Location = new System.Drawing.Point(501, 51);
            this.nudSmtpPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudSmtpPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSmtpPort.Name = "nudSmtpPort";
            this.nudSmtpPort.Size = new System.Drawing.Size(55, 23);
            this.nudSmtpPort.TabIndex = 5;
            this.nudSmtpPort.Value = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            // 
            // tbxSmtpHost
            // 
            this.tbxSmtpHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxSmtpHost.Location = new System.Drawing.Point(141, 51);
            this.tbxSmtpHost.Name = "tbxSmtpHost";
            this.tbxSmtpHost.Size = new System.Drawing.Size(313, 23);
            this.tbxSmtpHost.TabIndex = 3;
            // 
            // lblSmtpPort
            // 
            this.lblSmtpPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSmtpPort.AutoSize = true;
            this.lblSmtpPort.Location = new System.Drawing.Point(460, 54);
            this.lblSmtpPort.Name = "lblSmtpPort";
            this.lblSmtpPort.Size = new System.Drawing.Size(35, 15);
            this.lblSmtpPort.TabIndex = 4;
            this.lblSmtpPort.Text = "Porta";
            // 
            // lblSmtpSecurity
            // 
            this.lblSmtpSecurity.AutoSize = true;
            this.lblSmtpSecurity.Location = new System.Drawing.Point(6, 83);
            this.lblSmtpSecurity.Name = "lblSmtpSecurity";
            this.lblSmtpSecurity.Size = new System.Drawing.Size(124, 15);
            this.lblSmtpSecurity.TabIndex = 6;
            this.lblSmtpSecurity.Text = "Sicurezza connessione";
            // 
            // lblSmtpHost
            // 
            this.lblSmtpHost.AutoSize = true;
            this.lblSmtpHost.Location = new System.Drawing.Point(6, 54);
            this.lblSmtpHost.Name = "lblSmtpHost";
            this.lblSmtpHost.Size = new System.Drawing.Size(74, 15);
            this.lblSmtpHost.TabIndex = 2;
            this.lblSmtpHost.Text = "Nome server";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(418, 406);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Annulla";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(499, 406);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Salva";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbxPdfGeneration
            // 
            this.gbxPdfGeneration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxPdfGeneration.Controls.Add(this.cbxPdfGenerationLocale);
            this.gbxPdfGeneration.Controls.Add(this.lblPdfGenerationLocale);
            this.gbxPdfGeneration.Controls.Add(this.cbxPdfGenerationWith);
            this.gbxPdfGeneration.Controls.Add(this.lblPdfGenerationWith);
            this.gbxPdfGeneration.Controls.Add(this.lnkPathSofficeCom);
            this.gbxPdfGeneration.Controls.Add(this.btnPathSofficeCom);
            this.gbxPdfGeneration.Controls.Add(this.tbxPathSofficeCom);
            this.gbxPdfGeneration.Controls.Add(this.lblPathSofficeCom);
            this.gbxPdfGeneration.Location = new System.Drawing.Point(12, 12);
            this.gbxPdfGeneration.Name = "gbxPdfGeneration";
            this.gbxPdfGeneration.Size = new System.Drawing.Size(562, 122);
            this.gbxPdfGeneration.TabIndex = 0;
            this.gbxPdfGeneration.TabStop = false;
            this.gbxPdfGeneration.Text = "Generazione PDF";
            // 
            // cbxPdfGenerationLocale
            // 
            this.cbxPdfGenerationLocale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxPdfGenerationLocale.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxPdfGenerationLocale.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxPdfGenerationLocale.FormattingEnabled = true;
            this.cbxPdfGenerationLocale.Location = new System.Drawing.Point(141, 22);
            this.cbxPdfGenerationLocale.Name = "cbxPdfGenerationLocale";
            this.cbxPdfGenerationLocale.Size = new System.Drawing.Size(313, 23);
            this.cbxPdfGenerationLocale.TabIndex = 1;
            // 
            // lblPdfGenerationLocale
            // 
            this.lblPdfGenerationLocale.AutoSize = true;
            this.lblPdfGenerationLocale.Location = new System.Drawing.Point(6, 25);
            this.lblPdfGenerationLocale.Name = "lblPdfGenerationLocale";
            this.lblPdfGenerationLocale.Size = new System.Drawing.Size(90, 15);
            this.lblPdfGenerationLocale.TabIndex = 0;
            this.lblPdfGenerationLocale.Text = "Lingua da usare";
            // 
            // cbxPdfGenerationWith
            // 
            this.cbxPdfGenerationWith.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxPdfGenerationWith.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPdfGenerationWith.FormattingEnabled = true;
            this.cbxPdfGenerationWith.Location = new System.Drawing.Point(141, 51);
            this.cbxPdfGenerationWith.Name = "cbxPdfGenerationWith";
            this.cbxPdfGenerationWith.Size = new System.Drawing.Size(313, 23);
            this.cbxPdfGenerationWith.TabIndex = 3;
            this.cbxPdfGenerationWith.SelectedIndexChanged += new System.EventHandler(this.cbxPdfGenerationWith_SelectedIndexChanged);
            // 
            // lblPdfGenerationWith
            // 
            this.lblPdfGenerationWith.AutoSize = true;
            this.lblPdfGenerationWith.Location = new System.Drawing.Point(6, 54);
            this.lblPdfGenerationWith.Name = "lblPdfGenerationWith";
            this.lblPdfGenerationWith.Size = new System.Drawing.Size(91, 15);
            this.lblPdfGenerationWith.TabIndex = 2;
            this.lblPdfGenerationWith.Text = "Genera PDF con";
            // 
            // lnkPathSofficeCom
            // 
            this.lnkPathSofficeCom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkPathSofficeCom.AutoSize = true;
            this.lnkPathSofficeCom.Location = new System.Drawing.Point(410, 104);
            this.lnkPathSofficeCom.Name = "lnkPathSofficeCom";
            this.lnkPathSofficeCom.Size = new System.Drawing.Size(44, 15);
            this.lnkPathSofficeCom.TabIndex = 7;
            this.lnkPathSofficeCom.TabStop = true;
            this.lnkPathSofficeCom.Text = "Scarica";
            this.lnkPathSofficeCom.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lnkPathSofficeCom.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPathSofficeCom_LinkClicked);
            // 
            // btnPathSofficeCom
            // 
            this.btnPathSofficeCom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPathSofficeCom.Location = new System.Drawing.Point(460, 80);
            this.btnPathSofficeCom.Name = "btnPathSofficeCom";
            this.btnPathSofficeCom.Size = new System.Drawing.Size(96, 23);
            this.btnPathSofficeCom.TabIndex = 6;
            this.btnPathSofficeCom.Text = "Sfoglia...";
            this.btnPathSofficeCom.UseVisualStyleBackColor = true;
            this.btnPathSofficeCom.Click += new System.EventHandler(this.btnPathSofficeCom_Click);
            // 
            // tbxPathSofficeCom
            // 
            this.tbxPathSofficeCom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxPathSofficeCom.Location = new System.Drawing.Point(141, 80);
            this.tbxPathSofficeCom.Name = "tbxPathSofficeCom";
            this.tbxPathSofficeCom.Size = new System.Drawing.Size(313, 23);
            this.tbxPathSofficeCom.TabIndex = 5;
            // 
            // lblPathSofficeCom
            // 
            this.lblPathSofficeCom.AutoSize = true;
            this.lblPathSofficeCom.Location = new System.Drawing.Point(8, 84);
            this.lblPathSofficeCom.Name = "lblPathSofficeCom";
            this.lblPathSofficeCom.Size = new System.Drawing.Size(127, 15);
            this.lblPathSofficeCom.TabIndex = 4;
            this.lblPathSofficeCom.Text = "Percorso di LibreOffice";
            // 
            // ofdPathSofficeCom
            // 
            this.ofdPathSofficeCom.DefaultExt = "com";
            this.ofdPathSofficeCom.Filter = "Programma LibreOffice|soffice.com|Programmi|*.com;*.exe|Tutti i file|*.*\"";
            this.ofdPathSofficeCom.Title = "Posizione del programma LibreOffice";
            // 
            // frmOptions
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(586, 441);
            this.Controls.Add(this.gbxPdfGeneration);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbxSmtp);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1500, 600);
            this.MinimumSize = new System.Drawing.Size(400, 480);
            this.Name = "frmOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ADBMailer - Opzioni";
            this.gbxSmtp.ResumeLayout(false);
            this.gbxSmtp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSmtpPort)).EndInit();
            this.gbxPdfGeneration.ResumeLayout(false);
            this.gbxPdfGeneration.PerformLayout();
            this.ResumeLayout(false);

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
    }
}