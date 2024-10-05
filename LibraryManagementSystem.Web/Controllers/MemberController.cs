using LibraryManagementSystem.Web.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Web.Controllers
{
    public class MemberController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public MemberController(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }



        public async Task<IActionResult> Index()
        {
            var applicationUser = await _userManager.GetUserAsync(User);
            ViewBag.Name = applicationUser.Name;
            return View();
        }
    }
}
