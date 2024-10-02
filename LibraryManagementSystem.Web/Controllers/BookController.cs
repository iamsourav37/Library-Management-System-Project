using AutoMapper;
using LibraryManagementSystem.Web.Models.Domain;
using LibraryManagementSystem.Web.Models.ViewModel;
using LibraryManagementSystem.Web.Models.ViewModel.Book;
using LibraryManagementSystem.Web.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Web.Controllers
{
    [Authorize(Roles = $"{Constant.ConstantValues.SUPER_ADMIN_ROLE}, {Constant.ConstantValues.ADMIN_ROLE}")]
    public class BookController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public BookController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this._categoryRepository = categoryRepository;
            this._mapper = mapper;
        }

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

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryCreateViewModel categoryCreateViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(categoryCreateViewModel);
            }

            var category = _mapper.Map<Category>(categoryCreateViewModel);

            await _categoryRepository.CreateAsync(category);

            return RedirectToAction("Index", "Book");
        }

        [HttpGet("all-category-list")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllCategoryAsync();
            var categoryViewModelList = _mapper.Map<List<CategoryViewModel>>(categories);
            return View(categoryViewModelList);
        }

    }
}
