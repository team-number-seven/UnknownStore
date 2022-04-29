using System;
using System.Text;
using System.Threading.Tasks;
using IdentityServer4.Models;
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
using UnknownStore.IdentityServer.Services.BuilderModels;
using UnknownStore.IdentityServer.Services.Email;

namespace UnknownStore.IdentityServer.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly ModelsBuilder _modelsBuilder;
        private readonly ConfirmAndDeclineUrlOptions _optionsUrlOptions;
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
            IOptions<ConfirmAndDeclineUrlOptions> optionsUrlConfiguration,
            ModelsBuilder modelsBuilder)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _interaction = interaction;
            _emailService = emailService;
            _configuration = configuration;
            _modelsBuilder = modelsBuilder;
            _optionsUrlOptions = optionsUrlConfiguration.Value;
        }


        [Route("[action]")]
        [HttpGet]
        public Task<IActionResult> Login([FromQuery] string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl)) return Task.FromResult<IActionResult>(View("_NotFound"));

            var loginViewModel = _modelsBuilder.LoginViewModelBuilder.Build(returnUrl);
            return Task.FromResult<IActionResult>(View(loginViewModel));
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var context = await _interaction.GetAuthorizationContextAsync(model.ReturnUrl);
            var loginViewModel =
                _modelsBuilder.LoginViewModelBuilder.Build(model.ReturnUrl, model.IsRemember, model.Email);
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user is null)
                {
                    await _interaction.DenyAuthorizationAsync(context, AuthorizationError.AccessDenied);
                    ModelState.AddModelError(string.Empty, "Invalid email or password");
                    return View(loginViewModel);
                }

                var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.IsRemember, true);
                if (result.Succeeded) return Redirect(model.ReturnUrl);
            }

            await _interaction.DenyAuthorizationAsync(context, AuthorizationError.AccessDenied);
            ModelState.AddModelError(string.Empty, "Invalid email or password");
            return View(loginViewModel);
        }

        [Route("[action]")]
        [HttpGet]
        public Task<IActionResult> Register(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl)) return Task.FromResult<IActionResult>(View("_NotFound"));

            var registerViewModel = _modelsBuilder.RegisterViewModelBuilder.Build(returnUrl);
            return Task.FromResult<IActionResult>(View(registerViewModel));
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var registerViewModel =
                _modelsBuilder.RegisterViewModelBuilder.Build(model.ReturnUrl, model.Email, model.Username,
                    model.PhoneNumber);
            if (ModelState.IsValid is false) return View(registerViewModel);

            if (await _userManager.FindByEmailAsync(model.Email) is not null)
            {
                ModelState.AddModelError(string.Empty, "Email has already been registered");
                return View(registerViewModel);
            }

            if (await _userManager.FindByNameAsync(model.Username) is not null)
            {
                ModelState.AddModelError(string.Empty, "Username has already been registered");
                return View(registerViewModel);
            }

            var user = new User
            {
                Id = Guid.NewGuid(), Email = model.Email, PhoneNumber = model.PhoneNumber, EmailConfirmed = false,
                UserName = model.Username
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded is false)
            {
                foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error.Description);

                return View(registerViewModel);
            }

            await _userManager.AddToRoleAsync(user, "User");

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var urlConfirm = BuildConfirmEmailUrl(new
                {userId = user.Id, tokenConfirmation = token, returnUrl = model.ReturnUrl});
            var urlDecline = BuildDeclineEmailUrl(new
                {userId = user.Id, tokenConfirmation = token, returnUrl = model.ReturnUrl});
            var body = await CreateFormAsync(urlConfirm, urlDecline);
            await _emailService.SendEmailAsync(user.Email, user.UserName, "Email confirmation", body);

            var loginViewModel = new LoginViewModel {ReturnUrl = model.ReturnUrl};
            return View(nameof(Login), loginViewModel);
        }

        private async Task<string> CreateFormAsync(string urlConfirm, string urlDecline, string pathForm = null)
        {
            var htmlForm =
                new StringBuilder(await System.IO.File.ReadAllTextAsync(
                    @"D:\GitHub\UnknownStore\src\UnknownStore.IdentityServer\Common\HTML\EmailConfirmation.html"));
            htmlForm.Replace(_configuration["EmailHtmlFormMessage:ReplaceConfirm"], urlConfirm);
            htmlForm.Replace(_configuration["EmailHtmlFormMessage:ReplaceDecline"], urlDecline);

            return htmlForm.ToString();
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> Logout(string logoutId)
        {
            if (string.IsNullOrEmpty(logoutId)) return View("_NotFound");
            await _signInManager.SignOutAsync();
            var logoutResult = await _interaction.GetLogoutContextAsync(logoutId);
            return Redirect(logoutResult.PostLogoutRedirectUri);
        }

        private string BuildConfirmEmailUrl(object values)
        {
            return Url.Action(new UrlActionContext
            {
                Action = _optionsUrlOptions.ConfirmAction,
                Controller = _optionsUrlOptions.Controller,
                Host = _optionsUrlOptions.Host,
                Protocol = _optionsUrlOptions.Scheme,
                Values = values
            });
        }

        private string BuildDeclineEmailUrl(object values)
        {
            return Url.Action(new UrlActionContext
            {
                Action = _optionsUrlOptions.DeclineAction,
                Controller = _optionsUrlOptions.Controller,
                Host = _optionsUrlOptions.Host,
                Protocol = _optionsUrlOptions.Scheme,
                Values = values
            });
        }
    }
}