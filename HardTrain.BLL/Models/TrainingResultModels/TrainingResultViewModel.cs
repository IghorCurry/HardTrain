using HardTrain.DAL.Entities.TrainingScope;
using HardTrain.DAL.Entities.UserResultScope;

namespace HardTrain.BLL.Models.TrainingResultModels;

public record TrainingResultViewModel : TrainingResultUpdateModel
{
    public Guid Id { get; init; }

    public DateTime ExecutionDate { get; init; }

    public Guid TrainingId { get; init; }

    public Guid UserId { get; init; }
    public string Note { get; init; }//updatemodel1

    public ICollection<ExersiceResult> ExersiceResults { get; init; }
}
