namespace HardTrain.BLL.Models.ExersiceResultModels
{
    public record ExersiceResultUpdateModel : ExersiceResultCreateModel
    {
        public Guid Id { get; init; }
    }
}
