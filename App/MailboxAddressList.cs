using MimeKit;

namespace ADBMailer
{
    internal class MailboxAddressList : List<MailboxAddress>
    {
        public new string ToString()
        {
            if (this.Count == 0)
            {
                return "";
            }
            InternetAddressList internetAddresses = new InternetAddressList();
            foreach (MailboxAddress address in this)
            {
                internetAddresses.Add(address);
            }
            return internetAddresses.ToString();
        }
    }
}