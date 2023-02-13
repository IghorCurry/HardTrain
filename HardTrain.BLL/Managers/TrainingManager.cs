using HardTrain.BLL.Abstractions;
using HardTrain.BLL.Models.ExersiceModels;
using HardTrain.BLL.Models.TrainingModels;
using HardTrain.DAL;
using HardTrain.DAL.Entities.TrainingScope;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Transactions;

namespace HardTrain.BLL.Managers
{
    internal class TrainingManager : ITrainingManager
    {

        private readonly DataContext _dataContext;
        private readonly ILogger _logger;
        //private readonly IMapper _mapper;

        public TrainingManager(DataContext context, ILogger<TrainingManager> logger)
        {
            _dataContext = context;
            _logger = logger;
        }
        public async Task<bool> IsExists(Guid id)
        {
            return await _dataContext.Trainings.AnyAsync(c => c.Id == id);
        }

        public async Task<TrainingViewModel> CreateTrainingAsync(TrainingCreateModel model)
        {
            try
            {
                Training training = new Training();
                training.Description = model.Description;
                training.Title = model.Title;

                //var exersice = model.Adapt<Exersice>();

                _dataContext.Trainings.Add(training);
                await _dataContext.SaveChangesAsync();
                _logger.LogInformation("Training created");
                return training.Adapt<TrainingViewModel>();//need to be replaced
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while creating a training template.");
                return null;
            }
        }
        public async Task<TrainingViewModel> UpdateAsync(TrainingUpdateModel model)
        {
            try
            {
                var training = model.Adapt<Training>();
                var exersice2 = new Exersice
                {
                    Title = model.Title,
                    Id = model.Id,
                    Description = model.Description,
                };

                _dataContext.Entry(training).State = EntityState.Modified;

                //_dataContext.Update(exersice2);

                await _dataContext.SaveChangesAsync();
                _logger.LogInformation("Training updated");

                return training.Adapt<TrainingViewModel>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating training template.");
                return null;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var training = new Training { Id = id };

            try
            {
                _dataContext.Entry(training).State = EntityState.Deleted;
                await _dataContext.SaveChangesAsync();
                _logger.LogInformation("Training deleted");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting a training template");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Guid[] ids)
        {
            using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            try
            {
                foreach (var id in ids)
                {
                    var exersice = new Exersice { Id = id };

                    _dataContext.Entry(exersice).State = EntityState.Deleted;
                    await _dataContext.SaveChangesAsync();
                }

                transaction.Complete();
                _logger.LogInformation("Trainings deleted");
            }
            catch (Exception ex)
            {
                transaction.Dispose();
                throw new InvalidOperationException();
                _logger.LogError(ex, "An error occurred while deleting a training templates");
            }
            return true;
        }

        public async Task<IEnumerable<TrainingViewModel>> GetAllAsync()
        {
            return await _dataContext.Trainings
                .Include(c => c.TrainingExersices)
                .ThenInclude(ca => ca.Exersice)
                //.Where(x => x.Category ==)
                .Select(x => new TrainingViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Exersices = x.TrainingExersices.Select(x => new ExersiceViewModel
                    {
                        Id = x.Id,
                        Title = x.Exersice.Title,
                        Description = x.Exersice.Description,
                        Category = x.Exersice.Category,
                    }).ToList()
                }).ToListAsync();
        }

        public async Task<TrainingViewModel> GetByIdAsync(Guid id)
        {
            return await _dataContext.Trainings
            .Include(c => c.TrainingExersices)
            .ThenInclude(ca => ca.Exersice)
            //.Where(x => x.Category ==)
            .Select(x => new TrainingViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Exersices = x.TrainingExersices.Select(x => new ExersiceViewModel
                {
                    Id = x.Id,
                    Title = x.Exersice.Title,
                    Description = x.Exersice.Description,
                    Category = x.Exersice.Category,
                }).ToList()
            }).FirstOrDefaultAsync();
        }

        //public async Task<TrainingViewModel> GetByTitleAsync(string name)
        //{
        //    return await _dataContext.Trainings.ProjectToType<TrainingViewModel>().FirstOrDefaultAsync(x => x.Title == name);
        //}

        //public async Task<TrainingViewModel> GetByCategoryAsync(Category category)
        //{
        //    return await _dataContext.Trainings.ProjectToType<TrainingViewModel>().FirstOrDefaultAsync(x => x.Category == category);
        //}

        public async Task<bool> AddExersiceAsync(Guid trainingId, Guid exersiceId)
        {
            try
            {
                await _dataContext.TrainingExersices.AddAsync(new TrainingExersice
                {
                    TrainingId = trainingId,
                    ExersiceId = exersiceId
                });
                await _dataContext.SaveChangesAsync();
                _logger.LogInformation("Exersice added to training template");
                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding an exersice to training template");
                return false;
            }
        }


        public async Task<bool> RemoveExersiceAsync(Guid trainingId, Guid exersiceId)
        {
            var trainingExersice = await _dataContext.TrainingExersices.FirstOrDefaultAsync(x => x.TrainingId == trainingId && x.ExersiceId == exersiceId);
            if (trainingExersice == null)
                return false;
            _dataContext.TrainingExersices.Remove(trainingExersice);
            await _dataContext.SaveChangesAsync();
            return true;
        }
    }
}
