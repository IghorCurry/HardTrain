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

            builder.HasOne(x => x.Training)
                .WithMany(x => x.TrainingExersices)
                .HasForeignKey(x => x.TrainingId);

            builder.HasOne(x => x.Exersice)
               .WithMany()
               .HasForeignKey(x => x.ExersiceId);


        }


    }
}
