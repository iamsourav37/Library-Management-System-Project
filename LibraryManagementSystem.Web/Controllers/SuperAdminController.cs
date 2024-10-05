using AutoMapper;
using LibraryManagementSystem.Web.Constant;
using LibraryManagementSystem.Web.Models.Domain;
using LibraryManagementSystem.Web.Models.ViewModel.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = Constant.ConstantValues.SUPER_ADMIN_ROLE)]
    public class SuperAdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public SuperAdminController(UserManager<ApplicationUser> userManager, IMapper mapper, RoleManager<ApplicationRole> roleManager)
        {
            this._userManager = userManager;
            this._mapper = mapper;
            this._roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var applicationUser = await _userManager.GetUserAsync(User);
            ViewBag.Name = applicationUser?.Name;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Users()
        {
            var allUsers = await _userManager.Users.ToListAsync();

            var currentUser = await _userManager.GetUserAsync(User);

            ViewBag.CurrentUserId = currentUser.Id;

            return View(allUsers);
        }

        [HttpGet]
        public async Task<IActionResult> UserEdit(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var userEditViewModel = _mapper.Map<UserEditViewModel>(user);
            var allRoles = ConstantValues.GetAllRoles();
            userEditViewModel.RoleList = allRoles.Select(role => new SelectListItem()
            {
                Value = role,
                Text = role
            }).ToList();
            return View(userEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UserEdit(UserEditViewModel userEditViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userEditViewModel);
            }
            var user = await _userManager.FindByIdAsync(userEditViewModel.Id.ToString());
            // Map properties from ViewModel to the existing user entity
            _mapper.Map(userEditViewModel, user);

            user.SecurityStamp = user.Id.ToString();
            user.UserName = user.Email;
            var identityResult = await _userManager.UpdateAsync(user);

            if (identityResult.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, userEditViewModel.SelectedRole);

                return RedirectToAction("Index");
            }
            return View(userEditViewModel);

        }
    }
}
