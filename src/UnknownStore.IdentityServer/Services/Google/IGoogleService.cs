using System.Threading.Tasks;
using MailKit.Security;

namespace UnknownStore.IdentityServer.Services.Google
{
    public interface IGoogleService
    {
        public Task<SaslMechanismOAuth2> AuthorizationAsync();
    }
}