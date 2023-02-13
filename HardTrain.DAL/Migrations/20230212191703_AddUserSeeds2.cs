using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HardTrain.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddUserSeeds2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1bdd1192-19fa-47ad-8ee4-705e02f226b7"),
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "12bc04c5-564a-432a-85e7-d739b526a393", "user2@gmail.com", "USER2@GMAIL.COM", "USER2@GMAIL.COM", "AQAAAAEAACcQAAAAEOgtukciGPv3nqCg0ttbAIyQLE5sKRvaDXVeIgLSkSz3hA1pGKQrnR6sg+P+gK1k1w==", "user2@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1ef65a80-45e1-4efa-8070-96ea00898357"),
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "afb936bd-b36f-4d8f-a2fe-9fce1aa4090a", "user3@gmail.com", "USER3@GMAIL.COM", "USER3@GMAIL.COM", "AQAAAAEAACcQAAAAELeTypKZzJGYKp4eqmMe7hoiNB4Vqm8dpQRCJpQVyRjfePmj8c6sPl6jzTGXnEhLkA==", "user3@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6fa67588-40fb-4cc2-a574-deca54a5b811"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "10a4b597-1764-4192-a862-2c085c351ebb", "AQAAAAEAACcQAAAAEKt/hqBFTYytkGMOcKnIxcCBNC8eFFU8Uv1DJt0DLEOL3ciwS8OZhfIbDVgEXe4GcA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a0a28231-c733-4acf-aa5b-46a26e1a11ed"),
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "16790557-aab8-46bf-b65a-db593cb81e12", "user1@gmail.com", "USER1@GMAIL.COM", "USER1@GMAIL.COM", "AQAAAAEAACcQAAAAEI3x7bkDy4RREUcyiISv+rJlAm5TvpovSVQYN2G/3wbAxCiZuw8rEWiiU/eUB+KZvA==", "user1@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b9bf1f-b24f-4c96-90b5-413d21943f18"),
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "956aaf0f-87da-42e5-9f77-22cff88af77c", "manager@gmail.com", "MANAGER@GMAIL.COM", "MANAGER@GMAIL.COM", "AQAAAAEAACcQAAAAEENrUm5e29EIsKF7Pi8N9OCIxtiNtk6XOwgsFBejP4My6/amoK8s620A0BH9D4arBw==", "manager@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1bdd1192-19fa-47ad-8ee4-705e02f226b7"),
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "9cdbc4f0-18ef-425f-a001-707c9522763d", "qwe@gmail.com", "QWE@GMAIL.COM", "QWE@GMAIL.COM", "AQAAAAEAACcQAAAAEIsu09Sp+XiPC5eP11wtO1mseO+sr+D82YDATK3CjEzkWcyKV+r6I84ZOG9zesFdlg==", "qwe@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1ef65a80-45e1-4efa-8070-96ea00898357"),
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "c7177fc3-4b79-4678-91f5-7c7997142906", "asd@gmail.com", "ASD@GMAIL.COM", "ASD@GMAIL.COM", "AQAAAAEAACcQAAAAEFdlXcOGyYBVIUaZg7TjVEM4vpFihcduC+jzvZHEHEAmwjIMANObxIOTJCXpQVlLug==", "asd@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6fa67588-40fb-4cc2-a574-deca54a5b811"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d5ab11fd-2a52-4321-8363-031921ec5b1b", "AQAAAAEAACcQAAAAEACMlZ+wWZHT4qQLFJtqCP4+tAZftEgupNMfgtJHIkjijsBo1sE37NYMj4XAxxU75Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a0a28231-c733-4acf-aa5b-46a26e1a11ed"),
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "a3d053cd-e538-4268-8985-02cf7f5a5964", "safd@gmail.com", "SAFD@GMAIL.COM", "SAFD@GMAIL.COM", "AQAAAAEAACcQAAAAEOC89e/tp58Leey+5m4ptf3wNCbfhFUx8Qljg5Ts+TWgaFDZJvfFKeihYgHbTRrvwA==", "safd@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b9bf1f-b24f-4c96-90b5-413d21943f18"),
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "5d6e8959-1164-4b5f-85be-5dd5a6dc0c4b", "xcv@gmail.com", "XCV@GMAIL.COM", "ZXC@GMAIL.COM", "AQAAAAEAACcQAAAAEBym3+SJbkmPjhKxJty3aYV+zzfussy5kDoQk/9LGahwQ3VSdMKVpw4IUNjFC5ysHQ==", "xcv@gmail.com" });
        }
    }
}
