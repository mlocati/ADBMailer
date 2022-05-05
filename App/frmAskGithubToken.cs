using System.Diagnostics;

namespace ADBMailer
{
    public partial class frmAskGithubToken : Form
    {
        public frmAskGithubToken()
        {
            InitializeComponent();
            if (Program.ExeIcon != null)
            {
                this.Icon = Program.ExeIcon;
            }
        }

        private void lnkOpenGitHubTokens_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo($"https://github.com/settings/tokens/new?description=ADBMailer+auto-update&scopes=repo") { UseShellExecute = true });
            }
            catch (Exception x)
            {
                MessageBox.Show(this, x.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var token = this.tbxToken.Text.Trim();
            if (token.Length == 0)
            {
                this.tbxToken.Clear();
                this.tbxToken.Focus();
                return;
            }
            Options.GitHubToken = token;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}