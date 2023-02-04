using HardTrain.BLL.Models.ExersiceResultModels;

namespace HardTrain.BLL.Models.TrainingResultModels
{
    public record TrainingResultCreateModel
    {
        public DateTime ExecutionDate { get; init; }

        public Guid TrainingId { get; init; }

        public ICollection<ExersiceResultCreateModel> ExersiceResults { get; init; }

    }
}
