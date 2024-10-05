using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Web.Controllers
{
    [Authorize(Roles =Constant.ConstantValues.ADMIN_ROLE)]
    public class BookIssueController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
