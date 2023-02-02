using HardTrain.BLL.Contracts;
using HardTrain.BLL.Models.TrainingResultModels;
using HardTrain.BLL.Models.UserModels;
using HardTrain.DAL.Entities.UserResultScope;
using HardTrain.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Mapster;

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
                await _dataContext.SaveChangesAsync();
                return result.Adapt<TrainingResultViewModel>();//need to be replaced
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while creating a job title.");
                return null;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = new TrainingResult { Id = id };

            _dataContext.Entry(result).State = EntityState.Deleted;
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

                transaction.Complete();
            }
            catch (Exception)
            {
                transaction.Dispose();
                throw new InvalidOperationException();
            }
            return true;
        }

        public async Task<IEnumerable<TrainingResultViewModel>> GetAllAsync()
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
                _logger.LogError(ex, $"An error occurred while getting job title.");
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

                //_dataContext.Update(exersice2);

                await _dataContext.SaveChangesAsync();

                return result.Adapt<TrainingResultViewModel>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating job title.");
                return null;
            }
        }
    }
}
