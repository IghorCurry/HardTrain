namespace HardTrain.BLL.Models.TrainingModels
{
    public record TrainingUpdateModel : TrainingCreateModel
    {
        public Guid Id { get; init; }
    }
}
