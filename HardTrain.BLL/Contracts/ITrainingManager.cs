using HardTrain.BLL.Models.TrainingModels;

namespace HardTrain.BLL.Contracts;

public interface ITrainingManager
{
    Task<IEnumerable<TrainingViewModel>> GetAllAsync();
    Task<TrainingViewModel> GetByIdAsync(Guid id);

    Task<TrainingViewModel> CreateTrainingAsync(TrainingCreateModel model);
    Task<bool> IsExists(Guid id);
    Task<TrainingViewModel> UpdateAsync(TrainingUpdateModel model);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> DeleteAsync(Guid[] ids);//need to be fixed
    Task<bool> AddExersiceAsync(Guid trainingId, Guid exersiceId);
    Task<bool> RemoveExersiceAsync(Guid trainingId, Guid exersiceId);
}
