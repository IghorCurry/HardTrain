using HardTrain.DAL.Enums;

namespace HardTrain.BLL.Models.ExersiceModels;

public record ExersiceViewModel : ExersiceUpdateModel
{
    public string Title { get; init; }
    public string Description { get; init; }
    public Category Category { get; init; }
    public int DefaultWeight { get; init; }

    public int DefaultReps { get; init; }

    public int DefaultTime { get; init; }
}

