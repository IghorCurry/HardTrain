using HardTrain.BLL.Contracts;
using HardTrain.BLL.Models.TrainingResultModels;
using HardTrain.DAL;
using HardTrain.DAL.Entities.UserResultScope;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Transactions;

namespace HardTrain.BLL.Managers
{
    public class TrainingResultManager : ITrainingResultManager
    {
        private readonly DataContext _dataContext;
        private readonly ILogger _logger;

        public TrainingResultManager(DataContext context, ILogger<TrainingResultManager> logger)
        {
            _dataContext = context;
            _logger = logger;
        }
        public async Task<TrainingResultViewModel> CreateTrainingResultAsync(TrainingResultCreateModel model)
        {
            try
            {
                //TrainingResult result = new TrainingResult();
                //result.ExecutionDate = model.ExecutionDate;
                //result.TrainingId = model.TrainingId;
                //result.ExersiceResults = model.ExersiceResults;

                var result = model.Adapt<TrainingResult>();

                _dataContext.TrainingResults.Add(result);
                _logger.LogInformation("Creating training result");
                await _dataContext.SaveChangesAsync();
                return result.Adapt<TrainingResultViewModel>();//need to be replaced
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while creating a training result.");
                return null;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = new TrainingResult { Id = id };

            _dataContext.Entry(result).State = EntityState.Deleted;
            _logger.LogInformation("Deleted training result");
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid[] ids)
        {
            using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            try
            {
                foreach (var id in ids)
                {
                    var result = new TrainingResult { Id = id };

                    _dataContext.Entry(result).State = EntityState.Deleted;
                    await _dataContext.SaveChangesAsync();
                }
                _logger.LogInformation("Created training result");
                transaction.Complete();
            }
            catch (Exception)
            {
                transaction.Dispose();
                _logger.LogError("An error occured while bulk deleting");
                throw new InvalidOperationException();
            }
            return true;
        }

        public async Task<IEnumerable<TrainingResultViewModel>> GetAllAsync()
        {
            try
            {
                return await _dataContext.TrainingResults.Select(x => new TrainingResultViewModel
                {
                    Id = x.Id,
                    ExecutionDate = x.ExecutionDate,
                    TrainingId = x.TrainingId,
                    UserId = x.UserId,
                    Note = x.Note,
                    ExersiceResults = x.ExersiceResults
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting all training results.");
                return null;
            }
        }

        public async Task<TrainingResultViewModel> GetByIdAsync(Guid id)
        {
            try
            {
                return await _dataContext.TrainingResults.Select(x => new TrainingResultViewModel
                {
                    Id = x.Id,
                    ExecutionDate = x.ExecutionDate,
                    TrainingId = x.TrainingId,
                    UserId = x.UserId,
                    Note = x.Note,
                    ExersiceResults = x.ExersiceResults
                }).FirstOrDefaultAsync(x => x.Id == id);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting training result.");
                return null;
            }
        }

        public async Task<bool> IsExists(Guid id)
        {
            return await _dataContext.TrainingResults.AnyAsync(p => p.Id == id);
        }

        public async Task<TrainingResultViewModel> UpdateAsync(TrainingResultUpdateModel model)
        {
            try
            {
                var result = model.Adapt<User>();
                //var result = new TrainingResult
                //{
                //    Id = model.Id,
                //    Note = model.Note,
                //};

                _dataContext.Entry(result).State = EntityState.Modified;
                _logger.LogInformation("Updating training result");

                //_dataContext.Update(exersice2);

                await _dataContext.SaveChangesAsync();

                return result.Adapt<TrainingResultViewModel>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating training result.");
                return null;
            }
        }
    }
}
