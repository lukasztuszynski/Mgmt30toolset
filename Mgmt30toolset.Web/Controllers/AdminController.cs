
using Mgmt30toolset.Model;
using Mgmt30toolset.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Identity = Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Users.Controllers
{

    [Authorize(Roles = "Admins")]
    public class AdminController : Controller
    {
        private Identity.UserManager<User> userManager;
        private Identity.SignInManager<User> signInManager;

        public AdminController(Identity.UserManager<User> userManager, Identity.SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public ViewResult Index()
        {
            return View(userManager.Users.ToList());
        }

        public ViewResult Login()
        {
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

    }
}