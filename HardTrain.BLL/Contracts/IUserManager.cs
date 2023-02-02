using HardTrain.BLL.Models.TrainingModels;
using HardTrain.BLL.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardTrain.BLL.Contracts;

public interface IUserManager
{
    Task<IEnumerable<UserViewModel>> GetAllAsync();
    Task<UserViewModel> GetByIdAsync(Guid id);
    Task<UserViewModel> CreateUserAsync(UserCreateModel model);
    Task<bool> IsExists(Guid id);
    Task<UserViewModel> UpdateAsync(UserUpdateModel model);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> DeleteAsync(Guid[] ids);
   
}
