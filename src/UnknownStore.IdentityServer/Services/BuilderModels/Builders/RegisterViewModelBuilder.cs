#nullable enable
using System.Diagnostics.CodeAnalysis;
using UnknownStore.IdentityServer.Common.IdentityModels;

namespace UnknownStore.IdentityServer.Services.BuilderModels.Builders
{
    public class RegisterViewModelBuilder
    {
        public RegisterViewModel Build([NotNull] string returnUrl, string? email = null, string? password = null, string? username = null, string? confirmPassword = null)
        {
            return new RegisterViewModel
            {
                Email = email, Password = password, ReturnUrl = returnUrl, ConfirmPassword = confirmPassword,
                Username = username
            };
        }
    }
}