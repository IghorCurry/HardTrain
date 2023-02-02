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
                    DefaultWeight = table.Column<int>(type: "int", nullable: false),
                    DefaultReps = table.Column<int>(type: "int", nullable: false),
                    DefaultTime = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exersices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingExersices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExersiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingExersices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingExersices_Exersices_ExersiceId",
                        column: x => x.ExersiceId,
                        principalTable: "Exersices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingExersices_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExecutionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrainingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingResults_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingResults_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExersiceResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExersiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Reps = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<int>(type: "int", nullable: false),
                    TrainingResultId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExersiceResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExersiceResults_Exersices_ExersiceId",
                        column: x => x.ExersiceId,
                        principalTable: "Exersices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExersiceResults_TrainingResults_TrainingResultId",
                        column: x => x.TrainingResultId,
                        principalTable: "TrainingResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExersiceResults_ExersiceId",
                table: "ExersiceResults",
                column: "ExersiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExersiceResults_TrainingResultId",
                table: "ExersiceResults",
                column: "TrainingResultId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingExersices_ExersiceId",
                table: "TrainingExersices",
                column: "ExersiceId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingExersices_TrainingId",
                table: "TrainingExersices",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingResults_TrainingId",
                table: "TrainingResults",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingResults_UserId",
                table: "TrainingResults",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExersiceResults");

            migrationBuilder.DropTable(
                name: "TrainingExersices");

            migrationBuilder.DropTable(
                name: "TrainingResults");

            migrationBuilder.DropTable(
                name: "Exersices");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
