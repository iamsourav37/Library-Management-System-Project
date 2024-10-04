using LibraryManagementSystem.Web.Models.Domain;

namespace LibraryManagementSystem.Web.Repository.Interfaces
{
    public interface IBookRepository
    {
        Task CreateBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(Book book);
        Task<Book> GetBookByIdAsync(Guid id);
        Task<IEnumerable<Book>> GetAllBooksAsync();

    }
}
