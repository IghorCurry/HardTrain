using HardTrain.DAL.Entities.UserResultScope;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HardTrain.DAL.Configuration
{
    internal class ExersiceResultConfiguration : IEntityTypeConfiguration<ExersiceResult>
    {
        public void Configure(EntityTypeBuilder<ExersiceResult> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne<TrainingResult>(s => s.TrainingResult)
            .WithMany(t => t.ExersiceResults)
            .HasForeignKey(f => f.TrainingResultId);
        }

    }
}
