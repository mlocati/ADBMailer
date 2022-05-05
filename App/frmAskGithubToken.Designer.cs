namespace ADBMailer
{
    partial class frmAskGithubToken
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
            this.lblInfo = new System.Windows.Forms.Label();
            this.lnkOpenGitHubTokens = new System.Windows.Forms.LinkLabel();
            this.lblToken = new System.Windows.Forms.Label();
            this.tbxToken = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.BackColor = System.Drawing.SystemColors.Control;
            this.lblInfo.Location = new System.Drawing.Point(12, 9);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(389, 52);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Per aggiornare automaticamente l\'applicazione è necessario fornire un token di ac" +
    "cesso personale di GitHub.";
            // 
            // lnkOpenGitHubTokens
            // 
            this.lnkOpenGitHubTokens.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkOpenGitHubTokens.AutoSize = true;
            this.lnkOpenGitHubTokens.Location = new System.Drawing.Point(283, 105);
            this.lnkOpenGitHubTokens.Name = "lnkOpenGitHubTokens";
            this.lnkOpenGitHubTokens.Size = new System.Drawing.Size(118, 15);
            this.lnkOpenGitHubTokens.TabIndex = 3;
            this.lnkOpenGitHubTokens.TabStop = true;
            this.lnkOpenGitHubTokens.Text = "Crea un nuovo token";
            this.lnkOpenGitHubTokens.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkOpenGitHubTokens_LinkClicked);
            // 
            // lblToken
            // 
            this.lblToken.AutoSize = true;
            this.lblToken.Location = new System.Drawing.Point(12, 61);
            this.lblToken.Name = "lblToken";
            this.lblToken.Size = new System.Drawing.Size(203, 15);
            this.lblToken.TabIndex = 1;
            this.lblToken.Text = "Token di accesso personale di GitHub";
            // 
            // tbxToken
            // 
            this.tbxToken.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxToken.Location = new System.Drawing.Point(12, 79);
            this.tbxToken.Name = "tbxToken";
            this.tbxToken.Size = new System.Drawing.Size(389, 23);
            this.tbxToken.TabIndex = 2;
            this.tbxToken.UseSystemPasswordChar = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(245, 152);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Annulla";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(326, 152);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Applica";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmAskGithubToken
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(413, 187);
            this.Controls.Add(this.lnkOpenGitHubTokens);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblToken);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tbxToken);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(340, 200);
            this.Name = "frmAskGithubToken";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ABMailer - Token di GitHub";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblInfo;
        private LinkLabel lnkOpenGitHubTokens;
        private Label lblToken;
        private TextBox tbxToken;
        private Button btnCancel;
        private Button btnOk;
    }
}