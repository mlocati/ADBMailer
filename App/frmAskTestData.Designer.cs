namespace ADBMailer
{
    partial class frmAskTestData
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
            this.lblRecipient = new System.Windows.Forms.Label();
            this.tbxRecipient = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblExcelRow = new System.Windows.Forms.Label();
            this.nudExcelRow = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudExcelRow)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecipient
            // 
            this.lblRecipient.AutoSize = true;
            this.lblRecipient.Location = new System.Drawing.Point(12, 62);
            this.lblRecipient.Name = "lblRecipient";
            this.lblRecipient.Size = new System.Drawing.Size(264, 15);
            this.lblRecipient.TabIndex = 2;
            this.lblRecipient.Text = "Indicare il destinatario cui inviare l\'email di prova";
            // 
            // tbxRecipient
            // 
            this.tbxRecipient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxRecipient.Location = new System.Drawing.Point(12, 80);
            this.tbxRecipient.Name = "tbxRecipient";
            this.tbxRecipient.Size = new System.Drawing.Size(560, 23);
            this.tbxRecipient.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(416, 124);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Annulla";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(497, 124);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblExcelRow
            // 
            this.lblExcelRow.AutoSize = true;
            this.lblExcelRow.Location = new System.Drawing.Point(12, 9);
            this.lblExcelRow.Name = "lblExcelRow";
            this.lblExcelRow.Size = new System.Drawing.Size(138, 15);
            this.lblExcelRow.TabIndex = 0;
            this.lblExcelRow.Text = "Riga di Excel da utilizzare";
            // 
            // nudExcelRow
            // 
            this.nudExcelRow.Location = new System.Drawing.Point(12, 27);
            this.nudExcelRow.Name = "nudExcelRow";
            this.nudExcelRow.Size = new System.Drawing.Size(138, 23);
            this.nudExcelRow.TabIndex = 1;
            // 
            // frmAskTestData
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(584, 159);
            this.Controls.Add(this.nudExcelRow);
            this.Controls.Add(this.lblExcelRow);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tbxRecipient);
            this.Controls.Add(this.lblRecipient);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 190);
            this.Name = "frmAskTestData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ADBMailer - Invio email di prova";
            ((System.ComponentModel.ISupportInitialize)(this.nudExcelRow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblRecipient;
        private TextBox tbxRecipient;
        private Button btnCancel;
        private Button btnOk;
        private Label lblExcelRow;
        private NumericUpDown nudExcelRow;
    }
}