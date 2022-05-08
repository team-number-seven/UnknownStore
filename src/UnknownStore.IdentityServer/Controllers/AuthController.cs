using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<AuthController> _logger;
        private readonly ModelsBuilder _modelsBuilder;
        private readonly ConfirmAndDeclineUrlOptions _optionsUrlOptions;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AuthController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IIdentityServerInteractionService interaction,
            IEmailService emailService,
            IConfiguration configuration,
            IOptions<ConfirmAndDeclineUrlOptions> optionsUrlConfiguration,
            ModelsBuilder modelsBuilder,
            RoleManager<Role> roleManager, ILogger<AuthController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _interaction = interaction;
            _emailService = emailService;
            _configuration = configuration;
            _modelsBuilder = modelsBuilder;
            _roleManager = roleManager;
            _logger = logger;
            _optionsUrlOptions = optionsUrlConfiguration.Value;
            _logger.LogInformation(_configuration["CurrentDirectory"]);
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> Login([FromQuery] string returnUrl)
        {
            var externalProviders = await _signInManager.GetExternalAuthenticationSchemesAsync();
            if (string.IsNullOrEmpty(returnUrl)) return View("_NotFound");
            var loginViewModel = _modelsBuilder.LoginViewModelBuilder.Build(returnUrl, externalProviders);
            return View(loginViewModel);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            model.ExternalProviders = await _signInManager.GetExternalAuthenticationSchemesAsync();
            var context = await _interaction.GetAuthorizationContextAsync(model.ReturnUrl);
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user is null)
                {
                    await _interaction.DenyAuthorizationAsync(context, AuthorizationError.AccessDenied);
                    ModelState.AddModelError(string.Empty, "Invalid email or password");
                    model.Password = string.Empty;
                    return View(model);
                }

                var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.IsRemember, true);
                if (result.Succeeded) return Redirect(model.ReturnUrl);
            }

            await _interaction.DenyAuthorizationAsync(context, AuthorizationError.AccessDenied);
            ModelState.AddModelError(string.Empty, "Invalid email or password");
            model.Password = string.Empty;

            return View(model);
        }

        [Route("[action]")]
        [AllowAnonymous]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Auth", new { returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }


        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl)
        {
            var context = await _interaction.GetAuthorizationContextAsync(returnUrl);
            var externalLoginInfo = await _signInManager.GetExternalLoginInfoAsync();
            if (externalLoginInfo is null)
            {
                await _interaction.DenyAuthorizationAsync(context, AuthorizationError.AccessDenied);
                return View("_AccessDenied");
            }

            var result = await _signInManager.ExternalLoginSignInAsync(externalLoginInfo.LoginProvider,
                externalLoginInfo.ProviderKey, false, false);
            if (result.Succeeded) return Redirect(returnUrl);
            return RedirectToAction("RegisterExternal", new { returnUrl });
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult RegisterExternal(string returnUrl)
        {
            var model = _modelsBuilder.ExternalLoginViewModelBuilder.Build(returnUrl, null);
            return View(model);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> RegisterExternal(ExternalLoginViewModel model)
        {
            var context = await _interaction.GetAuthorizationContextAsync(model.ReturnUrl);
            model.ExternalLoginInfo = await _signInManager.GetExternalLoginInfoAsync();
            if (model.ExternalLoginInfo is null)
            {
                await _interaction.DenyAuthorizationAsync(context, AuthorizationError.AccessDenied);
                return View("_AccessDenied");
            }

            var user = new User { Id = Guid.NewGuid(), EmailConfirmed = true };
            user.UserName = user.Id + "|" + model.Username;
            var createResult = await _userManager.CreateAsync(user);

            if (createResult.Succeeded)
            {
                var claimResult = await _userManager.AddToRoleAsync(user, "User");
                if (claimResult.Succeeded)
                {
                    var loginResult = await _userManager.AddLoginAsync(user, model.ExternalLoginInfo);
                    if (loginResult.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, false);
                        return Redirect(model.ReturnUrl);
                    }
                }
            }

            ModelState.AddModelError(string.Empty, createResult.Errors.First().Description);
            return RedirectToAction("Login", new { model.ReturnUrl });
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl)) return View("_NotFound");

            var registerViewModel = _modelsBuilder.RegisterViewModelBuilder.Build(returnUrl);
            return View(registerViewModel);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid is false)
            {
                model.Password = string.Empty;
                return View(model);
            }

            if (await _userManager.FindByEmailAsync(model.Email) is not null)
            {
                model.Password = string.Empty;
                ModelState.AddModelError(string.Empty, "Email has already been registered");
                return View(model);
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = model.Email,
                EmailConfirmed = false
            };
            user.UserName = user.Id + "|" + model.Username;

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded is false)
            {
                foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error.Description);
                model.Password = string.Empty;
                return View(model);
            }

            await _userManager.AddToRoleAsync(user, "User");

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var urlConfirm = CreateConfirmEmailUrl(new
                { userId = user.Id, tokenConfirmation = token, returnUrl = model.ReturnUrl });
            var urlDecline = CreateDeclineEmailUrl(new
                { userId = user.Id, tokenConfirmation = token, returnUrl = model.ReturnUrl });
            var body = await CreateFormAsync(urlConfirm, urlDecline,
                _configuration["CurrentDirectory"] + _configuration["EmailHtmlFormMessage:PathForm"]);

            await _emailService.SendEmailAsync(user.Email, user.UserName, "Email confirmation", body);
            return View("SuccessfullyRegistered");
        }

        private async Task<string> CreateFormAsync(string urlConfirm, string urlDecline, string pathForm)
        {
            var htmlForm = new StringBuilder(await System.IO.File.ReadAllTextAsync(pathForm));
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

        private string CreateConfirmEmailUrl(object values)
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

        private string CreateDeclineEmailUrl(object values)
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