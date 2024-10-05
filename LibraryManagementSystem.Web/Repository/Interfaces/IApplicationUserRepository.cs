using LibraryManagementSystem.Web.Models.Domain;

namespace LibraryManagementSystem.Web.Repository.Interfaces
{
    public interface IApplicationUserRepository
    {
        Task<IEnumerable<ApplicationUser>> GetAllMemberAsync();
    }
}
