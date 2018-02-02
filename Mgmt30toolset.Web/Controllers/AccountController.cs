using Mgmt30toolset.Model;
using Mgmt30toolset.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Identity = Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Users.Controllers
{
    public class AccountController : Controller
    {
        private Identity.UserManager<User> userManager;
        private Identity.SignInManager<User> signInManager;
        private IConfiguration configuration;

        public AccountController(IConfiguration configuration, Identity.UserManager<User> userManager, Identity.SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        public IActionResult GoogleLogin(string returnUrl)
        {
            string redirectUrl = Url.Action("GoogleResponse", "Account", new { ReturnUrl = returnUrl });
            var properties = signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);

            return new ChallengeResult("Google", properties);
        }

        [AllowAnonymous]
        public async Task<IActionResult> GoogleResponse(string returnUrl = "/")
        {
            ExternalLoginInfo info = await signInManager.GetExternalLoginInfoAsync();

            if (info == null)
            {
                return RedirectToAction(nameof(Login));
            }

            var result = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);

            if (result.Succeeded)
            {
                return Redirect(returnUrl);
            }
            else if (info.Principal.FindFirst(ClaimTypes.Email).Value.EndsWith("@" + configuration["AuthenticationData:Google:OrganizationName"]))
            {
                User user = new User
                {
                    Email = info.Principal.FindFirst(ClaimTypes.Email).Value,
                    UserName = info.Principal.FindFirst(ClaimTypes.Email).Value,
                    FirstName = info.Principal.FindFirst(ClaimTypes.GivenName).Value,
                    LastName = info.Principal.FindFirst(ClaimTypes.Surname).Value
                };

                IdentityResult identResult = await userManager.CreateAsync(user);

                if (identResult.Succeeded)
                {
                    identResult = await userManager.AddLoginAsync(user, info);
                    if (identResult.Succeeded)
                    {
                        await signInManager.SignInAsync(user, false);
                        return Redirect(returnUrl);
                    }
                }
            }

            return AccessDenied();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginFormViewModel loginForm, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                User user = await userManager.FindByEmailAsync(loginForm.Email);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, loginForm.Password, false, false);
                    if (result.Succeeded)
                    {
                        return Redirect(returnUrl ?? "/");
                    }
                }
                ModelState.AddModelError(nameof(loginForm.Email), "Invalid user or password");
            }
            return View(loginForm);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Kudo");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View("AccessDenied");
        }
    }
}