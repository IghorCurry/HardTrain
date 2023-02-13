using HardTrain.DAL.Setting;
using Microsoft.EntityFrameworkCore;

namespace HardTrain.DAL.DataSeeds
{
    internal static partial class TestDataSeed
    {
        public static void AddTestableData(this ModelBuilder modelBuilder, DefaultAdminSettings defaultAdminSettings)
        {
            modelBuilder.AddTestTrainings();
            modelBuilder.AddTestUsers();
            modelBuilder.AddUsers();
            modelBuilder.AddTestExersices();
            modelBuilder.AddTestTrainingExersices();
            modelBuilder.AddAdmin(defaultAdminSettings);
        }
    }
}
