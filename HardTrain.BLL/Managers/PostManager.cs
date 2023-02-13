using HardTrain.BLL.Abstractions;
using HardTrain.BLL.Models.PostModels;
using HardTrain.BLL.Models.TrainingResultModels;
using HardTrain.DAL;
using HardTrain.DAL.Entities.PostScope;
using HardTrain.DAL.Entities.UserResultScope;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HardTrain.BLL.Managers;

public class PostManager : IPostManager
{
    private readonly DataContext _dataContext;
    private readonly ILogger _logger;

    public PostManager(DataContext context, ILogger<PostManager> logger)
    {
        _dataContext = context;
        _logger = logger;
    }
    public async Task<PostViewModel> CreatePostAsync(PostCreateModel model)
    {
        try
        {

            var result = model.Adapt<Post>();

            _dataContext.Posts.Add(result);
            _logger.LogInformation("Post created.");
            await _dataContext.SaveChangesAsync();
            return result.Adapt<PostViewModel>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while creating a post.");
            return null;
        }
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var result = new Post { Id = id };

        _dataContext.Entry(result).State = EntityState.Deleted;
        _logger.LogInformation("Post deleted");
        await _dataContext.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<PostViewModel>> GetAllAsync()
    {
        return await _dataContext.Posts
                .ProjectToType<PostViewModel>()
                .ToListAsync();
    }

    public async Task<PostViewModel?> GetByIdAsync(Guid id)
    {
        try
        {
            return await _dataContext.Posts
                  .ProjectToType<PostViewModel>()
                  .FirstOrDefaultAsync(x => x.Id == id);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while getting user .");
            return null;
        }
    }

    public async Task<PostViewModel> UpdateAsync(PostUpdateModel model)
    {
        try
        {
            var post = model.Adapt<Post>();
            //var post = new Post
            //{
            //    Title = model.Title,
            //    Description = model.Description,
            //    ImageURL = model.ImageURL,

            //};

            _dataContext.Entry(post).State = EntityState.Modified;

            await _dataContext.SaveChangesAsync();
            _logger.LogInformation("Post updated");

            return post.Adapt<PostViewModel>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while updating post.");
            return null;
        }
    }
}
