namespace ADBMailer
{
    partial class frmUpdater
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
            this.lblCurrentVersionLabel = new System.Windows.Forms.Label();
            this.lblCurrentVersion = new System.Windows.Forms.Label();
            this.lblLatestVersionLabel = new System.Windows.Forms.Label();
            this.tlpVersions = new System.Windows.Forms.TableLayoutPanel();
            this.lblLatestVersion = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.bgwGetLatestVersion = new System.ComponentModel.BackgroundWorker();
            this.bgwPrepare = new System.ComponentModel.BackgroundWorker();
            this.btnGitHubToken = new System.Windows.Forms.Button();
            this.tlpVersions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCurrentVersionLabel
            // 
            this.lblCurrentVersionLabel.AutoSize = true;
            this.lblCurrentVersionLabel.Location = new System.Drawing.Point(3, 0);
            this.lblCurrentVersionLabel.Name = "lblCurrentVersionLabel";
            this.lblCurrentVersionLabel.Size = new System.Drawing.Size(90, 15);
            this.lblCurrentVersionLabel.TabIndex = 0;
            this.lblCurrentVersionLabel.Text = "Versione attuale";
            // 
            // lblCurrentVersion
            // 
            this.lblCurrentVersion.AutoSize = true;
            this.lblCurrentVersion.Location = new System.Drawing.Point(159, 0);
            this.lblCurrentVersion.Name = "lblCurrentVersion";
            this.lblCurrentVersion.Size = new System.Drawing.Size(98, 15);
            this.lblCurrentVersion.TabIndex = 1;
            this.lblCurrentVersion.Text = "lblCurrentVersion";
            // 
            // lblLatestVersionLabel
            // 
            this.lblLatestVersionLabel.AutoSize = true;
            this.lblLatestVersionLabel.Location = new System.Drawing.Point(3, 15);
            this.lblLatestVersionLabel.Name = "lblLatestVersionLabel";
            this.lblLatestVersionLabel.Size = new System.Drawing.Size(150, 15);
            this.lblLatestVersionLabel.TabIndex = 2;
            this.lblLatestVersionLabel.Text = "Ultima versione disponibile";
            // 
            // tlpVersions
            // 
            this.tlpVersions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpVersions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpVersions.ColumnCount = 2;
            this.tlpVersions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpVersions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpVersions.Controls.Add(this.lblLatestVersion, 1, 1);
            this.tlpVersions.Controls.Add(this.btnUpdate, 0, 2);
            this.tlpVersions.Controls.Add(this.lblCurrentVersionLabel, 0, 0);
            this.tlpVersions.Controls.Add(this.lblLatestVersionLabel, 0, 1);
            this.tlpVersions.Controls.Add(this.lblCurrentVersion, 1, 0);
            this.tlpVersions.Location = new System.Drawing.Point(12, 12);
            this.tlpVersions.Name = "tlpVersions";
            this.tlpVersions.RowCount = 3;
            this.tlpVersions.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpVersions.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpVersions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpVersions.Size = new System.Drawing.Size(427, 87);
            this.tlpVersions.TabIndex = 0;
            // 
            // lblLatestVersion
            // 
            this.lblLatestVersion.AutoSize = true;
            this.lblLatestVersion.Location = new System.Drawing.Point(159, 15);
            this.lblLatestVersion.Name = "lblLatestVersion";
            this.lblLatestVersion.Size = new System.Drawing.Size(89, 15);
            this.lblLatestVersion.TabIndex = 3;
            this.lblLatestVersion.Text = "lblLatestVersion";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tlpVersions.SetColumnSpan(this.btnUpdate, 2);
            this.btnUpdate.Location = new System.Drawing.Point(176, 47);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Aggiorna";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(364, 105);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Chiudi";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // bgwGetLatestVersion
            // 
            this.bgwGetLatestVersion.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwGetLatestVersion_DoWork);
            this.bgwGetLatestVersion.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwGetLatestVersion_RunWorkerCompleted);
            // 
            // bgwPrepare
            // 
            this.bgwPrepare.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwPrepare_DoWork);
            this.bgwPrepare.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwPrepare_RunWorkerCompleted);
            // 
            // btnGitHubToken
            // 
            this.btnGitHubToken.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGitHubToken.Location = new System.Drawing.Point(251, 105);
            this.btnGitHubToken.Name = "btnGitHubToken";
            this.btnGitHubToken.Size = new System.Drawing.Size(107, 23);
            this.btnGitHubToken.TabIndex = 1;
            this.btnGitHubToken.Text = "Token di GitHub";
            this.btnGitHubToken.UseVisualStyleBackColor = true;
            this.btnGitHubToken.Visible = false;
            this.btnGitHubToken.Click += new System.EventHandler(this.btnGitHubToken_Click);
            // 
            // frmUpdater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(451, 140);
            this.Controls.Add(this.btnGitHubToken);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tlpVersions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 150);
            this.Name = "frmUpdater";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ADBMailer - Aggiornamento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmUpdater_FormClosing);
            this.Shown += new System.EventHandler(this.frmUpdater_Shown);
            this.tlpVersions.ResumeLayout(false);
            this.tlpVersions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblCurrentVersionLabel;
        private Label lblCurrentVersion;
        private Label lblLatestVersionLabel;
        private TableLayoutPanel tlpVersions;
        private Label lblLatestVersion;
        private Button btnClose;
        private Button btnUpdate;
        private System.ComponentModel.BackgroundWorker bgwGetLatestVersion;
        private System.ComponentModel.BackgroundWorker bgwPrepare;
        private Button btnGitHubToken;
    }
}