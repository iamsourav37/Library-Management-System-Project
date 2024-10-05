using AutoMapper;
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
        private readonly IBookTransactionRepository _bookTransactionRepository;
        private readonly IMapper _mapper;

        public BookTransactionController(UserManager<ApplicationUser> userManager, IBookRepository bookRepository, IApplicationUserRepository applicationUserRepository, IBookTransactionRepository bookTransactionRepository, IMapper mapper)
        {
            this._userManager = userManager;
            this._bookRepository = bookRepository;
            this._applicationUserRepository = applicationUserRepository;
            this._bookTransactionRepository = bookTransactionRepository;
            this._mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var bookTransactionList = await _bookTransactionRepository.GetAllBookTransactionAsync();

            #region Bad Approach
            /*
            var bookTransactionViewModel = bookTransactionList.Select(async transaction => new BookTransactionViewModel()
            {
                BookId = transaction.BookId,
                MemberId = transaction.MemberId,
                DueDate = transaction.DueDate,
                BorrowedDate = transaction.BorrowedDate,
                PenaltyAmount = transaction.PenaltyAmount,
                TransactionId = transaction.TransactionId,
                Status = transaction.Status,
                ReturnedDate = transaction.ReturnedDate,

                BookTitle = (await _bookRepository.GetBookByIdAsync(transaction.BookId)).Title,
               // MemberName = (await _userManager.GetUserNameAsync(User))

            }).ToList();
            */
            #endregion

            #region Good Approach
            List<BookTransactionViewModel> bookTransactionViewModelList = new();

            foreach (var transaction in bookTransactionList)
            {
                var book = await _bookRepository.GetBookByIdAsync(transaction.BookId);
                var member = await _userManager.FindByIdAsync(transaction.MemberId.ToString());

                var viewModel = new BookTransactionViewModel
                {
                    BookId = transaction.BookId,
                    MemberId = transaction.MemberId,
                    DueDate = transaction.DueDate,
                    BorrowedDate = transaction.BorrowedDate,
                    PenaltyAmount = transaction.PenaltyAmount,
                    TransactionId = transaction.TransactionId,
                    Status = transaction.Status,
                    ReturnedDate = transaction.ReturnedDate,
                    BookTitle = book.Title,  // Fetching book title directly
                    MemberName = member?.UserName, // Fetching member's name
                    MemberEmail = member?.Email
                };
                bookTransactionViewModelList.Add(viewModel);
            }
            #endregion

            return View(bookTransactionViewModelList);
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

        [HttpPost]
        public async Task<IActionResult> IssueBook(BookTransactionCreateViiewModel bookTransactionCreateViiewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(bookTransactionCreateViiewModel);
            }

            var book = await _bookRepository.GetBookByIdAsync(bookTransactionCreateViiewModel.BookId);
            if (book != null)
            {
                if (book.TotalCopies > 0)
                {
                    // Create the BookTransaction Object
                    var bookTransaction = new BookTransaction()
                    {
                        BookId = bookTransactionCreateViiewModel.BookId,
                        MemberId = bookTransactionCreateViiewModel.MemberId,
                        BorrowedDate = DateTime.Now,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        DueDate = DateTime.Now.AddDays(30),
                        PenaltyAmount = 0,
                        Status = Status.Borrowed,


                    };
                    await _bookTransactionRepository.CreateBookTransactionAsync(bookTransaction);

                    // Book Transaction is Created, now update the book availability
                    book.CopiesAvailable--;
                    await _bookRepository.UpdateBookAsync(book);

                    return RedirectToAction("Index");
                }
            }

            return View(bookTransactionCreateViiewModel);
        }
    }
}
