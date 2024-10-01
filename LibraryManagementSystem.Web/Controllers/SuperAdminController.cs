using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Web.Areas.Admin.Controllers
{
    public class SuperAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
