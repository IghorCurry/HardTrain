using HardTrain.BLL.Models.ExersiceModels;

namespace HardTrain.BLL.Models.TrainingModels;

public record TrainingViewModel : TrainingUpdateModel
{
    public string Title { get; init; }
    public string Description { get; init; }
    public ICollection<ExersiceViewModel> Exersices { get; init; } = new List<ExersiceViewModel>();

}
