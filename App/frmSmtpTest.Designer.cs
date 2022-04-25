namespace ADBMailer
{
    partial class frmSmtpTest
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.tbxSender = new System.Windows.Forms.TextBox();
            this.lblSender = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.tbxResult = new System.Windows.Forms.TextBox();
            this.bgwSend = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // lblRecipient
            // 
            this.lblRecipient.AutoSize = true;
            this.lblRecipient.Location = new System.Drawing.Point(12, 53);
            this.lblRecipient.Name = "lblRecipient";
            this.lblRecipient.Size = new System.Drawing.Size(135, 15);
            this.lblRecipient.TabIndex = 2;
            this.lblRecipient.Text = "Indirizzo del destinatario";
            // 
            // tbxRecipient
            // 
            this.tbxRecipient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxRecipient.Location = new System.Drawing.Point(12, 71);
            this.tbxRecipient.Name = "tbxRecipient";
            this.tbxRecipient.PlaceholderText = "IndirizzoEmail oppure Nome <IndirizzoEmail>";
            this.tbxRecipient.Size = new System.Drawing.Size(559, 23);
            this.tbxRecipient.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(415, 322);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Chiudi";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendEmail.Location = new System.Drawing.Point(496, 322);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(75, 23);
            this.btnSendEmail.TabIndex = 7;
            this.btnSendEmail.Text = "Invia email";
            this.btnSendEmail.UseVisualStyleBackColor = true;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // tbxSender
            // 
            this.tbxSender.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxSender.Location = new System.Drawing.Point(12, 27);
            this.tbxSender.Name = "tbxSender";
            this.tbxSender.PlaceholderText = "IndirizzoEmail oppure Nome <IndirizzoEmail>";
            this.tbxSender.Size = new System.Drawing.Size(559, 23);
            this.tbxSender.TabIndex = 1;
            // 
            // lblSender
            // 
            this.lblSender.AutoSize = true;
            this.lblSender.Location = new System.Drawing.Point(12, 9);
            this.lblSender.Name = "lblSender";
            this.lblSender.Size = new System.Drawing.Size(118, 15);
            this.lblSender.TabIndex = 0;
            this.lblSender.Text = "Indirizzo del mittente";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(12, 97);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(53, 15);
            this.lblResult.TabIndex = 4;
            this.lblResult.Text = "Risultato";
            // 
            // tbxResult
            // 
            this.tbxResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxResult.Location = new System.Drawing.Point(12, 115);
            this.tbxResult.Multiline = true;
            this.tbxResult.Name = "tbxResult";
            this.tbxResult.ReadOnly = true;
            this.tbxResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxResult.Size = new System.Drawing.Size(559, 201);
            this.tbxResult.TabIndex = 5;
            // 
            // bgwSend
            // 
            this.bgwSend.WorkerReportsProgress = true;
            this.bgwSend.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSend_DoWork);
            this.bgwSend.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwSend_ProgressChanged);
            this.bgwSend.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwSend_RunWorkerCompleted);
            // 
            // frmSmtpTest
            // 
            this.AcceptButton = this.btnSendEmail;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(583, 357);
            this.Controls.Add(this.tbxSender);
            this.Controls.Add(this.lblSender);
            this.Controls.Add(this.btnSendEmail);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tbxResult);
            this.Controls.Add(this.tbxRecipient);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblRecipient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSmtpTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ADBMailer - Prova invio email";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSmtpTest_FormClosing);
            this.Shown += new System.EventHandler(this.frmSmtpTest_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblRecipient;
        private TextBox tbxRecipient;
        private Button btnClose;
        private Button btnSendEmail;
        private TextBox tbxSender;
        private Label lblSender;
        private Label lblResult;
        private TextBox tbxResult;
        private System.ComponentModel.BackgroundWorker bgwSend;
    }
}