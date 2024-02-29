using MimeKit;

namespace ADBMailer
{
    internal class MailService
    {
        public static MailboxAddress? GetAddressFromString(string? rawAddress)
        {
            return GetAddressFromString(rawAddress, out _);
        }

        public static MailboxAddress? GetAddressFromString(string? rawAddress, out string reason)
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

        public static MailboxAddressList? GetAddressesFromList(string? rawAddresses)
        {
            return GetAddressesFromList(rawAddresses, out _);
        }

        public static MailboxAddressList? GetAddressesFromList(string? rawAddresses, out string reason)
        {
            reason = "";
            rawAddresses = rawAddresses?.Trim();
            MailboxAddressList result = new();
            if (string.IsNullOrEmpty(rawAddresses))
            {
                return result;
            }
            var options = new ParserOptions
            {
                AllowAddressesWithoutDomain = false,
            };
            try
            {
                var internetAddresses = InternetAddressList.Parse(options, rawAddresses);
                foreach (var internetAddress in internetAddresses)
                {
                    if (internetAddress is not MailboxAddress address)
                    {
                        reason = $"{internetAddress} non è un indirizzo email valido";
                        return null;
                    }
                    if (!address.Domain.Contains('.'))
                    {
                        reason = "Specificare il nome completo del dominio";
                        return null;
                    }
                    result.Add(address);
                }
                return result;
            }
            catch (Exception x)
            {
                reason = x.Message;
                return null;
            }
        }
    }
}