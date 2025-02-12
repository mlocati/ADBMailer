using MimeKit;

namespace ADBMailer
{
    public partial class frmMain : Form
    {
        private Mapping? Mapping = null;

        private class DroppedFiles
        {
            public FileInfo? xls = null;
            public FileInfo? doc = null;
        }

        private string _excelFile = "";

        private string ExcelFile
        {
            get => this._excelFile;
            set
            {
                this._excelFile = value ?? "";
                this.UpdateDocsStatus();
            }
        }

        private string _wordFile = "";

        private string WordFile
        {
            get => this._wordFile;
            set
            {
                this._wordFile = value ?? ""; ;
                this.UpdateDocsStatus();
            }
        }

        public frmMain()
        {
            InitializeComponent();
            if (Program.ExeIcon != null)
            {
                this.Icon = Program.ExeIcon;
            }
            if (Program.Version != null)
            {
                this.Text += " v" + Program.Version.ToString(3);
            }
            this.ExcelFile = "";
            this.WordFile = "";
            string dir;
            dir = Options.ExcelFilesDirectory;
            if (dir.Length > 0)
            {
                this.ofdExcel.InitialDirectory = dir;
            }
            dir = Options.WordFilesDirectory;
            if (dir.Length > 0)
            {
                this.ofdWord.InitialDirectory = dir;
            }
            if (Options.Smtp.DefaultSender != null)
            {
                this.tbxEmailFrom.Text = Options.Smtp.DefaultSender.ToString();
            }
            this.tbxEmailCC.Text = Options.MailCc.ToString();
            this.cbxMailSenderInCc.Checked = Options.MailSenderInCc;
            this.tbxEmailBCC.Text = Options.MailBcc.ToString();
            this.cbxMailSenderInBcc.Checked = Options.MailSenderInBcc;
        }

        private void tsbOptions_Click(object sender, EventArgs e)
        {
            bool setSender;
            if (this.tbxEmailFrom.Text.Trim() == "")
            {
                setSender = true;
            }
            else if (Options.Smtp.DefaultSender == null)
            {
                setSender = true;
            }
            else
            {
                setSender = Options.Smtp.DefaultSender.ToString() == this.tbxEmailFrom.Text.Trim();
            }
            using var options = new frmOptions();
            if (options.ShowDialog(this) == DialogResult.OK)
            {
                if (setSender && Options.Smtp.DefaultSender != null)
                {
                    this.tbxEmailFrom.Text = Options.Smtp.DefaultSender.ToString();
                }
            }
        }

        private void tsbMapFields_Click(object sender, EventArgs e)
        {
            try
            {
                var excelFields = new ExcelMapper().GetColumnHeaders(this.ExcelFile);
                var wordFields = new WordMapper(Options.GeneratePdfLocale).GetFields(this.WordFile);
                using var mapper = new frmMapDocs(excelFields, wordFields, this.Mapping);
                if (mapper.ShowDialog(this) == DialogResult.OK)
                {
                    this.Mapping = mapper.Mapping;
                    this.RememberDocsDirectories();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(this, x.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbSavePdfTest_Click(object sender, EventArgs e)
        {
            try
            {
                using var filler = new FieldFiller(this.ExcelFile, this.WordFile, false, this.Mapping);
                this.RememberDocsDirectories();
                int? testExcelDataRow = null;
                using (var frm = new frmAskTestData(filler.ExcelRange.FirstDataRow, filler.ExcelRange.LastDataRow, frmAskTestData.Reason.ViewPDF))
                {
                    if (frm.ShowDialog(this) == DialogResult.OK && frm.Result != null)
                    {
                        testExcelDataRow = frm.Result.ExcelDataRow;
                    }
                }
                if (testExcelDataRow == null)
                {
                    return;
                }
                var consumer = new FilledRowConsumer.SaverTest(testExcelDataRow.Value);
                this.Process(consumer, filler);
            }
            catch (Exception x)
            {
                MessageBox.Show(this, x.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbSavePdf_Click(object sender, EventArgs e)
        {
            try
            {
                using var filler = new FieldFiller(this.ExcelFile, this.WordFile, false, this.Mapping);
                this.RememberDocsDirectories();
                var fp = new FolderPicker
                {
                    Title = "Cartella dove salvare i PDF",
                    InputPath = Options.PdfOutputDirectory
                };
                if (fp.ShowDialog(this) == true)
                {
                    var outDir = new DirectoryInfo(fp.ResultPath);
                    Options.PdfOutputDirectory = outDir.FullName;
                    var consumer = new FilledRowConsumer.Saver(new DirectoryInfo(fp.ResultPath));
                    this.Process(consumer, filler);
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(this, x.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbEmailTest_Click(object sender, EventArgs e)
        {
            this.Send(true);
        }

        private void tsbEmailSend_Click(object sender, EventArgs e)
        {
            this.Send(false);
        }

        private void Send(bool test)
        {
            var from = MailService.GetAddressFromString(this.tbxEmailFrom.Text, out string reason);
            if (from == null)
            {
                MessageBox.Show(this, $"Specificare un indirizzo email del mittente valido.{Environment.NewLine}{Environment.NewLine}{reason}", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.tbxEmailFrom.Focus();
                return;
            }
            var cc = MailService.GetAddressesFromList(this.tbxEmailCC.Text, out reason);
            if (cc == null)
            {
                MessageBox.Show(this, $"Specificare un elenco di indirizzi email validi da usare in CC.{Environment.NewLine}{Environment.NewLine}{reason}", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.tbxEmailCC.Focus();
                return;
            }
            Options.MailCc = cc;
            if (this.cbxMailSenderInCc.Checked)
            {
                cc.Add(from);
            }
            var bcc = MailService.GetAddressesFromList(this.tbxEmailBCC.Text, out reason);
            if (bcc == null)
            {
                MessageBox.Show(this, $"Specificare un elenco di indirizzi email validi da usare in CCN.{Environment.NewLine}{Environment.NewLine}{reason}", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.tbxEmailBCC.Focus();
                return;
            }
            Options.MailBcc = bcc;
            if (this.cbxMailSenderInBcc.Checked)
            {
                bcc.Add(from);
            }
            var subject = this.tbxEmailSubject.Text.Trim();
            if (subject.Length == 0)
            {
                MessageBox.Show(this, "Specificare l'oggetto dell'email.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.tbxEmailSubject.Focus();
                return;
            }
            var body = this.tbxEmailBody.Text;
            if (body.Trim().Length == 0)
            {
                MessageBox.Show(this, "Specificare il corpo dell'email.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.tbxEmailBody.Focus();
                return;
            }
            try
            {
                this.RememberDocsDirectories();
                using var mailSender = new MailSender(Options.Smtp);
                using var filler = new FieldFiller(this.ExcelFile, this.WordFile, true, this.Mapping);
                MailboxAddress? overrideRecipient = null;
                int? testExcelDataRow = null;
                if (test)
                {
                    using (var frm = new frmAskTestData(filler.ExcelRange.FirstDataRow, filler.ExcelRange.LastDataRow, frmAskTestData.Reason.SendEmail))
                    {
                        if (frm.ShowDialog(this) == DialogResult.OK && frm.Result != null)
                        {
                            overrideRecipient = frm.Result.Recipient;
                            testExcelDataRow = frm.Result.ExcelDataRow;
                        }
                    }
                    if (overrideRecipient == null)
                    {
                        return;
                    }
                }
                var consumer = new FilledRowConsumer.Mailer(mailSender, from, cc, bcc, subject, body, overrideRecipient, testExcelDataRow);
                this.Process(consumer, filler);
            }
            catch (Exception x)
            {
                MessageBox.Show(this, x.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Process(FilledRowConsumer.IFilledRowConsumer consumer, FieldFiller filler)
        {
            using var form = new frmProcess(consumer, filler);
            form.ShowDialog(this);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (this.ofdExcel.ShowDialog() == DialogResult.OK)
            {
                this.ExcelFile = this.ofdExcel.FileName;
            }
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            if (this.ofdWord.ShowDialog() == DialogResult.OK)
            {
                this.WordFile = this.ofdWord.FileName;
            }
        }

        private void UpdateDocsStatus()
        {
            this.tmrUpdateDocs.Stop();
            this.tbxExcel.Text = AutoEllipsis.Compact(this.ExcelFile, this.tbxExcel, AutoEllipsis.EllipsisFormat.Middle | AutoEllipsis.EllipsisFormat.Path);
            this.ttTip.SetToolTip(this.tbxExcel, this._excelFile);
            this.tbxWord.Text = AutoEllipsis.Compact(this.WordFile, this.tbxWord, AutoEllipsis.EllipsisFormat.Middle | AutoEllipsis.EllipsisFormat.Path);
            this.ttTip.SetToolTip(this.tbxWord, this.WordFile);
            this.tsbEmailSend.Enabled = this.tsbEmailTest.Enabled = this.tsbSavePdf.Enabled = this.tsbSavePdfTest.Enabled = this.tsbMapFields.Enabled = this.ExcelFile != "" && this.WordFile != "";
        }

        private void RememberDocsDirectories()
        {
            DirectoryInfo? di;
            try
            {
                di = Directory.GetParent(this.ExcelFile);
                if (di != null)
                {
                    Options.ExcelFilesDirectory = di.FullName;
                }
            }
            catch { }
            try
            {
                di = Directory.GetParent(this.WordFile);
                if (di != null)
                {
                    Options.WordFilesDirectory = di.FullName;
                }
            }
            catch { }
        }

        private void tbxExcel_Resize(object sender, EventArgs e)
        {
            this.ScheduleUpdateDocsStatus();
        }

        private void tbxWord_Resize(object sender, EventArgs e)
        {
            this.ScheduleUpdateDocsStatus();
        }

        private void ScheduleUpdateDocsStatus()
        {
            this.tmrUpdateDocs.Stop();
            this.tmrUpdateDocs.Start();
        }

        private void tmrUpdateDocs_Tick(object sender, EventArgs e)
        {
            this.tmrUpdateDocs.Stop();
            this.UpdateDocsStatus();
        }

        private void frmMain_DragOver(object sender, DragEventArgs e)
        {
            var droppedFiles = this.ProcessDragDrop(e, true);
            e.Effect = droppedFiles == null ? DragDropEffects.Link : DragDropEffects.Copy;
        }

        private void frmMain_DragDrop(object sender, DragEventArgs e)
        {
            var droppedFiles = this.ProcessDragDrop(e, false);
            if (droppedFiles == null)
            {
                return;
            }
            if (droppedFiles.xls != null)
            {
                this.ExcelFile = droppedFiles.xls.FullName;
            }
            if (droppedFiles.doc != null)
            {
                this.WordFile = droppedFiles.doc.FullName;
            }
            this.Focus();
        }

        private DroppedFiles? ProcessDragDrop(DragEventArgs e, bool justFeedback)
        {
            string[]? files = e.Data == null ? null : e.Data.GetData(DataFormats.FileDrop, true) as string[];
            if (files == null || files.Length == 0)
            {
                return null;
            }
            if (files.Length > 2)
            {
                if (!justFeedback)
                {
                    MessageBox.Show(this, "Trascinare al pi? due file (un foglio di Excel e/o un documento di Word).", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return null;
            }
            var result = new DroppedFiles();
            if (justFeedback)
            {
                return result;
            }
            try
            {
                foreach (var file in files)
                {
                    var di = new DirectoryInfo(file);
                    if (di.Exists)
                    {
                        if (files.Length != 1)
                        {
                            MessageBox.Show(this, $"Trascinare una sola cartella, oppure uno o due file", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return null;
                        }
                        return this.ProcessDragDrop(di, result) ? result : null;
                    }
                    var fi = new FileInfo(file);
                    if (fi.Exists)
                    {
                        if (!this.ProcessDragDrop(fi, result, false))
                        {
                            return null;
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, $"Impossibile trovare il file {file}", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return null;
                    }
                }
                return result;
            }
            catch (Exception x)
            {
                MessageBox.Show(this, x.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        private bool ProcessDragDrop(DirectoryInfo directory, DroppedFiles result)
        {
            foreach (var file in directory.GetFiles())
            {
                if (!this.ProcessDragDrop(file, result, true))
                {
                    return false;
                }
            }
            if (result.xls != null && result.doc != null)
            {
                return true;
            }
            foreach (var subDirectory in directory.GetDirectories())
            {
                if (!this.ProcessDragDrop(subDirectory, result))
                {
                    return false;
                }
                if (result.xls != null && result.doc != null)
                {
                    return true;
                }
            }
            return true;
        }

        private bool ProcessDragDrop(FileInfo file, DroppedFiles result, bool ignoreUnrecognized)
        {
            try
            {
                var attrs = file.Attributes;
                if (attrs.HasFlag(FileAttributes.Hidden) || attrs.HasFlag(FileAttributes.System))
                {
                    return true;
                }
            }
            catch { }
            var ext = file.Extension.ToLowerInvariant();
            switch (ext)
            {
                case ".xlsx":
                case ".xlsm":
                    if (result.xls != null)
                    {
                        MessageBox.Show(this, "Trascinare un solo foglio di Excel.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else
                    {
                        result.xls = file;
                    }
                    break;

                case ".docx":
                case ".docm":
                    if (result.doc != null)
                    {
                        MessageBox.Show(this, "Trascinare un solo documento di Word.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    result.doc = file;
                    break;

                default:
                    if (ignoreUnrecognized)
                    {
                        return true;
                    }
                    MessageBox.Show(this, $"Il file {file.FullName} non è né un foglio di Excel né un documento di Word.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
            }
            return true;
        }

        private void tsbHelp_Click(object sender, EventArgs e)
        {
            foreach (var form in this.OwnedForms)
            {
                if (form as frmHelp != null)
                {
                    form.Show();
                    if (form.WindowState == FormWindowState.Minimized)
                    {
                        form.WindowState = FormWindowState.Normal;
                    }
                    form.Focus();
                    return;
                }
            }
            new frmHelp().Show(this);
        }

        private void tsbAutoupdate_Click(object sender, EventArgs e)
        {
            if (Program.Version == null)
            {
                MessageBox.Show(this, $"Non è stato possibile rilevare la versione del programma in esecuzione.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using var form = new frmUpdater(Program.Version);
            form.ShowDialog(this);
        }

        private void frmMain_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    if (e.Modifiers == Keys.None && this.tsbHelp.Enabled && this.tsbHelp.Visible)
                    {
                        this.tsbHelp_Click(sender, e);
                        e.SuppressKeyPress = true;
                    }
                    break;

                case Keys.F4:
                    if (e.Modifiers == Keys.None && this.tsbOptions.Enabled && this.tsbOptions.Visible)
                    {
                        this.tsbOptions_Click(sender, e);
                        e.SuppressKeyPress = true;
                    }
                    break;
            }
        }

        private void cbxMailSenderInCc_CheckedChanged(object sender, EventArgs e)
        {
            Options.MailSenderInCc = this.cbxMailSenderInCc.Checked;
        }

        private void cbxMailSenderInBcc_CheckedChanged(object sender, EventArgs e)
        {
            Options.MailSenderInBcc = this.cbxMailSenderInBcc.Checked;
        }
    }
}