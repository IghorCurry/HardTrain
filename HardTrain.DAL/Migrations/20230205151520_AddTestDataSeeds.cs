using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HardTrain.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddTestDataSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("1bdd1192-19fa-47ad-8ee4-705e02f226b7"), 0, "d6b05e7e-7d8e-44e8-9e40-a463cde5c0d5", "test@gmail.com", false, "Harry", "Evans", false, null, null, null, null, null, false, null, false, null },
                    { new Guid("a0a28231-c733-4acf-aa5b-46a26e1a11ed"), 0, "e308b5ff-5b41-4bc1-a1de-a5e52589d6b6", "gg@gmail.com", false, "Oleksandr", "Bendujik", false, null, null, null, null, null, false, null, false, null }
                });

            migrationBuilder.InsertData(
                table: "Exersices",
                columns: new[] { "Id", "Category", "DefaultReps", "DefaultTime", "DefaultWeight", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("13e3bc9b-088c-44c4-858f-5956d311b804"), 0, 0, 0, 0, "Train arms", "Test Triceps exersice" },
                    { new Guid("1a358bd3-a2cc-4706-a06a-05e0f06ee478"), 3, 0, 0, 0, "Train arms", "Test dead lift exersice" },
                    { new Guid("318cb157-1a66-43d2-9ebe-9f180f4c873b"), 0, 0, 0, 0, "Train arms", "Test Biceps exersice" },
                    { new Guid("39f25e4e-3ef4-4237-b943-d6a54b084e62"), 1, 0, 0, 0, "Train arms", "Test push ups exersice" },
                    { new Guid("73ba60f0-7dfc-40ff-9405-bbaa718313ae"), 3, 0, 0, 0, "Train arms", "Test pull ups exersice" },
                    { new Guid("cdac369b-ef11-468e-9c93-df5bf13e1799"), 1, 0, 0, 0, "Train arms", "Test fly chest exersice" },
                    { new Guid("fb51ed56-dc65-425c-ad2a-1808f9712a79"), 2, 0, 0, 0, "Train arms", "Test squats exersice" }
                });

            migrationBuilder.InsertData(
                table: "Trainings",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("191a9b4e-527e-419c-97a7-a4a841f91c2d"), "Train chest", "Test Chest training" },
                    { new Guid("60a7be00-3489-42f2-8e7a-9732ace21e1c"), "Train back", "Test Back training" },
                    { new Guid("81765a78-ed6b-4c9c-aa4e-9d0652951dd8"), "Train arms", "Test Arm training" },
                    { new Guid("a7a151e8-7816-4dad-9ee6-a89141b6776c"), "Train legs", "Test Legs training" }
                });

            migrationBuilder.InsertData(
                table: "TrainingExersices",
                columns: new[] { "Id", "ExersiceId", "TrainingId" },
                values: new object[,]
                {
                    { new Guid("07e161db-5504-4b7c-acca-b3b0f4488e34"), new Guid("73ba60f0-7dfc-40ff-9405-bbaa718313ae"), new Guid("60a7be00-3489-42f2-8e7a-9732ace21e1c") },
                    { new Guid("1d50e351-0aa2-4c2f-805f-242cad939202"), new Guid("39f25e4e-3ef4-4237-b943-d6a54b084e62"), new Guid("191a9b4e-527e-419c-97a7-a4a841f91c2d") },
                    { new Guid("9f413444-2e8b-4511-9200-02bd7e9c6d4a"), new Guid("1a358bd3-a2cc-4706-a06a-05e0f06ee478"), new Guid("60a7be00-3489-42f2-8e7a-9732ace21e1c") },
                    { new Guid("acef4f0c-59fd-4bd9-b8f7-95499777aeff"), new Guid("fb51ed56-dc65-425c-ad2a-1808f9712a79"), new Guid("a7a151e8-7816-4dad-9ee6-a89141b6776c") },
                    { new Guid("f0e2a2f2-a6ce-49d9-841f-966ea2171577"), new Guid("cdac369b-ef11-468e-9c93-df5bf13e1799"), new Guid("191a9b4e-527e-419c-97a7-a4a841f91c2d") },
                    { new Guid("f5a5965a-ca29-4de3-9a1a-1128b29f0f0c"), new Guid("318cb157-1a66-43d2-9ebe-9f180f4c873b"), new Guid("81765a78-ed6b-4c9c-aa4e-9d0652951dd8") },
                    { new Guid("f7cab932-38f4-4606-9ab8-7636bd8f18de"), new Guid("13e3bc9b-088c-44c4-858f-5956d311b804"), new Guid("81765a78-ed6b-4c9c-aa4e-9d0652951dd8") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1bdd1192-19fa-47ad-8ee4-705e02f226b7"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a0a28231-c733-4acf-aa5b-46a26e1a11ed"));

            migrationBuilder.DeleteData(
                table: "TrainingExersices",
                keyColumn: "Id",
                keyValue: new Guid("07e161db-5504-4b7c-acca-b3b0f4488e34"));

            migrationBuilder.DeleteData(
                table: "TrainingExersices",
                keyColumn: "Id",
                keyValue: new Guid("1d50e351-0aa2-4c2f-805f-242cad939202"));

            migrationBuilder.DeleteData(
                table: "TrainingExersices",
                keyColumn: "Id",
                keyValue: new Guid("9f413444-2e8b-4511-9200-02bd7e9c6d4a"));

            migrationBuilder.DeleteData(
                table: "TrainingExersices",
                keyColumn: "Id",
                keyValue: new Guid("acef4f0c-59fd-4bd9-b8f7-95499777aeff"));

            migrationBuilder.DeleteData(
                table: "TrainingExersices",
                keyColumn: "Id",
                keyValue: new Guid("f0e2a2f2-a6ce-49d9-841f-966ea2171577"));

            migrationBuilder.DeleteData(
                table: "TrainingExersices",
                keyColumn: "Id",
                keyValue: new Guid("f5a5965a-ca29-4de3-9a1a-1128b29f0f0c"));

            migrationBuilder.DeleteData(
                table: "TrainingExersices",
                keyColumn: "Id",
                keyValue: new Guid("f7cab932-38f4-4606-9ab8-7636bd8f18de"));

            migrationBuilder.DeleteData(
                table: "Exersices",
                keyColumn: "Id",
                keyValue: new Guid("13e3bc9b-088c-44c4-858f-5956d311b804"));

            migrationBuilder.DeleteData(
                table: "Exersices",
                keyColumn: "Id",
                keyValue: new Guid("1a358bd3-a2cc-4706-a06a-05e0f06ee478"));

            migrationBuilder.DeleteData(
                table: "Exersices",
                keyColumn: "Id",
                keyValue: new Guid("318cb157-1a66-43d2-9ebe-9f180f4c873b"));

            migrationBuilder.DeleteData(
                table: "Exersices",
                keyColumn: "Id",
                keyValue: new Guid("39f25e4e-3ef4-4237-b943-d6a54b084e62"));

            migrationBuilder.DeleteData(
                table: "Exersices",
                keyColumn: "Id",
                keyValue: new Guid("73ba60f0-7dfc-40ff-9405-bbaa718313ae"));

            migrationBuilder.DeleteData(
                table: "Exersices",
                keyColumn: "Id",
                keyValue: new Guid("cdac369b-ef11-468e-9c93-df5bf13e1799"));

            migrationBuilder.DeleteData(
                table: "Exersices",
                keyColumn: "Id",
                keyValue: new Guid("fb51ed56-dc65-425c-ad2a-1808f9712a79"));

            migrationBuilder.DeleteData(
                table: "Trainings",
                keyColumn: "Id",
                keyValue: new Guid("191a9b4e-527e-419c-97a7-a4a841f91c2d"));

            migrationBuilder.DeleteData(
                table: "Trainings",
                keyColumn: "Id",
                keyValue: new Guid("60a7be00-3489-42f2-8e7a-9732ace21e1c"));

            migrationBuilder.DeleteData(
                table: "Trainings",
                keyColumn: "Id",
                keyValue: new Guid("81765a78-ed6b-4c9c-aa4e-9d0652951dd8"));

            migrationBuilder.DeleteData(
                table: "Trainings",
                keyColumn: "Id",
                keyValue: new Guid("a7a151e8-7816-4dad-9ee6-a89141b6776c"));
        }
    }
}
