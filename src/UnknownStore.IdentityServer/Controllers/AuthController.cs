using System.Threading.Tasks;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UnknownStore.Common.IdentityModels;
using UnknownStore.DAL.Entities.Identity;

namespace UnknownStore.IdentityServer.Controllers
{
    [Controller]
    public class AuthController : Controller
    {
        private readonly IClientStore _clientStore;
        private readonly IEventService _events;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IAuthenticationSchemeProvider _schemeProvider;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AuthController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IIdentityServerInteractionService interaction,
            IClientStore clientStore,
            IAuthenticationSchemeProvider schemeProvider,
            IEventService events)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _interaction = interaction;
            _clientStore = clientStore;
            _schemeProvider = schemeProvider;
            _events = events;
        }


        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            var vm = await BuildLoginViewModelAsync(returnUrl);

            return View(vm);
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, true, true);
                if (result.Succeeded) return Redirect(model.ReturnUrl);
            }

            ModelState.AddModelError(string.Empty, "Invalid password or login");
            var vm = await BuildLoginViewModelAsync(model.ReturnUrl);
            vm.Password = model.Password;
            vm.Username = model.Username;
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Register(string returnUrl)
        {
            return View(returnUrl);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var rm = new RegisterViewModel
            {
                Email = model.Email, PhoneNumber = model.PhoneNumber, ReturnUrl = model.ReturnUrl,
                Username = model.Username
            };
            if (ModelState.IsValid)
            {
                if (await _userManager.FindByEmailAsync(model.Email) is not null)
                {
                    ModelState.AddModelError(string.Empty, "Email has already been registered");
                    return View(rm);
                }

                if (await _userManager.FindByNameAsync(model.Username) is not null)
                {
                    ModelState.AddModelError(string.Empty, "Username has already been registered");
                    return View(rm);
                }

                var user = new User {Email = model.Email, PhoneNumber = model.PhoneNumber, EmailConfirmed = false};
                var result = await _userManager.CreateAsync(user, model.Password);
                await _userManager.AddToRoleAsync(user, "User");
                return Redirect(model.ReturnUrl);
            }

            return View(rm);
        }

        private async Task<LoginViewModel> BuildLoginViewModelAsync(string returnUrl)
        {
            return new LoginViewModel {ReturnUrl = returnUrl};
        }

    }
}