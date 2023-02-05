using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HardTrain.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RemoteIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiresAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6fa67588-40fb-4cc2-a574-deca54a5b811"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b0716f40-3e2a-40b5-8bce-5320113b77cf", "AQAAAAEAACcQAAAAECOcH4jPXVFzWuaqezB/oVI+VExM8JpyjAc3hyx2/r5obJax+arN+fr48Yr2jO2XtA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6fa67588-40fb-4cc2-a574-deca54a5b811"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7eed8c09-a3d0-47b9-9a2f-e2a7d9b1717c", "AQAAAAEAACcQAAAAEN3KP0khcfUgNrOmeaXOtfGIdinLFkmwYicU92Yf+WtK2GxUsKwuzoSJJGI+xa+uSg==" });
        }
    }
}
