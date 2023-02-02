using HardTrain.DAL.Entities.UserResultScope;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection.Emit;

namespace HardTrain.DAL.Configuration
{
    internal class TrainingResultConfiguration : IEntityTypeConfiguration<TrainingResult>
    {
        public void Configure(EntityTypeBuilder<TrainingResult> builder)
        {
            builder.HasKey(x => x.Id);

            
            builder.HasOne<User>(s => s.User)
            .WithMany(t => t.TrainingResults)
            .HasForeignKey(f => f.UserId);
        }

    }
}
