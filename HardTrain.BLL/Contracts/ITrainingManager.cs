using HardTrain.BLL.Models;
using HardTrain.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardTrain.BLL.Contracts;

public interface ITrainingManager
{
    Task<IEnumerable<TrainingViewModel>> GetAllAsync();
    Task<TrainingViewModel> GetByIdAsync(Guid id);
    Task<TrainingViewModel> GetByTitleAsync(string name);
    Task<TrainingViewModel> GetByCategoryAsync(Category category);
    Task<TrainingViewModel> CreateTrainingAsync(TrainingCreateModel model);
    Task<bool> TrainingExists(Guid id);
    Task<TrainingViewModel> UpdateAsync(TrainingUpdateModel model);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> DeleteAsync(Guid[] ids);//need to be fixed
}
