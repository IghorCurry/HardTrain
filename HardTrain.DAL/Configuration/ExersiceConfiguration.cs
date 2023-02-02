using HardTrain.DAL.Entities.TrainingScope;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HardTrain.DAL.Configuration
{
    internal class ExersiceConfiguration : IEntityTypeConfiguration<Exersice>
    {
        public void Configure(EntityTypeBuilder<Exersice> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
