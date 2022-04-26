using System.ComponentModel.DataAnnotations;

namespace UnknownStore.Common.IdentityModels
{
    public class LoginViewModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "Username required")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}