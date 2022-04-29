using MailKit.Security;

namespace UnknownStore.IdentityServer.Common.Options
{
    public class EmailServiceOptions
    {
        public string MailServerAddress { get; set; }
        public int MailServerPort { get; set; }
        public string FromName { get; set; }
        public string FromAddress { get; set; }
        public SecureSocketOptions SecureSocket { get; set; }
    }
}