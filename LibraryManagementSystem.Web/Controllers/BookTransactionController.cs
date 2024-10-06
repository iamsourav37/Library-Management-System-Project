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
    [Authorize(Roles = $"{ConstantValues.ADMIN_ROLE}, {ConstantValues.SUPER_ADMIN_ROLE}")]
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


        /// <summary>
        /// Map Book Transaction View Model with Member and Book details
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private async Task<BookTransactionViewModel> LoadBookTransactionViewModelWithDetails(BookTransaction transaction)
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
                MemberName = member?.Name, // Fetching member's name
                MemberEmail = member?.Email
            };
            return viewModel;
        }


        public async Task<IActionResult> Index()
        {
            var bookTransactionList = await _bookTransactionRepository.GetAllBookTransactionAsync();

            var bookTransactionViewModelList = new List<BookTransactionViewModel>();

            foreach (var bookTransaction in bookTransactionList)
            {
                bookTransactionViewModelList.Add(await LoadBookTransactionViewModelWithDetails(bookTransaction));
            }


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

        [HttpGet]
        public async Task<IActionResult> ReturnBook(Guid transactionId)
        {
            var bookTransaction = await _bookTransactionRepository.GetBookTransactionByIdAsync(transactionId);
            int overdueDays = 0;
            if (bookTransaction != null)
            {
                // Write your logic here...
                var todayDate = DateTime.Now;
                bookTransaction.ReturnedDate = todayDate;
                if (todayDate > bookTransaction.DueDate)
                {
                    overdueDays = (todayDate - bookTransaction.DueDate).Days;
                    bookTransaction.PenaltyAmount = overdueDays * ConstantValues.FINE_AMOUNT;
                }

                var bookTransactionViewModel = await LoadBookTransactionViewModelWithDetails(bookTransaction);
                bookTransactionViewModel.PenaltyDays = overdueDays;
                return View(bookTransactionViewModel);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ReturnBook(BookTransactionViewModel bookTransactionViewModel)
        {
            var bookTransaction = await _bookTransactionRepository.GetBookTransactionByIdAsync(bookTransactionViewModel.TransactionId);

            bookTransaction.PenaltyAmount = bookTransactionViewModel.PenaltyAmount;
            bookTransaction.ReturnedDate = bookTransactionViewModel.ReturnedDate;

            if (bookTransactionViewModel.PenaltyAmount > 0)
            {
                bookTransaction.Status = Status.Overdue;
            }
            else
            {
                bookTransaction.Status = Status.Returned;
            }

            await _bookTransactionRepository.UpdateBookTransactionAsync(bookTransaction);
            var book = await _bookRepository.GetBookByIdAsync(bookTransactionViewModel.BookId);
            book.CopiesAvailable++;
            await _bookRepository.UpdateBookAsync(book);
            return RedirectToAction("Index");
        }
    }
}
