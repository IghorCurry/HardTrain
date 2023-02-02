using HardTrain.BLL.Models.ExersiceResultModels;
using HardTrain.BLL.Models.TrainingResultModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardTrain.BLL.Contracts
{
    public interface ITrainingResultManager
    {
        Task<IEnumerable<TrainingResultViewModel>> GetAllAsync();
        Task<TrainingResultViewModel> GetByIdAsync(Guid id);
        Task<TrainingResultViewModel> CreateTrainingResultAsync(TrainingResultCreateModel model);
        Task<bool> IsExists(Guid id);
        Task<TrainingResultViewModel> UpdateAsync(TrainingResultUpdateModel model);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> DeleteAsync(Guid[] ids);
    }
}
