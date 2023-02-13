using HardTrain.BLL.Models.UserModels;

namespace HardTrain.BLL.Abstractions;

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
