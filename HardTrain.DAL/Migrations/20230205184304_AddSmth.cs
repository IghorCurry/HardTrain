using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HardTrain.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddSmth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("6fa67588-40fb-4cc2-a574-deca54a5b811"), 0, "7eed8c09-a3d0-47b9-9a2f-e2a7d9b1717c", "admin@gmail.com", false, "Admin", "Default", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEN3KP0khcfUgNrOmeaXOtfGIdinLFkmwYicU92Yf+WtK2GxUsKwuzoSJJGI+xa+uSg==", null, false, "1cf5e64d-1c2f-466e-9978-636a70a10347", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("b13c0935-3467-4fa9-ae84-267197263f25"), new Guid("6fa67588-40fb-4cc2-a574-deca54a5b811") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b13c0935-3467-4fa9-ae84-267197263f25"), new Guid("6fa67588-40fb-4cc2-a574-deca54a5b811") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6fa67588-40fb-4cc2-a574-deca54a5b811"));
        }
    }
}
