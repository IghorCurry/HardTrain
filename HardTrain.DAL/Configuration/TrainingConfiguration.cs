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
        }
    }
}
