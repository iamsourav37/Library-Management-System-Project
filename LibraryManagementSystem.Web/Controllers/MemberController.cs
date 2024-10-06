using AutoMapper;
using LibraryManagementSystem.Web.Models.Domain;
using LibraryManagementSystem.Web.Models.ViewModel.Book;
using LibraryManagementSystem.Web.Repository.Implementation;
using LibraryManagementSystem.Web.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Web.Controllers
{
    public class MemberController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IBookTransactionRepository _bookTransactionRepository;
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        public MemberController(UserManager<ApplicationUser> userManager, IBookTransactionRepository bookTransactionRepository, IMapper mapper, IBookRepository bookRepository)
        {
            this._userManager = userManager;
            this._bookTransactionRepository = bookTransactionRepository;
            this._mapper = mapper;
            this._bookRepository = bookRepository;
        }



        public async Task<IActionResult> Index()
        {
            var applicationUser = await _userManager.GetUserAsync(User);
            ViewBag.Name = applicationUser.Name;

            var transactionList = await _bookTransactionRepository.GetAllBookTransactionsByUserIdAsync(applicationUser.Id);

            var bookTransactionViewModelList = new List<BookTransactionViewModel>();
            foreach(var transaction in transactionList)
            {
                bookTransactionViewModelList.Add(await LoadBookTransactionViewModelWithDetails(transaction));
            }
            return View(bookTransactionViewModelList);
        }

        private async Task<BookTransactionViewModel> LoadBookTransactionViewModelWithDetails(BookTransaction transaction)
        {

            var book = await _bookRepository.GetBookByIdAsync(transaction.BookId);

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
            };
            return viewModel;
        }
    }
}
