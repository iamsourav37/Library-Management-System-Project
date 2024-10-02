using LibraryManagementSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LibraryManagementSystem.Web.Areas.Public.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if(User.IsInRole(Constant.ConstantValues.SUPER_ADMIN_ROLE))
            {
                return RedirectToAction("Index", "SuperAdmin");
            }
            if (User.IsInRole(Constant.ConstantValues.ADMIN_ROLE))
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
