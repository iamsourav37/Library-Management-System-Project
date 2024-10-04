using LibraryManagementSystem.Web.Models.Domain;
using LibraryManagementSystem.Web.Models.ViewModel.Book;
using AutoMapper;
using LibraryManagementSystem.Web.Models.ViewModel;

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
                                               
        }
    }
}
