using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HardTrain.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6fa67588-40fb-4cc2-a574-deca54a5b811"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d5ab11fd-2a52-4321-8363-031921ec5b1b", "AQAAAAEAACcQAAAAEACMlZ+wWZHT4qQLFJtqCP4+tAZftEgupNMfgtJHIkjijsBo1sE37NYMj4XAxxU75Q==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("1bdd1192-19fa-47ad-8ee4-705e02f226b7"), 0, "9cdbc4f0-18ef-425f-a001-707c9522763d", "qwe@gmail.com", false, "Harry", "Evans", false, null, "QWE@GMAIL.COM", "QWE@GMAIL.COM", "AQAAAAEAACcQAAAAEIsu09Sp+XiPC5eP11wtO1mseO+sr+D82YDATK3CjEzkWcyKV+r6I84ZOG9zesFdlg==", null, false, "bf9922e8-3c69-4dee-9961-65c70e29072c", false, "qwe@gmail.com" },
                    { new Guid("1ef65a80-45e1-4efa-8070-96ea00898357"), 0, "c7177fc3-4b79-4678-91f5-7c7997142906", "asd@gmail.com", false, "Olga", "Strange", false, null, "ASD@GMAIL.COM", "ASD@GMAIL.COM", "AQAAAAEAACcQAAAAEFdlXcOGyYBVIUaZg7TjVEM4vpFihcduC+jzvZHEHEAmwjIMANObxIOTJCXpQVlLug==", null, false, "edd31d71-3bcc-475c-8b38-b50b731baaaa", false, "asd@gmail.com" },
                    { new Guid("a0a28231-c733-4acf-aa5b-46a26e1a11ed"), 0, "a3d053cd-e538-4268-8985-02cf7f5a5964", "safd@gmail.com", false, "Oleksandr", "Bendujik", false, null, "SAFD@GMAIL.COM", "SAFD@GMAIL.COM", "AQAAAAEAACcQAAAAEOC89e/tp58Leey+5m4ptf3wNCbfhFUx8Qljg5Ts+TWgaFDZJvfFKeihYgHbTRrvwA==", null, false, "654f6985-3739-4457-8c20-439d50c1f0ff", false, "safd@gmail.com" },
                    { new Guid("e9b9bf1f-b24f-4c96-90b5-413d21943f18"), 0, "5d6e8959-1164-4b5f-85be-5dd5a6dc0c4b", "xcv@gmail.com", false, "Hloya", "Abrams", false, null, "XCV@GMAIL.COM", "ZXC@GMAIL.COM", "AQAAAAEAACcQAAAAEBym3+SJbkmPjhKxJty3aYV+zzfussy5kDoQk/9LGahwQ3VSdMKVpw4IUNjFC5ysHQ==", null, false, "2e28282b-b3ee-4e6f-bd2a-76ab43a3638c", false, "xcv@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("6f8450e1-82bf-4df0-8540-d8d85f6e409a"), new Guid("1bdd1192-19fa-47ad-8ee4-705e02f226b7") },
                    { new Guid("6f8450e1-82bf-4df0-8540-d8d85f6e409a"), new Guid("1ef65a80-45e1-4efa-8070-96ea00898357") },
                    { new Guid("6f8450e1-82bf-4df0-8540-d8d85f6e409a"), new Guid("a0a28231-c733-4acf-aa5b-46a26e1a11ed") },
                    { new Guid("b025bb01-2eb4-4d45-bb28-e3fc4c139d80"), new Guid("e9b9bf1f-b24f-4c96-90b5-413d21943f18") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6f8450e1-82bf-4df0-8540-d8d85f6e409a"), new Guid("1bdd1192-19fa-47ad-8ee4-705e02f226b7") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6f8450e1-82bf-4df0-8540-d8d85f6e409a"), new Guid("1ef65a80-45e1-4efa-8070-96ea00898357") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6f8450e1-82bf-4df0-8540-d8d85f6e409a"), new Guid("a0a28231-c733-4acf-aa5b-46a26e1a11ed") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b025bb01-2eb4-4d45-bb28-e3fc4c139d80"), new Guid("e9b9bf1f-b24f-4c96-90b5-413d21943f18") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1bdd1192-19fa-47ad-8ee4-705e02f226b7"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1ef65a80-45e1-4efa-8070-96ea00898357"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a0a28231-c733-4acf-aa5b-46a26e1a11ed"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b9bf1f-b24f-4c96-90b5-413d21943f18"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6fa67588-40fb-4cc2-a574-deca54a5b811"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5a7fd0b8-9a04-46d3-8dfd-8fd0ffacb20e", "AQAAAAEAACcQAAAAEHvOhEryLmQapgs/oAHpqSB6w8HnnMcXzE2jwgRExoZoxroatamVGXCX2nv4N1brcw==" });
        }
    }
}
