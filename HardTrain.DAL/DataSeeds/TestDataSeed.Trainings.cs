using HardTrain.DAL.Entities.TrainingScope;
using Microsoft.EntityFrameworkCore;

namespace HardTrain.DAL.DataSeeds
{
    internal static partial class TestDataSeed
    {
        #region Training Settings
        private static readonly Guid training1Id = new Guid("81765a78-ed6b-4c9c-aa4e-9d0652951dd8");
        private static readonly Guid training2Id = new Guid("191a9b4e-527e-419c-97a7-a4a841f91c2d");
        private static readonly Guid training3Id = new Guid("a7a151e8-7816-4dad-9ee6-a89141b6776c");
        private static readonly Guid training4Id = new Guid("60a7be00-3489-42f2-8e7a-9732ace21e1c");
        private static readonly Guid exersice1Id = new Guid("318cb157-1a66-43d2-9ebe-9f180f4c873b");
        private static readonly Guid exersice2Id = new Guid("13e3bc9b-088c-44c4-858f-5956d311b804");
        private static readonly Guid exersice3Id = new Guid("39f25e4e-3ef4-4237-b943-d6a54b084e62");
        private static readonly Guid exersice4Id = new Guid("cdac369b-ef11-468e-9c93-df5bf13e1799");
        private static readonly Guid exersice5Id = new Guid("fb51ed56-dc65-425c-ad2a-1808f9712a79");
        private static readonly Guid exersice6Id = new Guid("73ba60f0-7dfc-40ff-9405-bbaa718313ae");
        private static readonly Guid exersice7Id = new Guid("1a358bd3-a2cc-4706-a06a-05e0f06ee478");
        private static readonly Guid trainingexesice1Id = new Guid("f5a5965a-ca29-4de3-9a1a-1128b29f0f0c");
        private static readonly Guid trainingexesice2Id = new Guid("f7cab932-38f4-4606-9ab8-7636bd8f18de");
        private static readonly Guid trainingexesice3Id = new Guid("1d50e351-0aa2-4c2f-805f-242cad939202");
        private static readonly Guid trainingexesice4Id = new Guid("f0e2a2f2-a6ce-49d9-841f-966ea2171577");
        private static readonly Guid trainingexesice5Id = new Guid("acef4f0c-59fd-4bd9-b8f7-95499777aeff");
        private static readonly Guid trainingexesice6Id = new Guid("07e161db-5504-4b7c-acca-b3b0f4488e34");
        private static readonly Guid trainingexesice7Id = new Guid("9f413444-2e8b-4511-9200-02bd7e9c6d4a");


        private static readonly Guid exersice12Id = new Guid("20121070-babe-4a78-b616-41fa12e52c62");
        private static readonly Guid exersice13Id = new Guid("1ef65a80-45e1-4efa-8070-96ea00898357");
        private static readonly Guid exersice14Id = new Guid("e9b9bf1f-b24f-4c96-90b5-413d21943f18");
        private static readonly Guid exersice15Id = new Guid("db6c9bef-79ce-4b5c-8068-b4c74d8a3dca");
        private static readonly Guid exersice16Id = new Guid("ddc3f111-0235-41e1-9f58-dcc01cbfe28f");
        private static readonly Guid exersice17Id = new Guid("e19940b7-e797-40cf-8f90-dfe943bd4bf7");
        private static readonly Guid exersice18Id = new Guid("e3fd10df-fc99-457b-b396-15f99d1aa316");
        private static readonly Guid exersice19Id = new Guid("9672b63c-d619-421d-a452-580e2fe62008");
        private static readonly Guid exersice20Id = new Guid("036efaba-4048-4068-921a-ec98f8578d2d");
        private static readonly Guid exersice21Id = new Guid("2b6e49e0-765b-434e-ae55-ac76c6611249");

        #endregion Training Settings
        private static void AddTestTrainings(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Training>().HasData(
                    new Training()
                    {
                        Id = training1Id,
                        Title = "Test Arm training",
                        Description = "Train arms"
                    },

                    new Training()
                    {
                        Id = training2Id,
                        Title = "Test Chest training",
                        Description = "Train chest"
                    },
                    new Training()
                    {
                        Id = training3Id,
                        Title = "Test Legs training",
                        Description = "Train legs"
                    },
                    new Training()
                    {
                        Id = training4Id,
                        Title = "Test Back training",
                        Description = "Train back"
                    });



        }
        private static void AddTestExersices(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exersice>().HasData(
                new Exersice()
                {
                    Id = exersice1Id,
                    Title = "Test Biceps exersice",
                    Description = "Train arms",
                    Category = Enums.Category.Arm,
                    DefaultReps = 0,
                    DefaultWeight = 0
                },
                new Exersice()
                {
                    Id = exersice2Id,
                    Title = "Test Triceps exersice",
                    Description = "Train arms",
                    Category = Enums.Category.Arm,
                    DefaultReps = 0,
                    DefaultWeight = 0
                },
                new Exersice()
                {
                    Id = exersice3Id,
                    Title = "Test push ups exersice",
                    Description = "Train arms",
                    Category = Enums.Category.Chest,
                    DefaultReps = 0,
                    DefaultWeight = 0
                },
                new Exersice()
                {
                    Id = exersice4Id,
                    Title = "Test fly chest exersice",
                    Description = "Train arms",
                    Category = Enums.Category.Chest,
                    DefaultReps = 0,
                    DefaultWeight = 0
                },
                new Exersice()
                {
                    Id = exersice5Id,
                    Title = "Test squats exersice",
                    Description = "Train arms",
                    Category = Enums.Category.Legs,
                    DefaultReps = 0,
                    DefaultWeight = 0
                },
                new Exersice()
                {
                    Id = exersice6Id,
                    Title = "Test pull ups exersice",
                    Description = "Train arms",
                    Category = Enums.Category.Back,
                    DefaultReps = 0,
                    DefaultWeight = 0
                },
                new Exersice()
                {
                    Id = exersice7Id,
                    Title = "Test dead lift exersice",
                    Description = "Train arms",
                    Category = Enums.Category.Back,
                    DefaultReps = 0,
                    DefaultWeight = 0
                });
        }
        private static void AddTestTrainingExersices(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrainingExersice>().HasData(
                    new TrainingExersice()
                    {
                        Id = trainingexesice1Id,
                        TrainingId = training1Id,
                        ExersiceId = exersice1Id,
                    },
                    new TrainingExersice()
                    {
                        Id = trainingexesice2Id,
                        TrainingId = training1Id,
                        ExersiceId = exersice2Id
                    },
                    new TrainingExersice()
                    {
                        Id = trainingexesice3Id,
                        TrainingId = training2Id,
                        ExersiceId = exersice3Id,
                    },
                    new TrainingExersice()
                    {
                        Id = trainingexesice4Id,
                        TrainingId = training2Id,
                        ExersiceId = exersice4Id
                    },
                    new TrainingExersice()
                    {
                        Id = trainingexesice5Id,
                        TrainingId = training3Id,
                        ExersiceId = exersice5Id,
                    },
                    new TrainingExersice()
                    {
                        Id = trainingexesice6Id,
                        TrainingId = training4Id,
                        ExersiceId = exersice6Id,
                    },
                    new TrainingExersice()
                    {
                        Id = trainingexesice7Id,
                        TrainingId = training4Id,
                        ExersiceId = exersice7Id
                    });
        }
    }
}
