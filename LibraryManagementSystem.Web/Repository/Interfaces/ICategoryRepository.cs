using LibraryManagementSystem.Web.Models.Domain;

namespace LibraryManagementSystem.Web.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        Task CreateAsync(Category category);
        Task<IEnumerable<Category>> GetAllCategoryAsync();
    }
}
