namespace UnknownStore.IdentityServer.Common.Options
{
    public class ConfirmAndDeclineUrlOptions
    {
        public string ConfirmAction { get; set; }
        public string DeclineAction { get; set; }
        public string Controller { get; set; }
        public string Host { get; set; }
        public string Scheme { get; set; }
    }
}