using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HardTrain.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exersices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exersices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExersiceTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Reps = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<int>(type: "int", nullable: false),
                    ExersiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExersiceKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainingKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExersiceTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExersiceTemplates_Exersices_ExersiceKey",
                        column: x => x.ExersiceKey,
                        principalTable: "Exersices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExersiceTemplates_TrainingTemplates_TrainingKey",
                        column: x => x.TrainingKey,
                        principalTable: "TrainingTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExersiceTemplates_ExersiceKey",
                table: "ExersiceTemplates",
                column: "ExersiceKey");

            migrationBuilder.CreateIndex(
                name: "IX_ExersiceTemplates_TrainingKey",
                table: "ExersiceTemplates",
                column: "TrainingKey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExersiceTemplates");

            migrationBuilder.DropTable(
                name: "Exersices");

            migrationBuilder.DropTable(
                name: "TrainingTemplates");
        }
    }
}
