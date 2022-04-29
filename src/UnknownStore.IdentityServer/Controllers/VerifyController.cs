using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UnknownStore.DAL.Entities.Identity;
using UnknownStore.IdentityServer.Common;
using UnknownStore.IdentityServer.Common.IdentityModels;

namespace UnknownStore.IdentityServer.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    public class VerifyController : Controller
    {
        private readonly UserManager<User> _userManager;

        public VerifyController(
            UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> DeclineEmail([FromQuery] ConfirmationEmail model)
        {
            if (StringHelper.HasNullOrEmptyStrings(model.UserId, model.ReturnUrl, model.TokenConfirmation))
                return View("_NotFound");

            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user is null) return View("_NotFound");

            var isVerifyUserToken = await _userManager.VerifyUserTokenAsync(user,
                _userManager.Options.Tokens.EmailConfirmationTokenProvider, "EmailConfirmation",
                model.TokenConfirmation);
            if (isVerifyUserToken is false) return View("_NotFound");

            await _userManager.DeleteAsync(user);

            return Redirect(model.ReturnUrl);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmationEmail model)
        {
            if (StringHelper.HasNullOrEmptyStrings(model.UserId, model.ReturnUrl, model.TokenConfirmation))
                return View("_NotFound");

            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null) return View("_NotFound");

            if (user.EmailConfirmed) return Redirect(model.ReturnUrl);

            var result = await _userManager.ConfirmEmailAsync(user, model.TokenConfirmation);
            if (result.Succeeded) return Redirect(model.ReturnUrl);

            return View("_NotFound");
        }
    }
}