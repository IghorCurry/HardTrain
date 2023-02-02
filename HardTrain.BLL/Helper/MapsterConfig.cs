using HardTrain.BLL.Models.TrainingModels;
using HardTrain.DAL.Entities.TrainingScope;
using Mapster;

namespace HardTrain.BLL.Helper
{
    public class MapsterConfig
    {
        public static void ConfigureMapping()
        {
            //TypeAdapterConfig<Training, TrainingViewModel>.NewConfig()
            //                .Map(dest => dest.Technologies, src => src.Technologies.Select(x => x.Technology));
        }
    }
}
