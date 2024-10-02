﻿using LibraryManagementSystem.Web.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Web.Areas.Admin.Controllers
{
    [Authorize(Roles =Constant.ConstantValues.SUPER_ADMIN_ROLE)]
    public class SuperAdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public SuperAdminController(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var applicationUser = await _userManager.GetUserAsync(User);
            ViewBag.Name = applicationUser?.Name;
            return View();
        }
    }
}
