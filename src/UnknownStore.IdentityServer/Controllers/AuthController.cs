using System;
using System.Text;
using System.Threading.Tasks;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using UnknownStore.DAL.Entities.Identity;
using UnknownStore.IdentityServer.Common.IdentityModels;
using UnknownStore.IdentityServer.Common.Options;
using UnknownStore.IdentityServer.Services.Email;

namespace UnknownStore.IdentityServer.Controllers
{
    [Controller]
    public class AuthController : Controller
    {
        private readonly IClientStore _clientStore;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        private readonly IEventService _events;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly ConfirmAndDeclineUrlOptions _optionsUrlOptions;
        private readonly IAuthenticationSchemeProvider _schemeProvider;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AuthController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IIdentityServerInteractionService interaction,
            IClientStore clientStore,
            IAuthenticationSchemeProvider schemeProvider,
            IEventService events,
            IEmailService emailService,
            IConfiguration configuration,
            IOptions<ConfirmAndDeclineUrlOptions> optionsUrlConfiguration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _interaction = interaction;
            _clientStore = clientStore;
            _schemeProvider = schemeProvider;
            _events = events;
            _emailService = emailService;
            _configuration = configuration;
            _optionsUrlOptions = optionsUrlConfiguration.Value;
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
                var user = await _userManager.FindByEmailAsync(model.Email);
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, true);
                if (result.Succeeded) return Redirect(model.ReturnUrl);
            }

            ModelState.AddModelError(string.Empty, "Invalid email or password");
            var vm = await BuildLoginViewModelAsync(model.ReturnUrl);
            vm.Password = model.Password;
            vm.Email = model.Email;
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Register(string returnUrl)
        {
            return View(new RegisterViewModel{ReturnUrl = returnUrl});
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

                var user = new User
                    {Id = Guid.NewGuid(), Email = model.Email, PhoneNumber = model.PhoneNumber, EmailConfirmed = false,UserName = model.Username};
                var result = await _userManager.CreateAsync(user, model.Password);
                
                await _userManager.AddToRoleAsync(user, "User");

                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                var urlConfirm = Url.Action(new UrlActionContext
                {
                    Action = _optionsUrlOptions.ActionConfirm,
                    Controller = _optionsUrlOptions.Controller,
                    Host = _optionsUrlOptions.Host,
                    Protocol = _optionsUrlOptions.Scheme,
                    Values = new {userId = user.Id, tokenConfirmation = token, returnUrl = model.ReturnUrl }
                });
                var urlDecline = Url.Action(new UrlActionContext
                {
                    Action = _optionsUrlOptions.ActionDecline,
                    Controller = _optionsUrlOptions.Controller,
                    Host = _optionsUrlOptions.Host,
                    Protocol = _optionsUrlOptions.Scheme,
                    Values = new {userId = user.Id, tokenConfirmation = token,returnUrl = model.ReturnUrl}
                });
                var body = await CreateFormAsync(urlConfirm, urlDecline);

                await _emailService.SendEmailAsync(user.Email, user.UserName, "Email confirmation", body);
                var lvm = new LoginViewModel {ReturnUrl = model.ReturnUrl};
                return View(nameof(Login), lvm);
            }

            return View(rm);
        }

        private async Task<string> CreateFormAsync(string urlConfirm, string urlDecline, string pathForm = null)
        {
            var htmlForm =
                new StringBuilder(await System.IO.File.ReadAllTextAsync(
                    @"D:\GitHub\UnknownStore\src\UnknownStore.IdentityServer\Common\HTML\EmailConfirmation.html"));
            htmlForm.Replace(_configuration["EmailHtmlFormMessage:ReplaceConfirm"], urlConfirm);
            htmlForm.Replace(_configuration["EmailHtmlFormMessage:ReplaceDecline"], urlConfirm);

            return htmlForm.ToString();
        }

        private async Task<LoginViewModel> BuildLoginViewModelAsync(string returnUrl)
        {
            return new LoginViewModel {ReturnUrl = returnUrl};
        }


        [AllowAnonymous]
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string userId, [FromQuery] string tokenConfirmation, [FromQuery] string returnUrl)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return View("_NotFound");
            if (user.EmailConfirmed) return Redirect(returnUrl);

            var result = await _userManager.ConfirmEmailAsync(user, tokenConfirmation);
            if (result.Succeeded)
                return Redirect(returnUrl);
            return View("_NotFound");
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("[action]")]
        public async Task<IActionResult> DeclineEmail([FromQuery] string userId, [FromQuery] string tokenConfirmation, [FromQuery] string returnUrl)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return View("_NotFound");
            var isVerifyUserToken = await _userManager.VerifyUserTokenAsync(user,
                _userManager.Options.Tokens.EmailConfirmationTokenProvider, "EmailConfirmation",
                tokenConfirmation);
            if (isVerifyUserToken)
            {
                var result = await _userManager.DeleteAsync(user); //email deleted 
                return Redirect(returnUrl);
            }

            return View("_NotFound");
        }
    }
}