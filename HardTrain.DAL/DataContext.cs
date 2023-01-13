using HardTrain.DAL.Entities.ExersiceEntities;
using Microsoft.EntityFrameworkCore;

namespace HardTrain.DAL
{
    public class DataContext : DbContext
    {
        public DbSet<Exersice> Exersices { get; set; }

        public DbSet<TemplateExersice> ExersiceTemplates { get; set; }

        public DbSet<TrainingTemplate> TrainingTemplates { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
