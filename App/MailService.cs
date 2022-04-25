using MimeKit;

namespace ADBMailer
{
    internal class MailService
    {
        public static MailboxAddress? ParseString(string? rawAddress)
        {
            return ParseString(rawAddress, out _);
        }

        public static MailboxAddress? ParseString(string? rawAddress, out string reason)
        {
            rawAddress = rawAddress?.Trim();
            if (string.IsNullOrEmpty(rawAddress))
            {
                reason = "L'indirizzo email è vuoto";
                return null;
            }
            var options = new ParserOptions
            {
                AllowAddressesWithoutDomain = false,
            };
            try
            {
                reason = "";
                var address = MailboxAddress.Parse(options, rawAddress);
                if (!address.Domain.Contains('.'))
                {
                    reason = "Specificare il nome completo del dominio";
                    return null;
                }
                return address;
            }
            catch (Exception x)
            {
                reason = x.Message;
                return null;
            }
        }
    }
}