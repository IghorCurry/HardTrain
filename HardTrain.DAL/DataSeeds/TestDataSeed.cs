using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardTrain.DAL.DataSeeds
{
    internal static partial class TestDataSeed
    {
        public static void AddTestableData(this ModelBuilder modelBuilder)
        {
            modelBuilder.AddTestTrainings();
        }
    }
}
