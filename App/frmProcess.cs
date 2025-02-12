using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace ADBMailer
{
    public partial class frmProcess : CustomControls.ProgressForm
    {
        private class ProcessStats
        {
            public class Result
            {
                public readonly uint ProcessedRows;
                public readonly TimeSpan ProcessingTime;
                public readonly Exception? Error;
                private string? _stringified = null;

                public Result(uint processedRows, TimeSpan trocessingTime, Exception? error)
                {
                    this.ProcessedRows = processedRows;
                    this.ProcessingTime = trocessingTime;
                    this.Error = error;
                }

                public override string ToString()
                {
                    if (this._stringified == null)
                    {
                        var sb = new StringBuilder();
                        switch (this.ProcessedRows)
                        {
                            case 1:
                                sb.Append("1 riga processata");
                                break;

                            default:
                                sb.AppendFormat("{0:N0} righe processate", this.ProcessedRows);
                                break;
                        }
                        sb.Append(" in ");
                        if (this.ProcessingTime.TotalMinutes >= 1D)
                        {
                            var minutes = Convert.ToUInt32(Math.Floor(this.ProcessingTime.TotalMinutes));
                            switch (minutes)
                            {
                                case 1:
                                    sb.Append("1 minuto");
                                    break;

                                default:
                                    sb.AppendFormat("{0:N0} minuti", minutes);
                                    break;
                            }
                            sb.AppendFormat(" e {0:N2} secondi", Convert.ToDouble(this.ProcessingTime.Seconds) + Convert.ToDouble(this.ProcessingTime.Milliseconds) / 1000D);
                        }
                        else
                        {
                            sb.AppendFormat("{0:N2} secondi", this.ProcessingTime.TotalSeconds);
                        }
                        if (this.ProcessedRows > 0 && this.ProcessingTime.TotalSeconds > 0)
                        {
                            sb.AppendFormat(" ({0:N2} righe/secondo)", Convert.ToDouble(this.ProcessedRows) / this.ProcessingTime.TotalSeconds);
                        }

                        this._stringified = sb.ToString();
                    }
                    return this._stringified;
                }
            }

            public readonly DateTime StartTime;

            private uint _processedRows;

            public ProcessStats()
            {
                this.StartTime = DateTime.Now;
                this._processedRows = 0;
            }

            public void CountRow()
            {
                this._processedRows++;
            }

            public Result GetResult(Exception? error)
            {
                return new(this._processedRows, DateTime.Now - this.StartTime, error);
            }
        }

        private class WorkerProgress
        {
            public ProcessingLine? Line = null;
        }

        private readonly FilledRowConsumer.IFilledRowConsumer Consumer;
        private readonly FieldFiller Filler;
        private bool Started = false;
        private readonly List<IDisposable> Disposables = new();

        private class ProcessingLine : INotifyPropertyChanged
        {
            public enum Statuses
            {
                Processing,
                Failed,
                Successful,
            }

            public event PropertyChangedEventHandler? PropertyChanged;

            public int Row { get; }

            private readonly frmProcess Form;
            private string _text;
            private FileInfo? _generatedFile;
            private Statuses _status;

            public string Text
            {
                get => this._text;
            }

            public FileInfo? GeneratedFile
            {
                get => this._generatedFile;
            }

            public Image? FolderOpenImage
            {
                get => this._generatedFile == null ? Images.transparent_16x14 : Images.folder_open_16x14;
            }

            public Image? FileViewImage
            {
                get => this._generatedFile == null ? Images.transparent_16x14 : Images.eye_16x14;
            }

            public Statuses Status
            {
                get => this._status;
            }

            public void Update(string text)
            {
                this.Update(text, this._generatedFile, this._status);
            }

            public void Update(FileInfo? generatedFile)
            {
                this.Update(this._text, generatedFile, this._status);
            }

            public void Update(Statuses status)
            {
                this.Update(this._text, this._generatedFile, status);
            }

            public void Update(string text, Statuses status)
            {
                this.Update(text, this._generatedFile, status);
            }

            public void Update(string text, FileInfo? generatedFile, Statuses status)
            {
                bool changedProperties = false;
                if (this._text != text)
                {
                    changedProperties = true;
                    this._text = text;
                }
                if (
                    this._generatedFile == null && generatedFile != null
                    || this._generatedFile != null && generatedFile == null
                    || this._generatedFile != null && generatedFile != null && this._generatedFile.FullName != generatedFile.FullName
                )
                {
                    changedProperties = true;
                    this._generatedFile = generatedFile;
                }
                if (this._status != status)
                {
                    changedProperties = true;
                    this._status = status;
                }
                if (changedProperties == false || this.PropertyChanged == null)
                {
                    return;
                }

                void changer()
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(null));
                }
                if (this.Form.InvokeRequired)
                {
                    this.Form.Invoke(changer);
                }
                else
                {
                    changer();
                }
            }

            public ProcessingLine(frmProcess form, int row)
                : this(form, row, Statuses.Processing)
            { }

            public ProcessingLine(frmProcess form, int row, Statuses status)
            {
                this.Form = form;
                this.Row = row;
                this._text = "Inizio analisi riga...";
                this._status = status;
            }
        }

        private readonly BindingList<ProcessingLine> ProcessingLines;

        private readonly WordConverter.IWordConverter WordConverter;

        public frmProcess(FilledRowConsumer.IFilledRowConsumer consumer, FieldFiller filler)
        {
            InitializeComponent();
            if (Program.ExeIcon != null)
            {
                this.Icon = Program.ExeIcon;
            }
            this.Consumer = consumer;
            this.Text = $"ADBMailer - {this.Consumer.ProcessingWindowTitle}";
            this.Filler = filler;
            this.dgvColOpenFile.Visible = this.dgvColOpenFolder.Visible = this.Consumer.GeneratesPermamentFiles;
            if (this.Consumer.ForceDataRow.HasValue)
            {
                this.pbProgress.Visible = false;
            }
            else
            {
                this.MinimumProgressValue = this.pbProgress.Minimum = 0;
                this.MaximumProgressValue = this.pbProgress.Maximum = int.MaxValue;
                this.ProgressValue = this.pbProgress.Value = this.Filler.ExcelRange.FirstDataRow;
                this.MinimumProgressValue = this.pbProgress.Minimum = this.Filler.ExcelRange.FirstDataRow;
                this.MaximumProgressValue = this.pbProgress.Maximum = 1 + this.Filler.ExcelRange.LastDataRow;
                this.pbProgress.Visible = true;
                this.ProgressState = CustomControls.ThumbnailProgressState.Normal;
            }
            this.lblStats.Location = this.pbProgress.Location;
            this.lblStats.Size = this.pbProgress.Size;
            this.ProcessingLines = new BindingList<ProcessingLine>();
            this.dgvProgress.AutoGenerateColumns = false;
            this.dgvProgress.ShowCellToolTips = false;
            this.dgvProgress.DataSource = this.ProcessingLines;
            this.dgvProgress.Refresh();
            this.WordConverter = Options.GeneratePdfWith switch
            {
                Options.GENERATEPDFWITH_LIBREOFFICE => new WordConverter.WithLibreOffice(Options.LibreOfficeSofficeComPath),
                _ => new WordConverter.WithMicrosoftWord(),
            };
        }

        private void frmSend_Shown(object sender, EventArgs e) => this.Start();

        private void Start()
        {
            if (this.Started)
            {
                return;
            }
            this.btnCancel.Enabled = true;
            this.btnClose.Enabled = false;
            this.Started = true;
            this.Cursor = Cursors.AppStarting;
            this.bgwProcess.RunWorkerAsync();
        }

        private void bgwProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            var stats = new ProcessStats();
            Exception? error;
            try
            {
                this.ProcessNext(stats, null);
                error = null;
            }
            catch (Exception x)
            {
                error = x;
            }
            e.Result = stats.GetResult(error);
        }

        private void bgwProcess_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is WorkerProgress progress)
            {
                if (progress.Line != null)
                {
                    if (!this.ProcessingLines.Contains(progress.Line))
                    {
                        this.ProcessingLines.Add(progress.Line);
                    }
                    if (this.pbProgress.Visible)
                    {
                        this.pbProgress.Value = progress.Line.Row;
                        this.ProgressValue = progress.Line.Row;
                    }
                }
            }
        }

        private void bgwProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.pbProgress.Visible = false;
            this.ProgressState = CustomControls.ThumbnailProgressState.NoProgress;
            this.btnCancel.Enabled = false;
            this.btnClose.Enabled = true;
            this.Cursor = Cursors.Default;
            if (e.Result is ProcessStats.Result result)
            {
                if (result.Error != null)
                {
                    MessageBox.Show(this, result.Error.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (result.ProcessedRows > 0)
                {
                    this.lblStats.Text = result.ToString();
                    this.lblStats.Visible = true;
                }
            }
        }

        private void ProcessNext(ProcessStats stats, ProcessingLine? previousLine)
        {
            if (this.bgwProcess.CancellationPending)
            {
                return;
            }
            ProcessingLine line;
            if (previousLine == null)
            {
                line = new ProcessingLine(this, this.Consumer.ForceDataRow ?? this.Filler.ExcelRange.FirstDataRow);
            }
            else if (this.Consumer.ForceDataRow != null)
            {
                return;
            }
            else
            {
                line = new ProcessingLine(this, previousLine.Row + 1);
                if (line.Row > this.Filler.ExcelRange.LastDataRow)
                {
                    return;
                }
            }
            if (this.bgwProcess.CancellationPending)
            {
                line.Update("Operazione interrotta.", ProcessingLine.Statuses.Failed);
                return;
            }
            this.bgwProcess.ReportProgress(0, new WorkerProgress() { Line = line });
            if (this.bgwProcess.CancellationPending)
            {
                line.Update("Operazione interrotta.", ProcessingLine.Statuses.Failed);
                return;
            }
            line.Update("Lettura dati da Excel...");
            try
            {
                var filled = this.Filler.Fill(line.Row, this.Consumer, delegate (string error, int row, int? column)
                {
                    line.Update(error, ProcessingLine.Statuses.Failed);
                });
                if (filled != null)
                {
                    stats.CountRow();
                    try
                    {
                        if (this.bgwProcess.CancellationPending)
                        {
                            line.Update("Operazione interrotta.", ProcessingLine.Statuses.Failed);
                            return;
                        }
                        line.Update("Conversione da Word a PDF...");
                        byte[] pdfBytes = this.WordConverter.ConvertToPDF(filled.FilledWordDocument, Options.PdfQuality);
                        if (this.bgwProcess.CancellationPending)
                        {
                            line.Update("Operazione interrotta.", ProcessingLine.Statuses.Failed);
                            return;
                        }
                        var processResult = this.Consumer.Process(filled, pdfBytes, delegate (string status)
                        {
                            line.Update(status);
                        });
                        if (processResult.Disposable != null)
                        {
                            this.Disposables.Add(processResult.Disposable);
                        }
                        if (processResult.GeneratedFile != null)
                        {
                            line.Update(processResult.GeneratedFile);
                        }
                        line.Update(ProcessingLine.Statuses.Successful);
                    }
                    finally
                    {
                        filled.Dispose();
                    }
                }
            }
            catch (Exception x)
            {
                line.Update(x.Message, ProcessingLine.Statuses.Failed);
            }
            this.ProcessNext(stats, line);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!this.btnCancel.Enabled)
            {
                return;
            }
            if (MessageBox.Show(this, "Interrompere l'operazione?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes || !this.btnCancel.Enabled)
            {
                return;
            }
            this.bgwProcess.CancelAsync();
            if (this.ProgressState == CustomControls.ThumbnailProgressState.Normal)
            {
                this.ProgressState = CustomControls.ThumbnailProgressState.Paused;
            }
            this.btnCancel.Enabled = false;
        }

        private void frmSend_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.bgwProcess.IsBusy)
            {
                e.Cancel = true;
            }
        }

        private void frmProcess_FormClosed(object sender, FormClosedEventArgs e)
        {
            try { this.WordConverter.Dispose(); } catch { }
            foreach (var disposable in this.Disposables)
            {
                try { disposable.Dispose(); } catch { }
            }
            this.Disposables.Clear();
        }

        private void dgvProgress_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= this.ProcessingLines.Count)
            {
                return;
            }
            Color fgColor = this.dgvProgress.DefaultCellStyle.ForeColor;
            Color bgColor = dgvProgress.DefaultCellStyle.BackColor;
            switch (this.ProcessingLines[e.RowIndex].Status)
            {
                case ProcessingLine.Statuses.Processing:
                    fgColor = SystemColors.Highlight;
                    bgColor = SystemColors.HighlightText;
                    break;

                case ProcessingLine.Statuses.Failed:
                    fgColor = Color.Red;
                    break;
            }
            if (!fgColor.Equals(this.dgvProgress.Rows[e.RowIndex].DefaultCellStyle.ForeColor))
            {
                this.dgvProgress.Rows[e.RowIndex].DefaultCellStyle.ForeColor = fgColor;
            }
            if (!bgColor.Equals(this.dgvProgress.Rows[e.RowIndex].DefaultCellStyle.BackColor))
            {
                this.dgvProgress.Rows[e.RowIndex].DefaultCellStyle.BackColor = bgColor;
            }
        }

        private void dgvProgress_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && (e.ColumnIndex == this.dgvColOpenFolder.Index || e.ColumnIndex == this.dgvColOpenFile.Index))
            {
                var file = this.ProcessingLines[e.RowIndex].GeneratedFile;
                if (file != null && !file.Exists)
                {
                    MessageBox.Show(this, $"Impossibile trovare il file {file.FullName}", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    file = null;
                }
                if (file != null)
                {
                    try
                    {
                        if (e.ColumnIndex == this.dgvColOpenFolder.Index)
                        {
                            using var process = new Process();
                            process.StartInfo = new ProcessStartInfo()
                            {
                                FileName = "explorer.exe",
                                UseShellExecute = false,
                                Arguments = $"/select,\"{file.FullName}\"",
                            };
                            process.Start();
                        }
                        else if (e.ColumnIndex == this.dgvColOpenFile.Index)
                        {
                            using var process = new Process();
                            process.StartInfo = new ProcessStartInfo()
                            {
                                FileName = file.FullName,
                                UseShellExecute = true,
                                Verb = "open",
                                WindowStyle = ProcessWindowStyle.Maximized,
                            };
                            process.Start();
                        }
                    }
                    catch (Exception x)
                    {
                        MessageBox.Show(this, x.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!this.btnClose.Enabled)
            {
                return;
            }
            this.Close();
        }

        private void frmProcess_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    if (this.btnCancel.Enabled)
                    {
                        e.Handled = true;
                        this.btnCancel_Click(this, e);
                    }
                    else if (this.btnClose.Enabled)
                    {
                        e.Handled = true;
                        this.btnClose_Click(this, e);
                    }
                    break;
            }
        }
    }
}