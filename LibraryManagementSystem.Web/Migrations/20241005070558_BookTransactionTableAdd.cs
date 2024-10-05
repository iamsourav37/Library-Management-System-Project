using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagementSystem.Web.Migrations
{
    /// <inheritdoc />
    public partial class BookTransactionTableAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "BookTransactions",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BorrowedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PenaltyAmount = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTransactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_BookTransactions_AspNetUsers_MemberId",
                        column: x => x.MemberId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookTransactions_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("cdf2c36b-0a4b-4127-95ec-0f4caebdb5a0"), "cdf2c36b-0a4b-4127-95ec-0f4caebdb5a0", "Admin", "ADMIN" },
                    { new Guid("d22c49ec-2828-4958-8aeb-5f29429ccf96"), "d22c49ec-2828-4958-8aeb-5f29429ccf96", "Member", "Member" },
                    { new Guid("e1f74b95-d5c1-44a7-85ca-8ce22dfa679c"), "e1f74b95-d5c1-44a7-85ca-8ce22dfa679c", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address1", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("a1b45806-a76a-426b-9b99-ac01b39c1fae"), 0, null, "3a9b6a54-9cb7-4b49-9373-f1f387804756", "superadmin@lms.com", false, false, null, "Sourav Ganguly", "SUPERADMIN@LMS.COM", "SUPERADMIN@LMS.COM", "AQAAAAIAAYagAAAAECJ4QeJnH2FQwW5wUh1ETIB5BlE+GIua6VHU84Fitabe1eBstllWCOwDn6e7ForPtg==", null, false, "a1b45806-a76a-426b-9b99-ac01b39c1fae", false, "superadmin@lms.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("cdf2c36b-0a4b-4127-95ec-0f4caebdb5a0"), new Guid("a1b45806-a76a-426b-9b99-ac01b39c1fae") },
                    { new Guid("d22c49ec-2828-4958-8aeb-5f29429ccf96"), new Guid("a1b45806-a76a-426b-9b99-ac01b39c1fae") },
                    { new Guid("e1f74b95-d5c1-44a7-85ca-8ce22dfa679c"), new Guid("a1b45806-a76a-426b-9b99-ac01b39c1fae") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookTransactions_BookId",
                table: "BookTransactions",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookTransactions_MemberId",
                table: "BookTransactions",
                column: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookTransactions");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cdf2c36b-0a4b-4127-95ec-0f4caebdb5a0"), new Guid("a1b45806-a76a-426b-9b99-ac01b39c1fae") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("d22c49ec-2828-4958-8aeb-5f29429ccf96"), new Guid("a1b45806-a76a-426b-9b99-ac01b39c1fae") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e1f74b95-d5c1-44a7-85ca-8ce22dfa679c"), new Guid("a1b45806-a76a-426b-9b99-ac01b39c1fae") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cdf2c36b-0a4b-4127-95ec-0f4caebdb5a0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d22c49ec-2828-4958-8aeb-5f29429ccf96"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1f74b95-d5c1-44a7-85ca-8ce22dfa679c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a1b45806-a76a-426b-9b99-ac01b39c1fae"));

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
        }
    }
}
