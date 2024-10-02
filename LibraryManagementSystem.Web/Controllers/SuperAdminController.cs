using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Web.Areas.Admin.Controllers
{
    [Authorize(Roles =Constant.ConstantValues.SUPER_ADMIN_ROLE)]
    public class SuperAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
