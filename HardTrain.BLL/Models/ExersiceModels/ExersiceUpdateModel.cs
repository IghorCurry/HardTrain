namespace HardTrain.BLL.Models.ExersiceModels;

public record ExersiceUpdateModel : ExersiceCreateModel
{
    public Guid Id { get; init; }
}
