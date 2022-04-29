using System.ComponentModel.DataAnnotations;

namespace UnknownStore.IdentityServer.Common.IdentityModels
{
    public class LoginViewModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email required")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }

        public bool IsRemember { get; set; }

        public string ReturnUrl { get; set; }
    }
}