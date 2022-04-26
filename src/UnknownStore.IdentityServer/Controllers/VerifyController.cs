using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UnknownStore.DAL.Entities.Identity;

namespace UnknownStore.IdentityServer.Controllers
{
    [Controller]
    public class VerifyController:Controller
    {
        private readonly UserManager<User> _userManager;

        public VerifyController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> VerifyEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email) is not null
                ? Json($"A email {email} already exists.")
                : Json(true);
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> VerifyUsername(string username)
        {
            return await _userManager.FindByNameAsync(username) is not null
                ? Json($"A username {username} already exists.")
                : Json(true);
        }
    }
}
