using LibraryManagementSystem.Web.Models.Domain;
using LibraryManagementSystem.Web.Models.ViewModel.Book;
using AutoMapper;
using LibraryManagementSystem.Web.Models.ViewModel;
using LibraryManagementSystem.Web.Models.ViewModel.Account;

namespace LibraryManagementSystem.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           // Category
            CreateMap<Category, CategoryCreateViewModel>().ReverseMap();
            CreateMap<CategoryViewModel, Category>().ReverseMap();

            // Book
            CreateMap<Book, BookCreateViewModel>().ReverseMap();
            CreateMap<Book, BookUpdateViewModel>().ReverseMap();
            CreateMap<Book, BookViewModel>().ReverseMap();

            // Account
            CreateMap<ApplicationUser, UserEditViewModel>()
          // Add any specific mappings if property names differ
          .ForMember(dest => dest.RoleList, opt => opt.Ignore()).ReverseMap();


            // BookTransaction
            CreateMap<BookTransactionViewModel, BookTransaction>().ReverseMap();
        }
    }
}
