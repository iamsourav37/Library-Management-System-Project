using LibraryManagementSystem.Web.Areas.Admin.Controllers;
using LibraryManagementSystem.Web.Models.Domain;
using LibraryManagementSystem.Web.Models.ViewModel.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Web.Constant;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [AllowAnonymous]
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
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            var applicationUser = await _userManager.FindByEmailAsync(loginViewModel.Email);

            if (applicationUser == null)
            {
                ViewBag.ErrorMessage = "Email or Password is invalid !!!";
                return View(loginViewModel);
            }

            var identityResult = await _signInManager.PasswordSignInAsync(applicationUser, loginViewModel.Password, isPersistent: loginViewModel.RememberMe, lockoutOnFailure: false);

            if (identityResult.Succeeded)
            {
                if (await _userManager.IsInRoleAsync(applicationUser, Constant.ConstantValues.SUPER_ADMIN_ROLE))
                {
                    return RedirectToAction(nameof(SuperAdminController.Index), "SuperAdmin");
                }
                else if (await _userManager.IsInRoleAsync(applicationUser, Constant.ConstantValues.ADMIN_ROLE))
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                    return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Email or Password is invalid !!!";
            }
            return View(loginViewModel);
        }

        [Authorize(Roles = ConstantValues.SUPER_ADMIN_ROLE)]
        [HttpGet]
        public IActionResult Register()
        {
            var allRoles = ConstantValues.GetAllRoles();
            var registerViewModel = new RegisterViewModel()
            {
                RoleList = allRoles.Select(role => new SelectListItem()
                {
                    Value = role,
                    Text = role
                }).ToList()
            };

            return View(registerViewModel);
        }

        [Authorize(Roles = Constant.ConstantValues.SUPER_ADMIN_ROLE)]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                registerViewModel.RoleList = ConstantValues.GetAllRoles().Select(role => new SelectListItem()
                {
                    Value = role,
                    Text = role
                }).ToList();
                var errorMessages = ModelState.Values
                                 .SelectMany(v => v.Errors)
                                 .Select(e => e.ErrorMessage);

                ViewBag.ErrorMessage = string.Join(" | ", errorMessages);
                return View(registerViewModel);
            }


            var applicationUser = new ApplicationUser()
            {
                UserName = registerViewModel.Email,
                Email = registerViewModel.Email,
                Address1 = registerViewModel.Address1,
                Name = registerViewModel.Name,
            };

            var identityResult = await _userManager.CreateAsync(applicationUser, registerViewModel.Password);

            if (identityResult.Succeeded)
            {
                IdentityResult result = null;
                if (await _roleManager.FindByNameAsync(registerViewModel.SelectedRole) != null)
                {
                    // Role Exist, add the role to the user
                    result = await _userManager.AddToRoleAsync(applicationUser, registerViewModel.SelectedRole);
                }
                else
                {
                    // Invalid role, so add as 'Member'
                    result = await _userManager.AddToRoleAsync(applicationUser, ConstantValues.MEMBER_ROLE);
                }

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "SuperAdmin");
                }
                else
                {
                    registerViewModel.RoleList = ConstantValues.GetAllRoles().Select(role => new SelectListItem()
                    {
                        Value = role,
                        Text = role
                    }).ToList();
                    ViewBag.ErrorMessage = string.Join(" | ", result.Errors.Select(e => e.Code));
                    return View(registerViewModel);
                }
            }

            var allRoles = ConstantValues.GetAllRoles();
            registerViewModel.RoleList = allRoles.Select(role => new SelectListItem()
            {
                Value = role,
                Text = role
            }).ToList();
            ViewBag.ErrorMessage = string.Join(" | ", identityResult.Errors.Select(e => e.Description));
            return View(registerViewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }


    }
}
