using HardTrain.DAL.Configuration;
using HardTrain.DAL.DataSeeds;
using HardTrain.DAL.Entities.TrainingScope;
using HardTrain.DAL.Entities.UserResultScope;
using HardTrain.DAL.Setting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SharedModules.Application.Common.Abstractions;
using SharedModules.Infrastructure.Identity.Models;

namespace HardTrain.DAL
{
    public class DataContext : IdentityDbContext<User, Role, Guid>, IDataContext
    {
       
        private DefaultAdminSettings _defaultAdminSettings { get; init; }
        public DataContext(DbContextOptions<DataContext> options, IOptions<DefaultAdminSettings> defaultAdminSettings) : base(options)
        {
            _defaultAdminSettings = defaultAdminSettings.Value;

        }
        public DbSet<Exersice> Exersices { get; set; }
        public DbSet<TrainingExersice> TrainingExersices { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<ExersiceResult> ExersiceResults { get; set; }
        public DbSet<TrainingResult> TrainingResults { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ExersiceConfiguration());
            modelBuilder.ApplyConfiguration(new TrainingConfiguration());
            modelBuilder.ApplyConfiguration(new TrainingExersiceConfiguration());
            modelBuilder.ApplyConfiguration(new ExersiceResultConfiguration());
            modelBuilder.ApplyConfiguration(new TrainingResultConfiguration());

            modelBuilder.AddTestableData(_defaultAdminSettings);
        }
    }
}
