using LibraryManagementSystem.Web.Constant;
using LibraryManagementSystem.Web.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public async Task<IActionResult> AdminUsers()
        {
            var adminUsers = await this.GetAllAdminUsers();
            return View(adminUsers);
        }

        private async Task<List<ApplicationUser>> GetAllAdminUsers()
        {
            var allUsers = await _userManager.Users.ToListAsync();
            var adminUsers = new List<ApplicationUser>();
            foreach(var user in allUsers)
            {
                if(await _userManager.IsInRoleAsync(user, Constant.ConstantValues.ADMIN_ROLE))
                {
                    adminUsers.Add(user);
                }
            }
 
            return adminUsers;
        }
    }
}
