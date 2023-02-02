using HardTrain.DAL.Entities.TrainingScope;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HardTrain.DAL.Configuration
{
    internal class TrainingConfiguration : IEntityTypeConfiguration<Training>
    {
        public void Configure(EntityTypeBuilder<Training> builder)
        {
            builder.HasKey(x => x.Id);
            //builder.HasIndex(x => new { x.TenantId, x.Email }).IsUnique();

            //builder.Property(x => x.Name).IsRequired();

            //builder.HasOne(x => x.TrainingExersices)
            //    .WithMany(x => x.Employees)
            //    .HasForeignKey(x => x.JobTitleId)
            //    .OnDelete(DeleteBehavior.SetNull);

        }

    }
}
