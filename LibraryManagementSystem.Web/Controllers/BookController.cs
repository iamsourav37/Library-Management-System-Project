using AutoMapper;
using LibraryManagementSystem.Web.Models.Domain;
using LibraryManagementSystem.Web.Models.ViewModel;
using LibraryManagementSystem.Web.Models.ViewModel.Book;
using LibraryManagementSystem.Web.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Net;

namespace LibraryManagementSystem.Web.Controllers
{
    [Authorize(Roles = Constant.ConstantValues.ADMIN_ROLE)]
    public class BookController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        public BookController(ICategoryRepository categoryRepository, IMapper mapper, IBookRepository bookRepository)
        {
            this._categoryRepository = categoryRepository;
            this._mapper = mapper;
            this._bookRepository = bookRepository;
        }

        public async Task<IActionResult> Index()
        {
            var allBooks = await _bookRepository.GetAllBooksAsync();
            var allCategories = await _categoryRepository.GetAllCategoryAsync();
            var bookViewModelList = _mapper.Map<List<BookViewModel>>(allBooks);

            // Create a dictionary of categories for faster lookup
            var categoryDictionary = allCategories.ToDictionary(category => category.Id, category => category.Name);

            // Assign category name to each book view model
            foreach (var bookViewModel in bookViewModelList)
            {
                if (categoryDictionary.TryGetValue(bookViewModel.CategoryId, out var categoryName))
                {
                    bookViewModel.CategoryName = categoryName;
                }
            }
            return View(bookViewModelList);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryCreateViewModel categoryCreateViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryCreateViewModel);
            }

            var category = _mapper.Map<Category>(categoryCreateViewModel);


            await Task.Run(async () =>
             {
                 var startTime = DateTime.Now;
                 try
                 {
                     await _categoryRepository.CreateAsync(category);
                 }
                 catch (Exception ex)
                 {
                     // Handle the exception (e.g., log it)
                 }
                 var endTime = DateTime.Now;
                 var duration = endTime - startTime;
                 // Log or output the duration
                 Console.WriteLine($"Task completed in {duration.TotalMilliseconds} ms");
             });


            return RedirectToAction("Index", "Book");
        }

        [HttpGet("all-category-list")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllCategoryAsync();
            var categoryViewModelList = _mapper.Map<List<CategoryViewModel>>(categories);
            return View(categoryViewModelList);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var allCategories = await _categoryRepository.GetAllCategoryAsync();
            var bookCreateViewModel = new BookCreateViewModel();
            bookCreateViewModel.CategoryList = allCategories.Select(category => new SelectListItem() { Text = category.Name, Value = category.Id.ToString() }).ToList();
            return View(bookCreateViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Create(BookCreateViewModel bookCreateViewModel)
        {

            if (!ModelState.IsValid)
            {
                var allCategories = await _categoryRepository.GetAllCategoryAsync();
                bookCreateViewModel.CategoryList = allCategories.Select(category => new SelectListItem() { Text = category.Name, Value = category.Id.ToString() }).ToList();
                return View(bookCreateViewModel);
            }

            var book = _mapper.Map<Book>(bookCreateViewModel);
            book.CopiesAvailable = book.TotalCopies;
            await _bookRepository.CreateBookAsync(book);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid bookId)
        {
            var book = await _bookRepository.GetBookByIdAsync(bookId);
            if (book == null)
            {
                return NotFound();
            }
            var bookUpdateViewModel = _mapper.Map<BookUpdateViewModel>(book);
            var allCategories = await this._categoryRepository.GetAllCategoryAsync();
            bookUpdateViewModel.CategoryList = allCategories.Select(category =>
            new SelectListItem()
            {
                Text = category.Name,
                Value = category.Id.ToString(),
                Selected = book.CategoryId == category.Id ? true : false

            }).ToList();


            return View(bookUpdateViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(BookUpdateViewModel bookUpdateViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(bookUpdateViewModel);
            }
            var book = await _bookRepository.GetBookByIdAsync(bookUpdateViewModel.Id);
            var availability = (bookUpdateViewModel.TotalCopies - book.TotalCopies) + book.CopiesAvailable;
            book.CopiesAvailable = availability;
            book.Title = bookUpdateViewModel.Title;
            book.ISBN = bookUpdateViewModel.ISBN;
            book.Author = bookUpdateViewModel.Author;
            book.TotalCopies = bookUpdateViewModel.TotalCopies;
            book.UpdatedDate = DateOnly.FromDateTime(DateTime.Now);
            book.CategoryId = bookUpdateViewModel.CategoryId;

            await _bookRepository.UpdateBookAsync(book);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid bookId)
        {
            var book = await _bookRepository.GetBookByIdAsync(bookId);

            if (book != null)
            {
                await _bookRepository.DeleteBookAsync(book);
            }


            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [HttpGet("list-of-books")]
        public async Task<IActionResult> BookList()
        {
            var allBooks = await _bookRepository.GetAllBooksAsync();
            var allCategories = await _categoryRepository.GetAllCategoryAsync();
            var bookViewModelList = _mapper.Map<List<BookViewModel>>(allBooks);

            // Create a dictionary of categories for faster lookup
            var categoryDictionary = allCategories.ToDictionary(category => category.Id, category => category.Name);

            // Assign category name to each book view model
            foreach (var bookViewModel in bookViewModelList)
            {
                if (categoryDictionary.TryGetValue(bookViewModel.CategoryId, out var categoryName))
                {
                    bookViewModel.CategoryName = categoryName;
                }
            }
            return View(bookViewModelList);
        }


    }
}
