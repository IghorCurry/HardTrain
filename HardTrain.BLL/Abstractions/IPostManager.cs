using HardTrain.BLL.Models.PostModels;
using HardTrain.BLL.Models.TrainingResultModels;

namespace HardTrain.BLL.Abstractions
{
    public interface IPostManager
    {
        Task<IEnumerable<PostViewModel>> GetAllAsync();
        Task<PostViewModel> GetByIdAsync(Guid id);
        Task<PostViewModel> CreatePostAsync(PostCreateModel model);
        Task<PostViewModel> UpdateAsync(PostUpdateModel model);
        Task<bool> DeleteAsync(Guid id);
    }
}
