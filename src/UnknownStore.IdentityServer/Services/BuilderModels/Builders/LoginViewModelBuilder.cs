#nullable enable
using UnknownStore.IdentityServer.Common.IdentityModels;

namespace UnknownStore.IdentityServer.Services.BuilderModels.Builders
{
    public class LoginViewModelBuilder
    {
        public LoginViewModel Build(string returnUrl, bool isRemember = false, string? email = null,
            string? password = null)
        {
            return new LoginViewModel {Email = email, Password = password, ReturnUrl = returnUrl};
        }
    }
}