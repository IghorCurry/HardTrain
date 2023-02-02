using HardTrain.DAL.Configuration;
using HardTrain.DAL.Entities.TrainingScope;
using HardTrain.DAL.Entities.UserResultScope;
using Microsoft.EntityFrameworkCore;

namespace HardTrain.DAL
{
    public class DataContext : DbContext
    {
        public DbSet<Exersice> Exersices { get; set; }

        public DbSet<TrainingExersice> TrainingExersices { get; set; }

        public DbSet<Training> Trainings { get; set; }

        public DbSet<ExersiceResult> ExersiceResults { get; set; }
        public DbSet<TrainingResult> TrainingResults { get; set; }
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ExersiceConfiguration());
            modelBuilder.ApplyConfiguration(new TrainingConfiguration());
            modelBuilder.ApplyConfiguration(new TrainingExersiceConfiguration());
        }
    }
}
