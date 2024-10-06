using LibraryManagementSystem.Web.Data;
using LibraryManagementSystem.Web.Models.Domain;
using LibraryManagementSystem.Web.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Web.Repository.Implementation
{
    public class BookTransactionRepository : IBookTransactionRepository
    {
        private readonly LibraryManagementSystemDbContext _dbContext;

        public BookTransactionRepository(LibraryManagementSystemDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task CreateBookTransactionAsync(BookTransaction transaction)
        {
            _dbContext.BookTransactions.Add(transaction);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookTransaction>> GetAllBookTransactionAsync()
        {
            return await _dbContext.BookTransactions.ToListAsync();
        }

        public async Task<IEnumerable<BookTransaction>> GetAllBookTransactionsByUserIdAsync(Guid userId)
        {
            return await _dbContext.BookTransactions.Include("Member").Where(transaction => transaction.MemberId == userId).ToListAsync();
        }

        public async Task<BookTransaction> GetBookTransactionByIdAsync(Guid id)
        {
            return await _dbContext.BookTransactions.FindAsync(id);
        }

        public async Task UpdateBookTransactionAsync(BookTransaction transaction)
        {
            _dbContext.BookTransactions.Update(transaction);
            await _dbContext.SaveChangesAsync();
        }
    }
}
