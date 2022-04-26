using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace UnknownStore.Common.IdentityModels
{
    public class RegisterViewModel
    {
        [EmailAddress]
        [Remote("VerifyUsername", "Verify", AdditionalFields = nameof(Username))]
        [Required(ErrorMessage = "Username required")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

        [Remote("VerifyEmail", "Verify", AdditionalFields = nameof(Email))]
        [Required(ErrorMessage = "Email required")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "ConfirmPassword required")]
        [Compare(nameof(Password), ErrorMessage = "Passwords must match")]
        public string ConfirmPassword { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
    }
}