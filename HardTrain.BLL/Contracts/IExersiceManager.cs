using HardTrain.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardTrain.BLL.Contracts;

public interface IExersiceManager //repository
{
    Task<IEnumerable<ExersiceViewModel>> GetAllAsync();
    Task<ExersiceViewModel> GetByIdAsync(Guid id);
    Task<ExersiceViewModel> GetByTitleAsync(string name);
    Task<ExersiceViewModel> CreateAsync(ExersiceCreateModel model);
    //Task<ExersiceViewModel> UpdateAsync(ExersiceUpdateModel model);
    //Task<bool> DeleteAsync(Guid id);
    //Task<bool> DeleteAsync(Guid[] ids);
}
