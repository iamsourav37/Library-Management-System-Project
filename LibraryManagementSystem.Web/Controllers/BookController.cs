using LibraryManagementSystem.Web.Models.ViewModel.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Web.Controllers
{
    [Authorize(Roles = $"{Constant.ConstantValues.SUPER_ADMIN_ROLE}, {Constant.ConstantValues.ADMIN_ROLE}")]
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            var bookList = new List<BookViewModel>()
            {
                new BookViewModel()
                {
                    Id = Guid.NewGuid(),
                    Title = "C# in Depth",
                    Author = "Anders Hejlsberg",
                    CategoryName = "Technology",
                    CopiesAvailable = 200,
                    TotalCopies = 200,
                    ISBN = "C#INDEPTH"
                }
            };
            return View(bookList);
        }

        [HttpGet("Books/create-category")]
        public IActionResult CreateCategory()
        {
            return View();
        }


    }
}
