namespace ADBMailer
{
    partial class frmMapDocs
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
            this.lsbField = new System.Windows.Forms.ListBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.tnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lsbHeader = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lnkClearSelected = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsbField
            // 
            this.lsbField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbField.FormattingEnabled = true;
            this.lsbField.IntegralHeight = false;
            this.lsbField.ItemHeight = 15;
            this.lsbField.Location = new System.Drawing.Point(3, 23);
            this.lsbField.Name = "lsbField";
            this.lsbField.Size = new System.Drawing.Size(382, 351);
            this.lsbField.TabIndex = 1;
            this.lsbField.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lsbField_DrawItem);
            this.lsbField.SelectedIndexChanged += new System.EventHandler(this.lsbField_SelectedIndexChanged);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTo.Location = new System.Drawing.Point(3, 0);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(382, 20);
            this.lblTo.TabIndex = 0;
            this.lblTo.Text = "Campo";
            this.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tnOk
            // 
            this.tnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tnOk.Location = new System.Drawing.Point(713, 415);
            this.tnOk.Name = "tnOk";
            this.tnOk.Size = new System.Drawing.Size(75, 23);
            this.tnOk.TabIndex = 2;
            this.tnOk.Text = "Applica";
            this.tnOk.UseVisualStyleBackColor = true;
            this.tnOk.Click += new System.EventHandler(this.tnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(632, 415);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Annulla";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(391, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(382, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Prendi valori da";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lsbHeader
            // 
            this.lsbHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbHeader.FormattingEnabled = true;
            this.lsbHeader.IntegralHeight = false;
            this.lsbHeader.ItemHeight = 15;
            this.lsbHeader.Location = new System.Drawing.Point(391, 23);
            this.lsbHeader.Name = "lsbHeader";
            this.lsbHeader.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbHeader.Size = new System.Drawing.Size(382, 351);
            this.lsbHeader.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblTo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lsbHeader, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lsbField, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lnkClearSelected, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(776, 397);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lnkClearSelected
            // 
            this.lnkClearSelected.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lnkClearSelected.AutoSize = true;
            this.lnkClearSelected.Location = new System.Drawing.Point(720, 379);
            this.lnkClearSelected.Name = "lnkClearSelected";
            this.lnkClearSelected.Size = new System.Drawing.Size(53, 15);
            this.lnkClearSelected.TabIndex = 4;
            this.lnkClearSelected.TabStop = true;
            this.lnkClearSelected.Text = "Nessuno";
            this.lnkClearSelected.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkClearSelected_LinkClicked);
            // 
            // frmMapDocs
            // 
            this.AcceptButton = this.tnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tnOk);
            this.MinimumSize = new System.Drawing.Size(400, 170);
            this.Name = "frmMapDocs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ADBMailer - Mappa documenti";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox lsbField;
        private Label lblTo;
        private Button tnOk;
        private Button btnCancel;
        private Label label1;
        private ListBox lsbHeader;
        private TableLayoutPanel tableLayoutPanel1;
        private LinkLabel lnkClearSelected;
    }
}