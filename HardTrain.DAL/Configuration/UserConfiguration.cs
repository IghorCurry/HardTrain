using HardTrain.DAL.Entities.UserResultScope;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardTrain.DAL.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany<TrainingResult>(g => g.TrainingResults)
            .WithOne(s => s.User)
            .HasForeignKey(s => s.UserId);
        }
    }
}
