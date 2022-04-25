namespace ADBMailer
{
    partial class frmProcess
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvProgress = new ADBMailer.CustomControls.DoubleBufferedDataGridView();
            this.dgvColLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColOpenFolder = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvColOpenFile = new System.Windows.Forms.DataGridViewImageColumn();
            this.bgwProcess = new System.ComponentModel.BackgroundWorker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.lblStats = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProgress
            // 
            this.dgvProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProgress.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvProgress.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvProgress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProgress.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvColLine,
            this.dgvColText,
            this.dgvColOpenFolder,
            this.dgvColOpenFile});
            this.dgvProgress.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvProgress.Location = new System.Drawing.Point(12, 12);
            this.dgvProgress.MultiSelect = false;
            this.dgvProgress.Name = "dgvProgress";
            this.dgvProgress.ReadOnly = true;
            this.dgvProgress.RowHeadersVisible = false;
            this.dgvProgress.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvProgress.RowTemplate.Height = 25;
            this.dgvProgress.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProgress.Size = new System.Drawing.Size(776, 397);
            this.dgvProgress.TabIndex = 0;
            this.dgvProgress.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProgress_CellClick);
            this.dgvProgress.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvProgress_CellFormatting);
            // 
            // dgvColLine
            // 
            this.dgvColLine.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvColLine.DataPropertyName = "Row";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvColLine.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvColLine.HeaderText = "Riga";
            this.dgvColLine.Name = "dgvColLine";
            this.dgvColLine.ReadOnly = true;
            this.dgvColLine.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvColLine.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvColText
            // 
            this.dgvColText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvColText.DataPropertyName = "Text";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColText.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvColText.HeaderText = "Avanzamento";
            this.dgvColText.Name = "dgvColText";
            this.dgvColText.ReadOnly = true;
            this.dgvColText.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvColText.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvColOpenFolder
            // 
            this.dgvColOpenFolder.DataPropertyName = "FolderOpenImage";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvColOpenFolder.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvColOpenFolder.HeaderText = "";
            this.dgvColOpenFolder.Name = "dgvColOpenFolder";
            this.dgvColOpenFolder.ReadOnly = true;
            this.dgvColOpenFolder.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvColOpenFolder.Width = 21;
            // 
            // dgvColOpenFile
            // 
            this.dgvColOpenFile.DataPropertyName = "FileViewImage";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvColOpenFile.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvColOpenFile.HeaderText = "";
            this.dgvColOpenFile.Name = "dgvColOpenFile";
            this.dgvColOpenFile.ReadOnly = true;
            this.dgvColOpenFile.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvColOpenFile.Width = 21;
            // 
            // bgwProcess
            // 
            this.bgwProcess.WorkerReportsProgress = true;
            this.bgwProcess.WorkerSupportsCancellation = true;
            this.bgwProcess.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwProcess_DoWork);
            this.bgwProcess.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwProcess_ProgressChanged);
            this.bgwProcess.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwProcess_RunWorkerCompleted);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(632, 415);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Interrompi";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Enabled = false;
            this.btnClose.Location = new System.Drawing.Point(713, 415);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Chiudi";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pbProgress
            // 
            this.pbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbProgress.Location = new System.Drawing.Point(12, 415);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(614, 23);
            this.pbProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbProgress.TabIndex = 1;
            // 
            // lblStats
            // 
            this.lblStats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStats.AutoEllipsis = true;
            this.lblStats.Location = new System.Drawing.Point(75, 419);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(45, 15);
            this.lblStats.TabIndex = 2;
            this.lblStats.Text = "lblStats";
            this.lblStats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStats.Visible = false;
            // 
            // frmProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblStats);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dgvProgress);
            this.KeyPreview = true;
            this.Name = "frmProcess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ADBMailer - Elaborazione";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSend_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmProcess_FormClosed);
            this.Shown += new System.EventHandler(this.frmSend_Shown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmProcess_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProgress)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ADBMailer.CustomControls.DoubleBufferedDataGridView dgvProgress;
        private System.ComponentModel.BackgroundWorker bgwProcess;
        private Button btnCancel;
        private Button btnClose;
        private ProgressBar pbProgress;
        private Label lblStats;
        private DataGridViewTextBoxColumn dgvColLine;
        private DataGridViewTextBoxColumn dgvColText;
        private DataGridViewImageColumn dgvColOpenFolder;
        private DataGridViewImageColumn dgvColOpenFile;
    }
}