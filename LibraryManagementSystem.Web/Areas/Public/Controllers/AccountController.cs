using LibraryManagementSystem.Web.Models.Domain;
using LibraryManagementSystem.Web.Models.ViewModel.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Web.Areas.Public.Controllers
{
    [AllowAnonymous]
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
            // Check if the user is already logged in
            if (User.Identity.IsAuthenticated)
            {
                // Redirect to home page or any other page if user is already authenticated
                return RedirectToAction("Index", "Home");
            }

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

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
