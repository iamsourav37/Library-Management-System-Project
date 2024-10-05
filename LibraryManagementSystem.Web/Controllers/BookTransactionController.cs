using LibraryManagementSystem.Web.Constant;
using LibraryManagementSystem.Web.Models.Domain;
using LibraryManagementSystem.Web.Models.ViewModel.Book;
using LibraryManagementSystem.Web.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Web.Controllers
{
    [Authorize(Roles = ConstantValues.ADMIN_ROLE)]
    public class BookTransactionController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IBookRepository _bookRepository;
        private readonly IApplicationUserRepository _applicationUserRepository;

        public BookTransactionController(UserManager<ApplicationUser> userManager, IBookRepository bookRepository, IApplicationUserRepository applicationUserRepository)
        {
            this._userManager = userManager;
            this._bookRepository = bookRepository;
            this._applicationUserRepository = applicationUserRepository;
        }
        public IActionResult Index()
        {
            var bookTransactionList = new List<BookTransactionViewModel>();
            return View(bookTransactionList);
        }

        public async Task<IActionResult> IssueBook()
        {
            var allBooks = await _bookRepository.GetAllBooksAsync();
            var members = await _applicationUserRepository.GetAllMemberAsync();

            var bookTransactionCreateViewModel = new BookTransactionCreateViiewModel()
            {
                BookList = allBooks.Select(book => new SelectListItem()
                {
                    Text = book.Title,
                    Value = book.Id.ToString()
                }).ToList(),

                MemberList = members.Select(member => new SelectListItem()
                {
                    Text = member.Name,
                    Value = member.Id.ToString()
                }).ToList()
            };

            return View(bookTransactionCreateViewModel);
        }
    }
}
