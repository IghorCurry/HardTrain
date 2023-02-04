using HardTrain.BLL.Models.TrainingResultModels;
using HardTrain.BLL.Models.UserModels;
using HardTrain.DAL.Entities.UserResultScope;
using Mapster;

namespace HardTrain.BLL.Helper
{
    public class MapsterConfig
    {
        public static void ConfigureMapping()
        {
            TypeAdapterConfig<TrainingResult, TrainingResultViewModel>.NewConfig()
                            .Map(dest => dest.ExersiceResults, src => src.ExersiceResults.Select(x => x.Exersice));

            TypeAdapterConfig<User, UserViewModel>.NewConfig()
                            .Map(dest => dest.TrainingResults, src => src.TrainingResults.Select(x => x.Training));
        }
    }
}
