namespace HardTrain.BLL.Models.TrainingResultModels
{
    public record TrainingResultUpdateModel /*: TrainingResultCreateModel*/
    {
        public Guid Id { get; init; }
        public string Note { get; init; }//updatemodel1
    }
}
