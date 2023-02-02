using HardTrain.DAL.Entities.TrainingScope;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HardTrain.DAL.Entities.UserResultScope;

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
