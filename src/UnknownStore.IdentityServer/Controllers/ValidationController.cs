using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UnknownStore.DAL.Entities.Identity;

namespace UnknownStore.IdentityServer.Controllers
{
    [AllowAnonymous]
    public class ValidationController : Controller
    {
        private readonly UserManager<User> _userManager;

        public ValidationController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> ValidationEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email) is not null
                ? Json($"A email {email} already exists.")
                : Json(true);
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult ValidationUsername(string username)
        {
            return username.Contains('|') ? Json($"{username} contains invalid characters") : Json(true);
        }
    }
}