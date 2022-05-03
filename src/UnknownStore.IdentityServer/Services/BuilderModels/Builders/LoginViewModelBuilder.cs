#nullable enable
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using UnknownStore.IdentityServer.Common.IdentityModels;

namespace UnknownStore.IdentityServer.Services.BuilderModels.Builders
{
    public class LoginViewModelBuilder
    {
        public LoginViewModel Build(string returnUrl, IEnumerable<AuthenticationScheme> externalLogin,
            bool isRemember = false, string? email = null,
            string? password = null)
        {
            return new LoginViewModel
                { Email = email, Password = password, ReturnUrl = returnUrl, ExternalProviders = externalLogin };
        }
    }
}