using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HardTrain.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIdFromUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6fa67588-40fb-4cc2-a574-deca54a5b811"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3250c765-0e6a-4bce-84e9-7b78b248e8b8", "AQAAAAEAACcQAAAAELGd1vdY6Kllcait2q90d+guwdVuoTUhgmMmGtGJFfngrYsRqVfMXvW19vQFDcl5+Q==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6fa67588-40fb-4cc2-a574-deca54a5b811"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b0716f40-3e2a-40b5-8bce-5320113b77cf", "AQAAAAEAACcQAAAAECOcH4jPXVFzWuaqezB/oVI+VExM8JpyjAc3hyx2/r5obJax+arN+fr48Yr2jO2XtA==" });
        }
    }
}
