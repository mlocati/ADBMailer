using System.ComponentModel;
using System.Diagnostics;

namespace ADBMailer
{
    public partial class frmUpdater : Form
    {
        private enum States
        {
            NeverStarted,
            FetchingLatestVersion,
            LatestVersionNotFetched,
            LatestVersionNotNewer,
            LatestVersionNewerAskingUser,
            Preparing,
            PreparationFailed,
            PreparationCompleted,
        }

        private States _state = States.NeverStarted;

        private States State
        {
            get => this._state;
            set
            {
                this._state = value;
                switch (value)
                {
                    case States.NeverStarted:
                    case States.FetchingLatestVersion:
                    case States.Preparing:
                    case States.PreparationCompleted:
                        this.btnClose.Enabled = this.btnUpdate.Enabled = false;
                        this.Cursor = Cursors.AppStarting;
                        break;

                    default:
                        this.btnClose.Enabled = true;
                        this.btnUpdate.Enabled = value == States.LatestVersionNewerAskingUser;
                        this.Cursor = Cursors.Default;
                        break;
                }
            }
        }

        private readonly Version CurrentVersion;
        private Updater.ReleaseVersion? _latestVersion = null;

        private Updater.ReleaseVersion? LatestVersion
        {
            get => this._latestVersion;
            set => this._latestVersion = value;
        }

        public frmUpdater(Version currentVersion)
        {
            InitializeComponent();
            if (Program.ExeIcon != null)
            {
                this.Icon = Program.ExeIcon;
            }
            this.CurrentVersion = currentVersion;
            this.lblCurrentVersion.Text = this.CurrentVersion.ToString(3);
            this.LatestVersion = null;
        }

        private void frmUpdater_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (this.State)
            {
                case States.NeverStarted:
                case States.FetchingLatestVersion:
                case States.Preparing:
                    e.Cancel = true;
                    break;

                case States.PreparationCompleted:
                    if (e.CloseReason != CloseReason.ApplicationExitCall)
                    {
                        e.Cancel = true;
                    }
                    break;
            }
        }

        private void frmUpdater_Shown(object sender, EventArgs e)
        {
            if (this.State != States.NeverStarted)
            {
                return;
            }
            this.State = States.FetchingLatestVersion;
            this.lblLatestVersion.Text = "Verifica ultima versione...";
            this.bgwGetLatestVersion.RunWorkerAsync(true);
        }

        private void bgwGetLatestVersion_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Updater.ReleaseVersion latestVersion;
                var isFirstRun = Convert.ToBoolean(e.Argument);
                Updater updater;
                if (isFirstRun)
                {
                    updater = new Updater();
                    try
                    {
                        latestVersion = updater.GetLatestVersion();
                        Options.GitHubToken = "";
                    }
                    catch (Updater.TokenRequiredException)
                    {
                        var githubToken = Options.GitHubToken;
                        if (githubToken == "")
                        {
                            throw;
                        }
                        updater = new Updater(githubToken);
                        latestVersion = updater.GetLatestVersion();
                    }
                }
                else
                {
                    updater = new Updater(Options.GitHubToken);
                    latestVersion = updater.GetLatestVersion();
                }
                e.Result = latestVersion;
            }
            catch (Exception x)
            {
                e.Result = x;
            }
        }

        private void bgwGetLatestVersion_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.LatestVersion = e.Result as Updater.ReleaseVersion;
            if (e.Result is Updater.TokenRequiredException)
            {
                this.lblLatestVersion.Text = "È richiesto un token di accesso a GitHub";
                this.btnGitHubToken.Visible = true;
            }
            else if (e.Result is Updater.TokenInvalidException)
            {
                this.lblLatestVersion.Text = "Il token di accesso a GitHub non è valido";
                this.btnGitHubToken.Visible = true;
            }
            else if (e.Result is Exception x)
            {
                this.lblLatestVersion.Text = x.Message;
            }
            else if (this.LatestVersion == null)
            {
                this.lblLatestVersion.Text = "Errore non specificato.";
            }
            if (this.LatestVersion == null)
            {
                this.State = States.LatestVersionNotFetched;
            }
            else
            {
                this.lblLatestVersion.Text = this.LatestVersion.Version.ToString(3);
                var currentVersionCmp = Version.Parse(this.CurrentVersion.ToString(3));
                var latestVersionCmp = Version.Parse(this.LatestVersion.Version.ToString(3));
                if (currentVersionCmp.CompareTo(latestVersionCmp) >= 0)
                {
                    this.State = States.LatestVersionNotNewer;
                }
                else
                {
                    this.State = States.LatestVersionNewerAskingUser;
                }
            }
        }

        private void btnGitHubToken_Click(object sender, EventArgs e)
        {
            using var form = new frmAskGithubToken();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                this.btnGitHubToken.Visible = false;
                this.State = States.FetchingLatestVersion;
                this.lblLatestVersion.Text = "Verifica ultima versione...";
                this.bgwGetLatestVersion.RunWorkerAsync(false);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.State = States.Preparing;
            this.bgwPrepare.RunWorkerAsync();
        }

        private void bgwPrepare_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (this.LatestVersion == null)
                {
                    throw new InvalidOperationException();
                }
                var zipFile = this.LatestVersion.Download();
                try
                {
                    e.Result = Updater.BuildUpdateScript(zipFile);
                }
                finally
                {
                    try { zipFile.Delete(); } catch { }
                }
            }
            catch (Exception x)
            {
                e.Result = x;
            }
        }

        private void bgwPrepare_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is not FileInfo batFile)
            {
                if (e.Result is not Exception x)
                {
                    x = new Exception("Errore durante la preparazione dell'aggiornamento");
                }
                this.State = States.PreparationFailed;
                MessageBox.Show(this, x.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.State = States.PreparationCompleted;
            try
            {
                var psi = new ProcessStartInfo()
                {
                    FileName = batFile.FullName,
                    UseShellExecute = true,
                    Verb = "runas",
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                };
                var proc = Process.Start(psi);
                if (proc == null)
                {
                    throw new Exception("Errore durante l'avvio dell'aggiornamento");
                }
            }
            catch (Exception x)
            {
                this.State = States.PreparationFailed;
                MessageBox.Show(this, x.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Application.Exit();
        }
    }
}