using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace UnknownStore.IdentityServer.Common.IdentityModels
{
    public class RegisterViewModel
    {
        [Remote("ValidationUsername", "Validation", AdditionalFields = nameof(Username))]
        [Required(ErrorMessage = "Username required")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

        [EmailAddress]
        [Remote("ValidationEmail", "Validation", AdditionalFields = nameof(Email))]
        [Required(ErrorMessage = "Email required")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm password required")]
        [Compare(nameof(Password), ErrorMessage = "Passwords must match")]
        public string ConfirmPassword { get; set; }
    }
}