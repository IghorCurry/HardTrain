using HardTrain.BLL.Models.CommentModels;

namespace HardTrain.BLL.Abstractions
{
    public interface ICommentManager
    {
        Task<IEnumerable<CommentViewModel>> GetAllAsync();
        Task<CommentViewModel> CreateCommentAsync(CommentCreateModel model);
        Task<bool> DeleteAsync(Guid id);
    }
}
