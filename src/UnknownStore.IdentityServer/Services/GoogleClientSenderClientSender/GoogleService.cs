using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using UnknownStore.IdentityServer.Common.Options;

namespace UnknownStore.IdentityServer.Services.GoogleClientSenderClientSender
{
    public class GoogleService : IGoogleService
    {
        private readonly GoogleClientSenderServiceOptions _googleAuthenticationOptions;
        private readonly ILogger<GoogleService> _logger;

        public GoogleService(IOptions<GoogleClientSenderServiceOptions> googleOptions,
            ILogger<GoogleService> logger)
        {
            _logger = logger;
            _googleAuthenticationOptions = googleOptions.Value;
        }

        public async Task<SaslMechanismOAuth2> AuthorizationAsync()
        {
            var secrets = new ClientSecrets
            {
                ClientId = _googleAuthenticationOptions.ClientId,
                ClientSecret = _googleAuthenticationOptions.ClientSecret
            };
            var tokenResponse = new TokenResponse
            {
                RefreshToken = _googleAuthenticationOptions.RefreshToken
            };
            var userCredential = new UserCredential(new GoogleAuthorizationCodeFlow(
                new GoogleAuthorizationCodeFlow.Initializer
                {
                    ClientSecrets = secrets
                }), _googleAuthenticationOptions.UserId, tokenResponse);
            await userCredential.GetAccessTokenForRequestAsync();

            return new SaslMechanismOAuth2(userCredential.UserId, userCredential.Token.AccessToken);
        }
    }
}