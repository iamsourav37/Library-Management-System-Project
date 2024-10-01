using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagementSystem.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddAddressToRequestMemberTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("052c16be-0174-47f1-a609-7cd276204f51"), new Guid("419417c0-693c-44ab-b4ca-8d751b5274e6") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f8a341db-52b8-4530-9205-1f6fb2cb128a"), new Guid("419417c0-693c-44ab-b4ca-8d751b5274e6") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f8e06332-1c19-482b-a993-773b8bf29393"), new Guid("419417c0-693c-44ab-b4ca-8d751b5274e6") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("052c16be-0174-47f1-a609-7cd276204f51"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f8a341db-52b8-4530-9205-1f6fb2cb128a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f8e06332-1c19-482b-a993-773b8bf29393"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("419417c0-693c-44ab-b4ca-8d751b5274e6"));

            migrationBuilder.AddColumn<string>(
                name: "Address1",
                table: "RequestMember",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2df918ba-b07f-4b1b-ad73-ef3a4aefc907"), "2df918ba-b07f-4b1b-ad73-ef3a4aefc907", "Member", "Member" },
                    { new Guid("2ead4989-d6f7-4091-a836-03067bcc7359"), "2ead4989-d6f7-4091-a836-03067bcc7359", "SuperAdmin", "SUPERADMIN" },
                    { new Guid("a2b86bb5-fdcb-47ec-ba12-49d20d5807aa"), "a2b86bb5-fdcb-47ec-ba12-49d20d5807aa", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address1", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("42412138-01af-49ca-b112-e1908d77f754"), 0, null, "6dd8ac95-47c0-4cc9-b5d9-35a38bca2e04", "superadmin@lms.com", false, false, null, "Sourav Ganguly", "SUPERADMIN@LMS.COM", "SUPERADMIN@LMS.COM", "AQAAAAIAAYagAAAAEBJY5veFbeC0AgR9v6hwBSmNgPsjtaqWsBrAiUxKK6SN9uxahhLns012oxlAZGfMYQ==", null, false, null, false, "superadmin@lms.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("2df918ba-b07f-4b1b-ad73-ef3a4aefc907"), new Guid("42412138-01af-49ca-b112-e1908d77f754") },
                    { new Guid("2ead4989-d6f7-4091-a836-03067bcc7359"), new Guid("42412138-01af-49ca-b112-e1908d77f754") },
                    { new Guid("a2b86bb5-fdcb-47ec-ba12-49d20d5807aa"), new Guid("42412138-01af-49ca-b112-e1908d77f754") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2df918ba-b07f-4b1b-ad73-ef3a4aefc907"), new Guid("42412138-01af-49ca-b112-e1908d77f754") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2ead4989-d6f7-4091-a836-03067bcc7359"), new Guid("42412138-01af-49ca-b112-e1908d77f754") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a2b86bb5-fdcb-47ec-ba12-49d20d5807aa"), new Guid("42412138-01af-49ca-b112-e1908d77f754") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2df918ba-b07f-4b1b-ad73-ef3a4aefc907"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2ead4989-d6f7-4091-a836-03067bcc7359"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a2b86bb5-fdcb-47ec-ba12-49d20d5807aa"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("42412138-01af-49ca-b112-e1908d77f754"));

            migrationBuilder.DropColumn(
                name: "Address1",
                table: "RequestMember");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("052c16be-0174-47f1-a609-7cd276204f51"), "052c16be-0174-47f1-a609-7cd276204f51", "Admin", "ADMIN" },
                    { new Guid("f8a341db-52b8-4530-9205-1f6fb2cb128a"), "f8a341db-52b8-4530-9205-1f6fb2cb128a", "SuperAdmin", "SUPERADMIN" },
                    { new Guid("f8e06332-1c19-482b-a993-773b8bf29393"), "f8e06332-1c19-482b-a993-773b8bf29393", "Member", "Member" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address1", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("419417c0-693c-44ab-b4ca-8d751b5274e6"), 0, null, "103e7505-ed39-410d-a6d2-463f9c8e499b", "superadmin@lms.com", false, false, null, "Sourav Ganguly", "SUPERADMIN@LMS.COM", "SUPERADMIN@LMS.COM", "AQAAAAIAAYagAAAAEM+COKIRX9x5ZhelpznfqjSTRmbet/faF43LK0eu7WYcwFYMuJQ/E6ZKjJpymg1yrw==", null, false, null, false, "superadmin@lms.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("052c16be-0174-47f1-a609-7cd276204f51"), new Guid("419417c0-693c-44ab-b4ca-8d751b5274e6") },
                    { new Guid("f8a341db-52b8-4530-9205-1f6fb2cb128a"), new Guid("419417c0-693c-44ab-b4ca-8d751b5274e6") },
                    { new Guid("f8e06332-1c19-482b-a993-773b8bf29393"), new Guid("419417c0-693c-44ab-b4ca-8d751b5274e6") }
                });
        }
    }
}
