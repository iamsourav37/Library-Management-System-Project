using LibraryManagementSystem.Web.Constant;
using LibraryManagementSystem.Web.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Web.Data
{
    public class LibraryManagementSystemDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public LibraryManagementSystemDbContext(DbContextOptions<LibraryManagementSystemDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<RequestMember> RequestMember { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            #region Seed the Roles
            var superAdminRoleId = Guid.NewGuid();
            var adminRoleId = Guid.NewGuid();
            var memberRoleId = Guid.NewGuid();

            var roles = new List<ApplicationRole>
            {
                new ApplicationRole
                {
                    Name= ConstantValues.SUPER_ADMIN_ROLE,
                    NormalizedName = ConstantValues.SUPER_ADMIN_ROLE.ToUpper(),
                    Id = superAdminRoleId,
                    ConcurrencyStamp = superAdminRoleId.ToString()
                },
                new ApplicationRole
                {
                   Name = ConstantValues.ADMIN_ROLE,
                   NormalizedName = ConstantValues.ADMIN_ROLE.ToUpper(),
                   Id = adminRoleId,
                   ConcurrencyStamp = adminRoleId.ToString()
                },
                new ApplicationRole()
                {
                    Name = ConstantValues.MEMBER_ROLE,
                    NormalizedName = ConstantValues.MEMBER_ROLE,
                    Id = memberRoleId,
                    ConcurrencyStamp = memberRoleId.ToString()
                }

            };

            builder.Entity<ApplicationRole>().HasData(roles);
            #endregion

            #region Seed Super Admin User
            var superAdminUserId = Guid.NewGuid();
            var superAdminEmail = "superadmin@lms.com";
            var superAdminInitialPassword = "Super@Admin.123";

            var superAdminUser = new ApplicationUser
            {
                UserName = superAdminEmail,
                Email = superAdminEmail,
                NormalizedEmail = superAdminEmail.ToUpper(),
                NormalizedUserName = superAdminEmail.ToUpper(),
                Id = superAdminUserId,
                Name = "Sourav Ganguly",
                SecurityStamp = superAdminUserId.ToString(),
            };

            superAdminUser.PasswordHash = new PasswordHasher<ApplicationUser>()
                .HashPassword(superAdminUser, superAdminInitialPassword);

            builder.Entity<ApplicationUser>().HasData(superAdminUser);
            #endregion

            #region Add all roles to Super Admin

            var superAdminRoles = new List<IdentityUserRole<Guid>>()
            {
                new IdentityUserRole<Guid>()
                {
                    RoleId = superAdminRoleId,
                    UserId = superAdminUserId,
                },
                new IdentityUserRole<Guid>()
                {
                    RoleId = adminRoleId,
                    UserId = superAdminUserId,
                },
                new IdentityUserRole<Guid>()
                {
                    RoleId = memberRoleId,
                    UserId = superAdminUserId,
                },
            };

            builder.Entity<IdentityUserRole<Guid>>().HasData(superAdminRoles);
            #endregion


        }



    }
}
