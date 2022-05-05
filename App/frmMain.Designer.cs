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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnWord = new System.Windows.Forms.Button();
            this.ofdExcel = new System.Windows.Forms.OpenFileDialog();
            this.ofdWord = new System.Windows.Forms.OpenFileDialog();
            this.ttTip = new System.Windows.Forms.ToolTip(this.components);
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tbxWord = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tbxExcel = new System.Windows.Forms.TextBox();
            this.lblBody = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblSender = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxEmailBody = new System.Windows.Forms.TextBox();
            this.tbxEmailSubject = new System.Windows.Forms.TextBox();
            this.tbxEmailFrom = new System.Windows.Forms.TextBox();
            this.tmrUpdateDocs = new System.Windows.Forms.Timer(this.components);
            this.tsMainMenu = new ADBMailer.CustomControls.ToolStrip();
            this.tsbMapFields = new System.Windows.Forms.ToolStripButton();
            this.tssSep0 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSavePdfTest = new System.Windows.Forms.ToolStripButton();
            this.tsbEmailTest = new System.Windows.Forms.ToolStripButton();
            this.tssSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSavePdf = new System.Windows.Forms.ToolStripButton();
            this.tsbEmailSend = new System.Windows.Forms.ToolStripButton();
            this.tssSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbOptions = new System.Windows.Forms.ToolStripButton();
            this.tssSep3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbHelp = new System.Windows.Forms.ToolStripButton();
            this.tsbAutoupdate = new System.Windows.Forms.ToolStripButton();
            this.tlpMain.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tsMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(533, 3);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExcel.TabIndex = 1;
            this.btnExcel.Text = "Sfoglia...";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnWord
            // 
            this.btnWord.Location = new System.Drawing.Point(533, 3);
            this.btnWord.Name = "btnWord";
            this.btnWord.Size = new System.Drawing.Size(75, 23);
            this.btnWord.TabIndex = 1;
            this.btnWord.Text = "Sfoglia...";
            this.btnWord.UseVisualStyleBackColor = true;
            this.btnWord.Click += new System.EventHandler(this.btnWord_Click);
            // 
            // ofdExcel
            // 
            this.ofdExcel.DefaultExt = "xlsx";
            this.ofdExcel.Filter = "Fogli di Excel|*.xlsx;*.xlsm|Tutti i file|*.*";
            this.ofdExcel.Title = "Apri foglio di Excel";
            // 
            // ofdWord
            // 
            this.ofdWord.DefaultExt = "docx";
            this.ofdWord.Filter = "Documenti di Word|*.docx;*.docm|Tutti i file|*.*";
            this.ofdWord.Title = "Apri documento di Word";
            // 
            // tlpMain
            // 
            this.tlpMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tableLayoutPanel3, 1, 1);
            this.tlpMain.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tlpMain.Controls.Add(this.lblBody, 0, 4);
            this.tlpMain.Controls.Add(this.lblSubject, 0, 3);
            this.tlpMain.Controls.Add(this.lblSender, 0, 2);
            this.tlpMain.Controls.Add(this.label1, 0, 0);
            this.tlpMain.Controls.Add(this.label2, 0, 1);
            this.tlpMain.Controls.Add(this.tbxEmailBody, 1, 4);
            this.tlpMain.Controls.Add(this.tbxEmailSubject, 1, 3);
            this.tlpMain.Controls.Add(this.tbxEmailFrom, 1, 2);
            this.tlpMain.Location = new System.Drawing.Point(12, 85);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 5;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(738, 376);
            this.tlpMain.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.btnWord, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tbxWord, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(124, 38);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(611, 29);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // tbxWord
            // 
            this.tbxWord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxWord.Location = new System.Drawing.Point(3, 3);
            this.tbxWord.Name = "tbxWord";
            this.tbxWord.PlaceholderText = "Seleziona un documento di Word o trascinalo in questa finestra";
            this.tbxWord.ReadOnly = true;
            this.tbxWord.Size = new System.Drawing.Size(524, 23);
            this.tbxWord.TabIndex = 0;
            this.tbxWord.Resize += new System.EventHandler(this.tbxWord_Resize);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.tbxExcel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnExcel, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(124, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(611, 29);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tbxExcel
            // 
            this.tbxExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxExcel.Location = new System.Drawing.Point(3, 3);
            this.tbxExcel.Name = "tbxExcel";
            this.tbxExcel.PlaceholderText = "Seleziona un foglio di Excel o trascinalo in questa finestra";
            this.tbxExcel.ReadOnly = true;
            this.tbxExcel.Size = new System.Drawing.Size(524, 23);
            this.tbxExcel.TabIndex = 0;
            this.tbxExcel.Resize += new System.EventHandler(this.tbxExcel_Resize);
            // 
            // lblBody
            // 
            this.lblBody.AutoSize = true;
            this.lblBody.Location = new System.Drawing.Point(3, 128);
            this.lblBody.Name = "lblBody";
            this.lblBody.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblBody.Size = new System.Drawing.Size(40, 25);
            this.lblBody.TabIndex = 8;
            this.lblBody.Text = "Corpo";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(3, 99);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblSubject.Size = new System.Drawing.Size(51, 25);
            this.lblSubject.TabIndex = 6;
            this.lblSubject.Text = "Oggetto";
            // 
            // lblSender
            // 
            this.lblSender.AutoSize = true;
            this.lblSender.Location = new System.Drawing.Point(3, 70);
            this.lblSender.Name = "lblSender";
            this.lblSender.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblSender.Size = new System.Drawing.Size(52, 25);
            this.lblSender.TabIndex = 4;
            this.lblSender.Text = "Mittente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label1.Size = new System.Drawing.Size(83, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Foglio di Excel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 35);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label2.Size = new System.Drawing.Size(115, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Documento di Word";
            // 
            // tbxEmailBody
            // 
            this.tbxEmailBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxEmailBody.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbxEmailBody.Location = new System.Drawing.Point(124, 131);
            this.tbxEmailBody.Multiline = true;
            this.tbxEmailBody.Name = "tbxEmailBody";
            this.tbxEmailBody.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxEmailBody.Size = new System.Drawing.Size(611, 242);
            this.tbxEmailBody.TabIndex = 9;
            // 
            // tbxEmailSubject
            // 
            this.tbxEmailSubject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxEmailSubject.Location = new System.Drawing.Point(124, 102);
            this.tbxEmailSubject.Name = "tbxEmailSubject";
            this.tbxEmailSubject.Size = new System.Drawing.Size(611, 23);
            this.tbxEmailSubject.TabIndex = 7;
            // 
            // tbxEmailFrom
            // 
            this.tbxEmailFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxEmailFrom.Location = new System.Drawing.Point(124, 73);
            this.tbxEmailFrom.Name = "tbxEmailFrom";
            this.tbxEmailFrom.PlaceholderText = "IndirizzoEmail oppure Nome <IndirizzoEmail>";
            this.tbxEmailFrom.Size = new System.Drawing.Size(611, 23);
            this.tbxEmailFrom.TabIndex = 5;
            // 
            // tmrUpdateDocs
            // 
            this.tmrUpdateDocs.Interval = 10;
            this.tmrUpdateDocs.Tick += new System.EventHandler(this.tmrUpdateDocs_Tick);
            // 
            // tsMainMenu
            // 
            this.tsMainMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbMapFields,
            this.tssSep0,
            this.tsbSavePdfTest,
            this.tsbEmailTest,
            this.tssSep1,
            this.tsbSavePdf,
            this.tsbEmailSend,
            this.tssSep2,
            this.tsbOptions,
            this.tssSep3,
            this.tsbHelp,
            this.tsbAutoupdate});
            this.tsMainMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMainMenu.Name = "tsMainMenu";
            this.tsMainMenu.Size = new System.Drawing.Size(762, 70);
            this.tsMainMenu.TabIndex = 0;
            this.tsMainMenu.Text = "Menu principale";
            // 
            // tsbMapFields
            // 
            this.tsbMapFields.Image = ((System.Drawing.Image)(resources.GetObject("tsbMapFields.Image")));
            this.tsbMapFields.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbMapFields.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMapFields.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.tsbMapFields.Name = "tsbMapFields";
            this.tsbMapFields.Size = new System.Drawing.Size(84, 67);
            this.tsbMapFields.Text = "Mappa campi";
            this.tsbMapFields.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbMapFields.Click += new System.EventHandler(this.tsbMapFields_Click);
            // 
            // tssSep0
            // 
            this.tssSep0.Name = "tssSep0";
            this.tssSep0.Size = new System.Drawing.Size(6, 70);
            // 
            // tsbSavePdfTest
            // 
            this.tsbSavePdfTest.Image = ((System.Drawing.Image)(resources.GetObject("tsbSavePdfTest.Image")));
            this.tsbSavePdfTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSavePdfTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSavePdfTest.Name = "tsbSavePdfTest";
            this.tsbSavePdfTest.Size = new System.Drawing.Size(87, 67);
            this.tsbSavePdfTest.Text = "Vedi PDF (test)";
            this.tsbSavePdfTest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSavePdfTest.Click += new System.EventHandler(this.tsbSavePdfTest_Click);
            // 
            // tsbEmailTest
            // 
            this.tsbEmailTest.Image = ((System.Drawing.Image)(resources.GetObject("tsbEmailTest.Image")));
            this.tsbEmailTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbEmailTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEmailTest.Name = "tsbEmailTest";
            this.tsbEmailTest.Size = new System.Drawing.Size(98, 67);
            this.tsbEmailTest.Text = "Invia email (test)";
            this.tsbEmailTest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbEmailTest.Click += new System.EventHandler(this.tsbEmailTest_Click);
            // 
            // tssSep1
            // 
            this.tssSep1.Name = "tssSep1";
            this.tssSep1.Size = new System.Drawing.Size(6, 70);
            // 
            // tsbSavePdf
            // 
            this.tsbSavePdf.Image = ((System.Drawing.Image)(resources.GetObject("tsbSavePdf.Image")));
            this.tsbSavePdf.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSavePdf.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSavePdf.Name = "tsbSavePdf";
            this.tsbSavePdf.Size = new System.Drawing.Size(62, 67);
            this.tsbSavePdf.Text = "Salva PDF";
            this.tsbSavePdf.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSavePdf.Click += new System.EventHandler(this.tsbSavePdf_Click);
            // 
            // tsbEmailSend
            // 
            this.tsbEmailSend.Image = ((System.Drawing.Image)(resources.GetObject("tsbEmailSend.Image")));
            this.tsbEmailSend.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbEmailSend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEmailSend.Name = "tsbEmailSend";
            this.tsbEmailSend.Size = new System.Drawing.Size(68, 67);
            this.tsbEmailSend.Text = "Invia email";
            this.tsbEmailSend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbEmailSend.Click += new System.EventHandler(this.tsbEmailSend_Click);
            // 
            // tssSep2
            // 
            this.tssSep2.Name = "tssSep2";
            this.tssSep2.Size = new System.Drawing.Size(6, 70);
            // 
            // tsbOptions
            // 
            this.tsbOptions.Image = ((System.Drawing.Image)(resources.GetObject("tsbOptions.Image")));
            this.tsbOptions.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOptions.Margin = new System.Windows.Forms.Padding(7, 1, 0, 2);
            this.tsbOptions.Name = "tsbOptions";
            this.tsbOptions.Size = new System.Drawing.Size(52, 67);
            this.tsbOptions.Text = "Opzioni";
            this.tsbOptions.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbOptions.ToolTipText = "Opzioni (F4)";
            this.tsbOptions.Click += new System.EventHandler(this.tsbOptions_Click);
            // 
            // tssSep3
            // 
            this.tssSep3.Name = "tssSep3";
            this.tssSep3.Size = new System.Drawing.Size(6, 70);
            // 
            // tsbHelp
            // 
            this.tsbHelp.Image = ((System.Drawing.Image)(resources.GetObject("tsbHelp.Image")));
            this.tsbHelp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHelp.Name = "tsbHelp";
            this.tsbHelp.Size = new System.Drawing.Size(52, 67);
            this.tsbHelp.Text = "Guida";
            this.tsbHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbHelp.ToolTipText = "Guida (F1)";
            this.tsbHelp.Click += new System.EventHandler(this.tsbHelp_Click);
            // 
            // tsbAutoupdate
            // 
            this.tsbAutoupdate.Image = ((System.Drawing.Image)(resources.GetObject("tsbAutoupdate.Image")));
            this.tsbAutoupdate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbAutoupdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAutoupdate.Name = "tsbAutoupdate";
            this.tsbAutoupdate.Size = new System.Drawing.Size(83, 67);
            this.tsbAutoupdate.Text = "Aggiorna app";
            this.tsbAutoupdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbAutoupdate.Click += new System.EventHandler(this.tsbAutoupdate_Click);
            // 
            // frmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 473);
            this.Controls.Add(this.tsMainMenu);
            this.Controls.Add(this.tlpMain);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(570, 300);
            this.Name = "frmMain";
            this.Text = "ADBMailer";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmMain_DragDrop);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.frmMain_DragOver);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyUp);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tsMainMenu.ResumeLayout(false);
            this.tsMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnExcel;
        private Button btnWord;
        private OpenFileDialog ofdExcel;
        private OpenFileDialog ofdWord;
        private ToolTip ttTip;
        private TableLayoutPanel tlpMain;
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
    }
}