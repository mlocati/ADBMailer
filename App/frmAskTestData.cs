using MimeKit;

namespace ADBMailer
{
    public partial class frmAskTestData : Form
    {
        public enum Reason
        {
            SendEmail,
            ViewPDF,
        }

        public class UserResult
        {
            public readonly int ExcelDataRow;
            public readonly MailboxAddress? Recipient;

            public UserResult(int excelDataRow, MailboxAddress? recipient)
            {
                this.ExcelDataRow = excelDataRow;
                this.Recipient = recipient;
            }
        }

        public UserResult? Result = null;
        private readonly bool AskRecipient;

        public frmAskTestData(int firstExcelDataRow, int lastExcelDataRow, Reason reason)
        {
            InitializeComponent();
            if (Program.ExeIcon != null)
            {
                this.Icon = Program.ExeIcon;
            }
            switch (reason)
            {
                case Reason.SendEmail:
                    this.Text = "ADBMailer - Invio email di prova";
                    break;

                case Reason.ViewPDF:
                    this.Text = "ADBMailer - Vedi PDF";
                    break;
            }
            this.AskRecipient = reason == Reason.SendEmail;
            this.nudExcelRow.Minimum = decimal.MinValue;
            this.nudExcelRow.Maximum = decimal.MaxValue;
            this.nudExcelRow.Value = firstExcelDataRow;
            this.nudExcelRow.Minimum = firstExcelDataRow;
            this.nudExcelRow.Maximum = lastExcelDataRow;
            if (this.AskRecipient)
            {
                var prev = Options.LastTestRecipient;
                if (prev != null)
                {
                    this.tbxRecipient.Text = prev.ToString();
                }
            }
            else
            {
                this.tbxRecipient.Visible = this.lblRecipient.Visible = false;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            MailboxAddress? recipient;
            if (this.AskRecipient)
            {
                var rawRecipient = this.tbxRecipient.Text.Trim();
                if (rawRecipient.Length == 0)
                {
                    MessageBox.Show(this, "Specificare il destinatario cui inviare l'email di prova.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.tbxRecipient.Focus();
                    return;
                }
                recipient = MailService.GetAddressFromString(rawRecipient, out string reason);
                if (recipient == null)
                {
                    MessageBox.Show(this, $"Il destinatario dell'email di prova non è valido:{Environment.NewLine}{reason}", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.tbxRecipient.Focus();
                    return;
                }
            }
            else
            {
                recipient = null;
            }
            Options.LastTestRecipient = recipient;
            this.Result = new UserResult((int)this.nudExcelRow.Value, recipient);
            this.DialogResult = DialogResult.OK;
        }
    }
}