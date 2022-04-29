using Microsoft.AspNetCore.Mvc;

namespace UnknownStore.IdentityServer.Common.IdentityModels
{
    public class ConfirmationEmail
    {
        [FromQuery] public string UserId { get; set; }

        [FromQuery] public string TokenConfirmation { get; set; }

        [FromQuery] public string ReturnUrl { get; set; }
    }
}