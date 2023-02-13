using HardTrain.BLL.Models.TrainingResultModels;

namespace HardTrain.BLL.Abstractions
{
    public interface ITrainingResultManager
    {
        Task<IEnumerable<TrainingResultViewModel>> GetByCurrentUserAsync();
        Task<TrainingResultViewModel> GetByIdAsync(Guid id);
        Task<TrainingResultViewModel> CreateTrainingResultAsync(TrainingResultCreateModel model);
        Task<bool> IsExists(Guid id);
        Task<TrainingResultViewModel> UpdateAsync(TrainingResultUpdateModel model);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> DeleteAsync(Guid[] ids);
    }
}
