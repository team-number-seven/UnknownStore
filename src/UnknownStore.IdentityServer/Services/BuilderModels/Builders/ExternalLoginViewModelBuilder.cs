using Microsoft.AspNetCore.Identity;
using UnknownStore.IdentityServer.Common.IdentityModels;

namespace UnknownStore.IdentityServer.Services.BuilderModels.Builders
{
    public class ExternalLoginViewModelBuilder
    {
        public ExternalLoginViewModel Build(string returnUrl, ExternalLoginInfo externalLogin, string username = null)
        {
            return new ExternalLoginViewModel
                { ReturnUrl = returnUrl, ExternalLoginInfo = externalLogin, Username = username };
        }
    }
}