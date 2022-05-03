using UnknownStore.IdentityServer.Services.BuilderModels.Builders;

namespace UnknownStore.IdentityServer.Services.BuilderModels
{
    public class ModelsBuilder
    {
        public LoginViewModelBuilder LoginViewModelBuilder => new();
        public ConfirmationEmailBuilder ConfirmationEmailBuilder => new();
        public RegisterViewModelBuilder RegisterViewModelBuilder => new();
        public ExternalLoginViewModelBuilder ExternalLoginViewModelBuilder => new();
    }
}