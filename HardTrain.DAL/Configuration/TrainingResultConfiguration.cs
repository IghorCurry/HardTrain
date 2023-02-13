using HardTrain.DAL.Entities.UserResultScope;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HardTrain.DAL.Configuration
{
    internal class TrainingResultConfiguration : IEntityTypeConfiguration<TrainingResult>
    {
        public void Configure(EntityTypeBuilder<TrainingResult> builder)
        {
            builder.HasKey(x => x.Id);


            builder.HasOne<User>(s => s.User)
            .WithMany(t => t.TrainingResults)
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        }

    }
}
