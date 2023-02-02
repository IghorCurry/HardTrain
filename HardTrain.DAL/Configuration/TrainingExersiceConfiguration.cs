using HardTrain.DAL.Entities.TrainingScope;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HardTrain.DAL.Configuration
{
    internal class TrainingExersiceConfiguration : IEntityTypeConfiguration<TrainingExersice>
    {
        public void Configure(EntityTypeBuilder<TrainingExersice> builder)
        {
            builder.HasKey(x => x.Id);
            //builder.HasIndex(x => new { x.TenantId, x.Email }).IsUnique();

            //builder.Property(x => x.Name).IsRequired();

            builder.HasOne(x => x.Training)
                .WithMany(x => x.TrainingExersices)
                .HasForeignKey(x => x.TrainingId);
            //.OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Exersice)
               .WithMany()
               .HasForeignKey(x => x.ExersiceId);


        }


    }
}
