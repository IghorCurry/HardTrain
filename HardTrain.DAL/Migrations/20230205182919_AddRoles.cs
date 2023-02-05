using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HardTrain.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1bdd1192-19fa-47ad-8ee4-705e02f226b7"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a0a28231-c733-4acf-aa5b-46a26e1a11ed"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("6f8450e1-82bf-4df0-8540-d8d85f6e409a"), "2", "Client", "CLIENT" },
                    { new Guid("b13c0935-3467-4fa9-ae84-267197263f25"), "1", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6f8450e1-82bf-4df0-8540-d8d85f6e409a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b13c0935-3467-4fa9-ae84-267197263f25"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("1bdd1192-19fa-47ad-8ee4-705e02f226b7"), 0, "d6b05e7e-7d8e-44e8-9e40-a463cde5c0d5", "test@gmail.com", false, "Harry", "Evans", false, null, null, null, null, null, false, null, false, null },
                    { new Guid("a0a28231-c733-4acf-aa5b-46a26e1a11ed"), 0, "e308b5ff-5b41-4bc1-a1de-a5e52589d6b6", "gg@gmail.com", false, "Oleksandr", "Bendujik", false, null, null, null, null, null, false, null, false, null }
                });
        }
    }
}
