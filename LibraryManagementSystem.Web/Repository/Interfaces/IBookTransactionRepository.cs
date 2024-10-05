using LibraryManagementSystem.Web.Models.Domain;

namespace LibraryManagementSystem.Web.Repository.Interfaces
{
    public interface IBookTransactionRepository
    {
        Task<IEnumerable<BookTransaction>> GetAllBookTransactionAsync();
        Task<BookTransaction> GetBookTransactionByIdAsync(Guid id);

        Task CreateBookTransactionAsync(BookTransaction transaction);
        Task UpdateBookTransactionAsync(BookTransaction transaction);
    }
}
