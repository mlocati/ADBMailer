using MimeKit;

namespace ADBMailer.FilledRowConsumer
{
    internal class Mailer : IFilledRowConsumer
    {
        private readonly MailSender MailSender;
        private readonly MailboxAddress From;
        private readonly List<MailboxAddress> CC;
        private readonly List<MailboxAddress> BCC;
        private readonly String Subject;
        private readonly String Body;
        private readonly MailboxAddress? ForceRecipient;
        public readonly int? ForceDataRow;

        int? IFilledRowConsumer.ForceDataRow => this.ForceDataRow;

        public bool UseRecipients => true;

        public bool GeneratesPermamentFiles => false;

        public bool UsePDFFilename => true;

        public string ProcessingWindowTitle => "Invio email";

        public Mailer(MailSender mailSender, MailboxAddress from, List<MailboxAddress> cc, List<MailboxAddress> bcc, string subject, string body, MailboxAddress? forceRecipient, int? forceDataRow)
        {
            this.MailSender = mailSender;
            this.From = from;
            this.CC = cc;
            this.BCC = bcc;
            this.Subject = subject;
            this.Body = body;
            this.ForceRecipient = forceRecipient;
            this.ForceDataRow = forceDataRow;
        }

        public IFilledRowConsumer.Result Process(FieldFiller.Result filled, byte[] pdfBytes, IFilledRowConsumer.StatusAdvancer statusAdvancer)
        {
            statusAdvancer("Creazione messaggio...");
            var message = new MimeMessage();
            message.From.Add(this.From);
            foreach (var cc in this.CC)
            {
                message.Cc.Add(cc);
            }
            foreach (var bcc in this.BCC)
            {
                message.Bcc.Add(bcc);
            }
            message.Subject = this.Subject;
            var builder = new BodyBuilder
            {
                TextBody = this.Body
            };
            builder.Attachments.Add(PDFFileName.BuildPDFFileName(filled, false, true), pdfBytes, ContentType.Parse("application/pdf"));
            message.Body = builder.ToMessageBody();
            if (this.ForceRecipient != null)
            {
                message.To.Add(this.ForceRecipient);
            }
            else
            {
                message.To.AddRange(filled.Recipients);
            }
            statusAdvancer("Invio messaggio...");
            this.MailSender.Send(message);
            statusAdvancer("Messaggio inviato a " + message.To.ToString());
            return new IFilledRowConsumer.Result();
        }
    }
}