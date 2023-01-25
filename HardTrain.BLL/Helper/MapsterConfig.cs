using HardTrain.BLL.Models;
using HardTrain.DAL.Entities.ExersiceEntities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardTrain.BLL.Helper
{
    public class MapsterConfig
    {
        public static void ConfigureMapping()
        {
            //TypeAdapterConfig<Exersice, ExersiceViewModel>.NewConfig()
            //                .Map(dest => dest.Technologies, src => src.Technologies.Select(x => x.Technology));
        }
    }
}
