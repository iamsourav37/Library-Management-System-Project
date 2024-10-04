using LibraryManagementSystem.Web.Data;
using LibraryManagementSystem.Web.Models.Domain;
using LibraryManagementSystem.Web.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Web.Repository.Implementation
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryManagementSystemDbContext _dbContext;

        public BookRepository(LibraryManagementSystemDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task CreateBookAsync(Book book)
        {
            this._dbContext.Books.Add(book);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(Book book)
        {
            this._dbContext.Books.Remove(book);
            await this._dbContext.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await this._dbContext.Books.ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(Guid id)
        {
            return await this._dbContext.Books.FindAsync(id);
        }

        public async Task UpdateBookAsync(Book book)
        {
            this._dbContext.Books.Update(book);
            await this._dbContext.SaveChangesAsync();
        }
    }
}
