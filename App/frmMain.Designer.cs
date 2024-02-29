namespace ADBMailer
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            btnExcel = new Button();
            btnWord = new Button();
            ofdExcel = new OpenFileDialog();
            ofdWord = new OpenFileDialog();
            ttTip = new ToolTip(components);
            tableLayoutPanel3 = new TableLayoutPanel();
            tbxWord = new TextBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            tbxExcel = new TextBox();
            lblBody = new Label();
            lblSubject = new Label();
            lblSender = new Label();
            label1 = new Label();
            label2 = new Label();
            tbxEmailBody = new TextBox();
            tbxEmailSubject = new TextBox();
            tbxEmailFrom = new TextBox();
            tmrUpdateDocs = new System.Windows.Forms.Timer(components);
            tsMainMenu = new CustomControls.ToolStrip();
            tsbMapFields = new ToolStripButton();
            tssSep0 = new ToolStripSeparator();
            tsbSavePdfTest = new ToolStripButton();
            tsbEmailTest = new ToolStripButton();
            tssSep1 = new ToolStripSeparator();
            tsbSavePdf = new ToolStripButton();
            tsbEmailSend = new ToolStripButton();
            tssSep2 = new ToolStripSeparator();
            tsbOptions = new ToolStripButton();
            tssSep3 = new ToolStripSeparator();
            tsbHelp = new ToolStripButton();
            tsbAutoupdate = new ToolStripButton();
            lblEmailCC = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            tbxEmailCC = new TextBox();
            cbxMailSenderInCc = new CheckBox();
            lblEmailBCC = new Label();
            tableLayoutPanel4 = new TableLayoutPanel();
            tbxEmailBCC = new TextBox();
            cbxMailSenderInBcc = new CheckBox();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tsMainMenu.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            SuspendLayout();
            // 
            // btnExcel
            // 
            btnExcel.Location = new Point(512, 3);
            btnExcel.Name = "btnExcel";
            btnExcel.Size = new Size(75, 23);
            btnExcel.TabIndex = 1;
            btnExcel.Text = "Sfoglia...";
            btnExcel.UseVisualStyleBackColor = true;
            btnExcel.Click += btnExcel_Click;
            // 
            // btnWord
            // 
            btnWord.Location = new Point(512, 3);
            btnWord.Name = "btnWord";
            btnWord.Size = new Size(75, 23);
            btnWord.TabIndex = 1;
            btnWord.Text = "Sfoglia...";
            btnWord.UseVisualStyleBackColor = true;
            btnWord.Click += btnWord_Click;
            // 
            // ofdExcel
            // 
            ofdExcel.DefaultExt = "xlsx";
            ofdExcel.Filter = "Fogli di Excel|*.xlsx;*.xlsm|Tutti i file|*.*";
            ofdExcel.Title = "Apri foglio di Excel";
            // 
            // ofdWord
            // 
            ofdWord.DefaultExt = "docx";
            ofdWord.Filter = "Documenti di Word|*.docx;*.docm|Tutti i file|*.*";
            ofdWord.Title = "Apri documento di Word";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.Controls.Add(btnWord, 1, 0);
            tableLayoutPanel3.Controls.Add(tbxWord, 0, 0);
            tableLayoutPanel3.Location = new Point(133, 125);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(590, 29);
            tableLayoutPanel3.TabIndex = 4;
            // 
            // tbxWord
            // 
            tbxWord.Dock = DockStyle.Fill;
            tbxWord.Location = new Point(3, 3);
            tbxWord.Name = "tbxWord";
            tbxWord.PlaceholderText = "Seleziona un documento di Word o trascinalo in questa finestra";
            tbxWord.ReadOnly = true;
            tbxWord.Size = new Size(503, 23);
            tbxWord.TabIndex = 0;
            tbxWord.Resize += tbxWord_Resize;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.Controls.Add(tbxExcel, 0, 0);
            tableLayoutPanel2.Controls.Add(btnExcel, 1, 0);
            tableLayoutPanel2.Location = new Point(133, 90);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(590, 29);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // tbxExcel
            // 
            tbxExcel.Dock = DockStyle.Fill;
            tbxExcel.Location = new Point(3, 3);
            tbxExcel.Name = "tbxExcel";
            tbxExcel.PlaceholderText = "Seleziona un foglio di Excel o trascinalo in questa finestra";
            tbxExcel.ReadOnly = true;
            tbxExcel.Size = new Size(503, 23);
            tbxExcel.TabIndex = 0;
            tbxExcel.Resize += tbxExcel_Resize;
            // 
            // lblBody
            // 
            lblBody.AutoSize = true;
            lblBody.Location = new Point(12, 283);
            lblBody.Name = "lblBody";
            lblBody.Padding = new Padding(0, 10, 0, 0);
            lblBody.Size = new Size(40, 25);
            lblBody.TabIndex = 13;
            lblBody.Text = "Corpo";
            // 
            // lblSubject
            // 
            lblSubject.AutoSize = true;
            lblSubject.Location = new Point(12, 259);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(51, 15);
            lblSubject.TabIndex = 11;
            lblSubject.Text = "Oggetto";
            // 
            // lblSender
            // 
            lblSender.AutoSize = true;
            lblSender.Location = new Point(12, 160);
            lblSender.Name = "lblSender";
            lblSender.Size = new Size(52, 15);
            lblSender.TabIndex = 5;
            lblSender.Text = "Mittente";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 97);
            label1.Name = "label1";
            label1.Size = new Size(83, 15);
            label1.TabIndex = 1;
            label1.Text = "Foglio di Excel";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 132);
            label2.Name = "label2";
            label2.Size = new Size(115, 15);
            label2.TabIndex = 3;
            label2.Text = "Documento di Word";
            // 
            // tbxEmailBody
            // 
            tbxEmailBody.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbxEmailBody.Font = new Font("Courier New", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            tbxEmailBody.Location = new Point(133, 285);
            tbxEmailBody.Multiline = true;
            tbxEmailBody.Name = "tbxEmailBody";
            tbxEmailBody.ScrollBars = ScrollBars.Both;
            tbxEmailBody.Size = new Size(590, 225);
            tbxEmailBody.TabIndex = 14;
            // 
            // tbxEmailSubject
            // 
            tbxEmailSubject.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbxEmailSubject.Location = new Point(133, 256);
            tbxEmailSubject.Name = "tbxEmailSubject";
            tbxEmailSubject.Size = new Size(590, 23);
            tbxEmailSubject.TabIndex = 12;
            // 
            // tbxEmailFrom
            // 
            tbxEmailFrom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbxEmailFrom.Location = new Point(133, 157);
            tbxEmailFrom.Name = "tbxEmailFrom";
            tbxEmailFrom.PlaceholderText = "IndirizzoEmail oppure Nome <IndirizzoEmail>";
            tbxEmailFrom.Size = new Size(590, 23);
            tbxEmailFrom.TabIndex = 6;
            // 
            // tmrUpdateDocs
            // 
            tmrUpdateDocs.Interval = 10;
            tmrUpdateDocs.Tick += tmrUpdateDocs_Tick;
            // 
            // tsMainMenu
            // 
            tsMainMenu.GripStyle = ToolStripGripStyle.Hidden;
            tsMainMenu.Items.AddRange(new ToolStripItem[] { tsbMapFields, tssSep0, tsbSavePdfTest, tsbEmailTest, tssSep1, tsbSavePdf, tsbEmailSend, tssSep2, tsbOptions, tssSep3, tsbHelp, tsbAutoupdate });
            tsMainMenu.Location = new Point(0, 0);
            tsMainMenu.Name = "tsMainMenu";
            tsMainMenu.Size = new Size(735, 70);
            tsMainMenu.TabIndex = 0;
            tsMainMenu.Text = "Menu principale";
            // 
            // tsbMapFields
            // 
            tsbMapFields.Image = (Image)resources.GetObject("tsbMapFields.Image");
            tsbMapFields.ImageScaling = ToolStripItemImageScaling.None;
            tsbMapFields.ImageTransparentColor = Color.Magenta;
            tsbMapFields.Margin = new Padding(10, 1, 0, 2);
            tsbMapFields.Name = "tsbMapFields";
            tsbMapFields.Size = new Size(84, 67);
            tsbMapFields.Text = "Mappa campi";
            tsbMapFields.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbMapFields.Click += tsbMapFields_Click;
            // 
            // tssSep0
            // 
            tssSep0.Name = "tssSep0";
            tssSep0.Size = new Size(6, 70);
            // 
            // tsbSavePdfTest
            // 
            tsbSavePdfTest.Image = (Image)resources.GetObject("tsbSavePdfTest.Image");
            tsbSavePdfTest.ImageScaling = ToolStripItemImageScaling.None;
            tsbSavePdfTest.ImageTransparentColor = Color.Magenta;
            tsbSavePdfTest.Name = "tsbSavePdfTest";
            tsbSavePdfTest.Size = new Size(87, 67);
            tsbSavePdfTest.Text = "Vedi PDF (test)";
            tsbSavePdfTest.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbSavePdfTest.Click += tsbSavePdfTest_Click;
            // 
            // tsbEmailTest
            // 
            tsbEmailTest.Image = (Image)resources.GetObject("tsbEmailTest.Image");
            tsbEmailTest.ImageScaling = ToolStripItemImageScaling.None;
            tsbEmailTest.ImageTransparentColor = Color.Magenta;
            tsbEmailTest.Name = "tsbEmailTest";
            tsbEmailTest.Size = new Size(98, 67);
            tsbEmailTest.Text = "Invia email (test)";
            tsbEmailTest.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbEmailTest.Click += tsbEmailTest_Click;
            // 
            // tssSep1
            // 
            tssSep1.Name = "tssSep1";
            tssSep1.Size = new Size(6, 70);
            // 
            // tsbSavePdf
            // 
            tsbSavePdf.Image = (Image)resources.GetObject("tsbSavePdf.Image");
            tsbSavePdf.ImageScaling = ToolStripItemImageScaling.None;
            tsbSavePdf.ImageTransparentColor = Color.Magenta;
            tsbSavePdf.Name = "tsbSavePdf";
            tsbSavePdf.Size = new Size(62, 67);
            tsbSavePdf.Text = "Salva PDF";
            tsbSavePdf.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbSavePdf.Click += tsbSavePdf_Click;
            // 
            // tsbEmailSend
            // 
            tsbEmailSend.Image = (Image)resources.GetObject("tsbEmailSend.Image");
            tsbEmailSend.ImageScaling = ToolStripItemImageScaling.None;
            tsbEmailSend.ImageTransparentColor = Color.Magenta;
            tsbEmailSend.Name = "tsbEmailSend";
            tsbEmailSend.Size = new Size(68, 67);
            tsbEmailSend.Text = "Invia email";
            tsbEmailSend.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbEmailSend.Click += tsbEmailSend_Click;
            // 
            // tssSep2
            // 
            tssSep2.Name = "tssSep2";
            tssSep2.Size = new Size(6, 70);
            // 
            // tsbOptions
            // 
            tsbOptions.Image = (Image)resources.GetObject("tsbOptions.Image");
            tsbOptions.ImageScaling = ToolStripItemImageScaling.None;
            tsbOptions.ImageTransparentColor = Color.Magenta;
            tsbOptions.Margin = new Padding(7, 1, 0, 2);
            tsbOptions.Name = "tsbOptions";
            tsbOptions.Size = new Size(52, 67);
            tsbOptions.Text = "Opzioni";
            tsbOptions.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbOptions.ToolTipText = "Opzioni (F4)";
            tsbOptions.Click += tsbOptions_Click;
            // 
            // tssSep3
            // 
            tssSep3.Name = "tssSep3";
            tssSep3.Size = new Size(6, 70);
            // 
            // tsbHelp
            // 
            tsbHelp.Image = (Image)resources.GetObject("tsbHelp.Image");
            tsbHelp.ImageScaling = ToolStripItemImageScaling.None;
            tsbHelp.ImageTransparentColor = Color.Magenta;
            tsbHelp.Name = "tsbHelp";
            tsbHelp.Size = new Size(52, 67);
            tsbHelp.Text = "Guida";
            tsbHelp.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbHelp.ToolTipText = "Guida (F1)";
            tsbHelp.Click += tsbHelp_Click;
            // 
            // tsbAutoupdate
            // 
            tsbAutoupdate.Image = (Image)resources.GetObject("tsbAutoupdate.Image");
            tsbAutoupdate.ImageScaling = ToolStripItemImageScaling.None;
            tsbAutoupdate.ImageTransparentColor = Color.Magenta;
            tsbAutoupdate.Name = "tsbAutoupdate";
            tsbAutoupdate.Size = new Size(83, 67);
            tsbAutoupdate.Text = "Aggiorna app";
            tsbAutoupdate.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbAutoupdate.Click += tsbAutoupdate_Click;
            // 
            // lblEmailCC
            // 
            lblEmailCC.AutoSize = true;
            lblEmailCC.Location = new Point(12, 191);
            lblEmailCC.Name = "lblEmailCC";
            lblEmailCC.Size = new Size(95, 15);
            lblEmailCC.TabIndex = 7;
            lblEmailCC.Text = "Destinatari in CC";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(tbxEmailCC, 0, 0);
            tableLayoutPanel1.Controls.Add(cbxMailSenderInCc, 1, 0);
            tableLayoutPanel1.Location = new Point(133, 186);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(590, 29);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // tbxEmailCC
            // 
            tbxEmailCC.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbxEmailCC.Location = new Point(3, 3);
            tbxEmailCC.Name = "tbxEmailCC";
            tbxEmailCC.PlaceholderText = "IndirizzoEmail oppure Nome <IndirizzoEmail> (separa più indirizzi con virgole)";
            tbxEmailCC.Size = new Size(457, 23);
            tbxEmailCC.TabIndex = 0;
            // 
            // cbxMailSenderInCc
            // 
            cbxMailSenderInCc.AutoSize = true;
            cbxMailSenderInCc.Location = new Point(466, 3);
            cbxMailSenderInCc.Name = "cbxMailSenderInCc";
            cbxMailSenderInCc.Padding = new Padding(0, 2, 0, 0);
            cbxMailSenderInCc.Size = new Size(121, 21);
            cbxMailSenderInCc.TabIndex = 1;
            cbxMailSenderInCc.Text = "aggiungi mittente";
            cbxMailSenderInCc.UseVisualStyleBackColor = true;
            // 
            // lblEmailBCC
            // 
            lblEmailBCC.AutoSize = true;
            lblEmailBCC.Location = new Point(12, 226);
            lblEmailBCC.Name = "lblEmailBCC";
            lblEmailBCC.Size = new Size(104, 15);
            lblEmailBCC.TabIndex = 9;
            lblEmailBCC.Text = "Destinatari in CCN";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel4.Controls.Add(tbxEmailBCC, 0, 0);
            tableLayoutPanel4.Controls.Add(cbxMailSenderInBcc, 1, 0);
            tableLayoutPanel4.Location = new Point(133, 221);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(590, 29);
            tableLayoutPanel4.TabIndex = 10;
            // 
            // tbxEmailBCC
            // 
            tbxEmailBCC.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbxEmailBCC.Location = new Point(3, 3);
            tbxEmailBCC.Name = "tbxEmailBCC";
            tbxEmailBCC.PlaceholderText = "IndirizzoEmail oppure Nome <IndirizzoEmail> (separa più indirizzi con virgole)";
            tbxEmailBCC.Size = new Size(457, 23);
            tbxEmailBCC.TabIndex = 0;
            // 
            // cbxMailSenderInBcc
            // 
            cbxMailSenderInBcc.AutoSize = true;
            cbxMailSenderInBcc.Location = new Point(466, 3);
            cbxMailSenderInBcc.Name = "cbxMailSenderInBcc";
            cbxMailSenderInBcc.Padding = new Padding(0, 2, 0, 0);
            cbxMailSenderInBcc.Size = new Size(121, 21);
            cbxMailSenderInBcc.TabIndex = 1;
            cbxMailSenderInBcc.Text = "aggiungi mittente";
            cbxMailSenderInBcc.UseVisualStyleBackColor = true;
            cbxMailSenderInBcc.CheckedChanged += cbxMailSenderInBcc_CheckedChanged;
            // 
            // frmMain
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(735, 522);
            Controls.Add(tbxEmailBody);
            Controls.Add(lblBody);
            Controls.Add(tableLayoutPanel3);
            Controls.Add(lblSubject);
            Controls.Add(tbxEmailSubject);
            Controls.Add(tsMainMenu);
            Controls.Add(lblEmailBCC);
            Controls.Add(lblEmailCC);
            Controls.Add(lblSender);
            Controls.Add(tableLayoutPanel4);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tbxEmailFrom);
            Controls.Add(label1);
            Controls.Add(label2);
            KeyPreview = true;
            MinimumSize = new Size(570, 320);
            Name = "frmMain";
            Text = "ADBMailer";
            DragDrop += frmMain_DragDrop;
            DragOver += frmMain_DragOver;
            KeyUp += frmMain_KeyUp;
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tsMainMenu.ResumeLayout(false);
            tsMainMenu.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnExcel;
        private Button btnWord;
        private OpenFileDialog ofdExcel;
        private OpenFileDialog ofdWord;
        private ToolTip ttTip;
        private TextBox tbxEmailSubject;
        private TextBox tbxEmailBody;
        private Label lblSubject;
        private Label lblBody;
        private Label lblSender;
        private TextBox tbxEmailFrom;
        private System.Windows.Forms.Timer tmrUpdateDocs;
        private Label label1;
        private Label label2;
        private TextBox tbxExcel;
        private TextBox tbxWord;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private ADBMailer.CustomControls.ToolStrip tsMainMenu;
        private ToolStripButton tsbMapFields;
        private ToolStripButton tsbOptions;
        private ToolStripSeparator tssSep0;
        private ToolStripSeparator tssSep1;
        private ToolStripSeparator tssSep2;
        private ToolStripButton tsbEmailTest;
        private ToolStripButton tsbSavePdf;
        private ToolStripButton tsbEmailSend;
        private ToolStripButton tsbSavePdfTest;
        private ToolStripSeparator tssSep3;
        private ToolStripButton tsbHelp;
        private ToolStripButton tsbAutoupdate;
        private Label lblEmailCC;
        private TableLayoutPanel tableLayoutPanel1;
        private CheckBox cbxMailSenderInCc;
        private TextBox tbxEmailCC;
        private Label lblEmailBCC;
        private TableLayoutPanel tableLayoutPanel4;
        private TextBox tbxEmailBCC;
        private CheckBox cbxMailSenderInBcc;
    }
}