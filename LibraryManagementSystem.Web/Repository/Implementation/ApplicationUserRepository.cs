using LibraryManagementSystem.Web.Constant;
using LibraryManagementSystem.Web.Data;
using LibraryManagementSystem.Web.Models.Domain;
using LibraryManagementSystem.Web.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Web.Repository.Implementation
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly LibraryManagementSystemDbContext _dbContext;

        public ApplicationUserRepository(LibraryManagementSystemDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<IEnumerable<ApplicationUser>> GetAllMemberAsync()
        {
            var members = await (from user in _dbContext.Users
                                 join userRole in _dbContext.UserRoles on user.Id equals userRole.UserId
                                 join role in _dbContext.Roles on userRole.RoleId equals role.Id
                                 where role.Name == ConstantValues.MEMBER_ROLE
                                 select user)
                                .ToListAsync();

            return members;
        }
    }
}
