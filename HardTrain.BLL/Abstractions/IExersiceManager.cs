using HardTrain.BLL.Models.ExersiceModels;

namespace HardTrain.BLL.Abstractions;

public interface IExersiceManager
{
    Task<IEnumerable<ExersiceViewModel>> GetAllAsync();
    Task<ExersiceViewModel> GetByIdAsync(Guid id);
    //Task<TrainingViewModel> GetByTitleAsync(string name);
    //Task<TrainingViewModel> GetByCategoryAsync(Category category);
    Task<ExersiceViewModel> GetByTitleAsync(string name);
    Task<ExersiceViewModel> CreateAsync(ExersiceCreateModel model);
    Task<bool> IsExists(Guid id);
    Task<ExersiceViewModel> UpdateAsync(ExersiceUpdateModel model);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> DeleteAsync(Guid[] ids);
}
