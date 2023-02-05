using HardTrain.DAL.Configuration;
using HardTrain.DAL.DataSeeds;
using HardTrain.DAL.Entities.TrainingScope;
using HardTrain.DAL.Entities.UserResultScope;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SharedModules.Application.Common.Abstractions;

namespace HardTrain.DAL
{
    public class DataContext : IdentityDbContext<User, Role, Guid>, IDataContext
    { 
        public DbSet<Exersice> Exersices { get; set; }

        public DbSet<TrainingExersice> TrainingExersices { get; set; }

        public DbSet<Training> Trainings { get; set; }

        public DbSet<ExersiceResult> ExersiceResults { get; set; }
        public DbSet<TrainingResult> TrainingResults { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ExersiceConfiguration());
            modelBuilder.ApplyConfiguration(new TrainingConfiguration());
            modelBuilder.ApplyConfiguration(new TrainingExersiceConfiguration());
            modelBuilder.ApplyConfiguration(new ExersiceResultConfiguration());
            modelBuilder.ApplyConfiguration(new TrainingResultConfiguration());

            modelBuilder.AddTestableData();
        }
    }
}
