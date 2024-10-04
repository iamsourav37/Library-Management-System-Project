using LibraryManagementSystem.Web.Data;
using LibraryManagementSystem.Web.Models.Domain;
using LibraryManagementSystem.Web.Repository.Implementation;
using LibraryManagementSystem.Web.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<LibraryManagementSystemDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("LMSDbConnectionString")));

// Identity Setup
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<LibraryManagementSystemDbContext>()
                .AddDefaultTokenProviders()
                .AddUserStore<UserStore<ApplicationUser, ApplicationRole, LibraryManagementSystemDbContext, Guid>>()
                .AddRoleStore<RoleStore<ApplicationRole, LibraryManagementSystemDbContext, Guid>>();




#region Add Dependencies
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IBookRepository, BookRepository>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
