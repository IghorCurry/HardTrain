namespace HardTrain.BLL.Models.ExersiceResultModels
{
    public record ExersiceResultCreateModel
    {
        public Guid ExersiceId { get; init; }

        public int Weight { get; init; }

        public int Reps { get; init; }

        public Guid TrainingResultId { get; init; }

    }
}
