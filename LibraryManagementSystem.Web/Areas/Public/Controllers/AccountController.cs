using LibraryManagementSystem.Web.Models.Domain;
using LibraryManagementSystem.Web.Models.ViewModel.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Web.Areas.Public.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            var applicationUser = await _userManager.FindByEmailAsync(loginViewModel.Email);

            if(applicationUser == null)
            {
                ViewBag.ErrorMessage = "Email or Password is invalid !!!";
                return View(loginViewModel);
            }

            var identityResult = await _signInManager.PasswordSignInAsync(applicationUser, loginViewModel.Password, isPersistent: loginViewModel.RememberMe, lockoutOnFailure:false);

            if(identityResult.Succeeded)
            {
                return RedirectToAction("Index", "Home");   
            }
            else
            {
                ViewBag.ErrorMessage = "Email or Password is invalid !!!";
            }
            return View(loginViewModel);
        }
    }
}
