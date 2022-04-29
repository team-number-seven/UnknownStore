using System.Diagnostics.CodeAnalysis;
using UnknownStore.IdentityServer.Common.IdentityModels;

namespace UnknownStore.IdentityServer.Services.BuilderModels.Builders
{
    public class ConfirmationEmailBuilder
    {
        public ConfirmationEmail Build([NotNull] string returnUrl, [NotNull] string tokenConfirmation,
            [NotNull] string userId)
        {
            return new ConfirmationEmail
                {ReturnUrl = returnUrl, TokenConfirmation = tokenConfirmation, UserId = userId};
        }
    }
}