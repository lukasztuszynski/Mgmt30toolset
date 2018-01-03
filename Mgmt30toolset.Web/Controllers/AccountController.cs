using Mgmt30toolset.Model;
using Mgmt30toolset.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Identity = Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Users.Controllers
{
    public class AccountController : Controller
    {
        private Identity.UserManager<User> userManager;
        private Identity.SignInManager<User> signInManager;

        public AccountController(Identity.UserManager<User> userManager, Identity.SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
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
            return View();
        }
    }
}