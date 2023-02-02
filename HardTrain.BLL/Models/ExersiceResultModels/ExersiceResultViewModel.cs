using HardTrain.DAL.Entities.TrainingScope;
using HardTrain.DAL.Entities.UserResultScope;

namespace HardTrain.BLL.Models.ExersiceResultModels
{
    public class ExersiceResultViewModel
    {
        public Guid Id { get; init; }

        public Guid ExersiceId { get; init; }

        public int Weight { get; init; }

        public int Reps { get; init; }

        public int Time { get; init; }

        public Guid TrainingResultId { get; init; }
    }
}
