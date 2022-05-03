using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UnknownStore.IdentityServer.Common.IdentityModels
{
    public class ExternalLoginViewModel
    {
        [Remote("ValidationUsername", "Validation", AdditionalFields = nameof(Username))]
        [Required]
        public string Username { get; set; }

        [Required] public string ReturnUrl { get; set; }

        public ExternalLoginInfo ExternalLoginInfo { get; set; }
    }
}