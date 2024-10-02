using LibraryManagementSystem.Web.Data;
using LibraryManagementSystem.Web.Models.Domain;
using LibraryManagementSystem.Web.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Web.Repository.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        LibraryManagementSystemDbContext _dbContext;

        public CategoryRepository(LibraryManagementSystemDbContext dbContext)
        {

            this._dbContext = dbContext;
        }

        public async Task CreateAsync(Category category)
        {
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }
    }
}
