using System.Threading.Tasks;
using MailKit.Security;

namespace UnknownStore.IdentityServer.Services.GoogleClientSenderClientSender
{
    public interface IGoogleClientSenderService
    {
        public Task<SaslMechanismOAuth2> AuthorizationAsync();
    }
}