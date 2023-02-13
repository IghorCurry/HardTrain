using HardTrain.BLL.Abstractions;
using HardTrain.BLL.Models.CommentModels;
using HardTrain.BLL.Models.PostModels;
using HardTrain.DAL;
using HardTrain.DAL.Entities.PostScope;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HardTrain.BLL.Managers;

internal class CommentManager : ICommentManager
{
    private readonly DataContext _dataContext;
    private readonly ILogger _logger;

    public CommentManager(DataContext context, ILogger<PostManager> logger)
    {
        _dataContext = context;
        _logger = logger;
    }
    public async Task<CommentViewModel> CreateCommentAsync(CommentCreateModel model)
    {
        try
        {
            var comment = model.Adapt<Comment>();

            _dataContext.Comments.Add(comment);
            _logger.LogInformation("Comment created.");
            await _dataContext.SaveChangesAsync();
            return comment.Adapt<CommentViewModel>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while creating a comment.");
            return null;
        }
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var comment = new Comment { Id = id };

        _dataContext.Entry(comment).State = EntityState.Deleted;
        _logger.LogInformation("Comment deleted");
        await _dataContext.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<CommentViewModel>> GetAllAsync()
    {
        return await _dataContext.Comments
                .ProjectToType<CommentViewModel>()
                .ToListAsync();
    }
}
