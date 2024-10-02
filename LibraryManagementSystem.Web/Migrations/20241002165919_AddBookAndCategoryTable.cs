using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagementSystem.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddBookAndCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3441dfed-f084-4dc2-b805-934d31f6c33c"), new Guid("cd2d1e35-9e9a-4de5-9711-391c123be1cf") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("673b6c56-1f26-4025-8899-5e9603c4f587"), new Guid("cd2d1e35-9e9a-4de5-9711-391c123be1cf") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7e9d0879-907f-4068-83f1-dd140714ac2d"), new Guid("cd2d1e35-9e9a-4de5-9711-391c123be1cf") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3441dfed-f084-4dc2-b805-934d31f6c33c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("673b6c56-1f26-4025-8899-5e9603c4f587"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7e9d0879-907f-4068-83f1-dd140714ac2d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cd2d1e35-9e9a-4de5-9711-391c123be1cf"));

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalCopies = table.Column<int>(type: "int", nullable: true),
                    CopiesAvailable = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("c47b11e0-f8cf-4d2e-9699-fcbe83559877"), "c47b11e0-f8cf-4d2e-9699-fcbe83559877", "Member", "Member" },
                    { new Guid("e0892188-055e-45ef-b8c1-c5f0819b3f51"), "e0892188-055e-45ef-b8c1-c5f0819b3f51", "Admin", "ADMIN" },
                    { new Guid("e727ecd6-ec5a-4012-8f4f-699009f807a8"), "e727ecd6-ec5a-4012-8f4f-699009f807a8", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address1", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("01d7c462-3db5-4244-9147-e2494237c632"), 0, null, "987040e4-7e28-4a9d-b1f5-8b1a44ebfd43", "superadmin@lms.com", false, false, null, "Sourav Ganguly", "SUPERADMIN@LMS.COM", "SUPERADMIN@LMS.COM", "AQAAAAIAAYagAAAAEBRv7ko+CsR5k5JWKWMKiU1vbmctDxiWs49HNeEdVqNDEL06GzMXD9V7WcFP6KD7hg==", null, false, "01d7c462-3db5-4244-9147-e2494237c632", false, "superadmin@lms.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("c47b11e0-f8cf-4d2e-9699-fcbe83559877"), new Guid("01d7c462-3db5-4244-9147-e2494237c632") },
                    { new Guid("e0892188-055e-45ef-b8c1-c5f0819b3f51"), new Guid("01d7c462-3db5-4244-9147-e2494237c632") },
                    { new Guid("e727ecd6-ec5a-4012-8f4f-699009f807a8"), new Guid("01d7c462-3db5-4244-9147-e2494237c632") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c47b11e0-f8cf-4d2e-9699-fcbe83559877"), new Guid("01d7c462-3db5-4244-9147-e2494237c632") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e0892188-055e-45ef-b8c1-c5f0819b3f51"), new Guid("01d7c462-3db5-4244-9147-e2494237c632") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e727ecd6-ec5a-4012-8f4f-699009f807a8"), new Guid("01d7c462-3db5-4244-9147-e2494237c632") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c47b11e0-f8cf-4d2e-9699-fcbe83559877"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e0892188-055e-45ef-b8c1-c5f0819b3f51"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e727ecd6-ec5a-4012-8f4f-699009f807a8"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("01d7c462-3db5-4244-9147-e2494237c632"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("3441dfed-f084-4dc2-b805-934d31f6c33c"), "3441dfed-f084-4dc2-b805-934d31f6c33c", "Admin", "ADMIN" },
                    { new Guid("673b6c56-1f26-4025-8899-5e9603c4f587"), "673b6c56-1f26-4025-8899-5e9603c4f587", "Member", "Member" },
                    { new Guid("7e9d0879-907f-4068-83f1-dd140714ac2d"), "7e9d0879-907f-4068-83f1-dd140714ac2d", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address1", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("cd2d1e35-9e9a-4de5-9711-391c123be1cf"), 0, null, "b7b85eda-50f3-4d39-a8bc-0c22e831b11c", "superadmin@lms.com", false, false, null, "Sourav Ganguly", "SUPERADMIN@LMS.COM", "SUPERADMIN@LMS.COM", "AQAAAAIAAYagAAAAENK1qpfPQMoMr6j3haJKfaWDoIbmvTIQl6Nkr5Xzv2p3rnzLFmJ0RiKlrJ7bUx+P6w==", null, false, "cd2d1e35-9e9a-4de5-9711-391c123be1cf", false, "superadmin@lms.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("3441dfed-f084-4dc2-b805-934d31f6c33c"), new Guid("cd2d1e35-9e9a-4de5-9711-391c123be1cf") },
                    { new Guid("673b6c56-1f26-4025-8899-5e9603c4f587"), new Guid("cd2d1e35-9e9a-4de5-9711-391c123be1cf") },
                    { new Guid("7e9d0879-907f-4068-83f1-dd140714ac2d"), new Guid("cd2d1e35-9e9a-4de5-9711-391c123be1cf") }
                });
        }
    }
}
