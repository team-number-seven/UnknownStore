namespace UnknownStore.IdentityServer.Common.Options
{
    public class ConfirmAndDeclineUrlOptions
    {
        public string Controller { get; set; }
        public string ActionConfirm { get; set; }
        public string ActionDecline { get; set; }
        public string Host { get; set; }
        public string Scheme { get; set; }
    }
}