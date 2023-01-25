using AutoMapper;
using HardTrain.BLL.Contracts;
using HardTrain.BLL.Models;
using HardTrain.DAL;
using HardTrain.DAL.Entities.ExersiceEntities;
using HardTrain.DAL.Enums;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardTrain.BLL.Managers
{
    internal class TrainingManager : ITrainingManager
    {

        private readonly DataContext _dataContext;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public TrainingManager(DataContext context, ILogger<TrainingManager> logger)
        {
            _dataContext = context;
            _logger = logger;
        }
        public async Task<bool> TrainingExists(Guid id)
        {
            return await _dataContext.TrainingTemplates.AnyAsync(c => c.Id == id);
        }

        public async Task<TrainingViewModel> CreateTrainingAsync(TrainingCreateModel model)
        {
            try
            {
                Training training = new Training();
                training.Id = model.Id;
                training.Description = model.Description;
                training.Title = model.Title;
                training.Category = model.Category;

                //var exersice = model.Adapt<Exersice>();

                _dataContext.TrainingTemplates.Add(training);
                await _dataContext.SaveChangesAsync();
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
                var training = model.Adapt<Exersice>();
                //var exersice2 = new Exersice
                //{
                //    Title = model.Title,
                //    Id = model.Id,
                //    Category = model.Category,
                //    Description = model.Description,
                //};

                _dataContext.Entry(training).State = EntityState.Modified;

                //_dataContext.Update(exersice2);

                await _dataContext.SaveChangesAsync();

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
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting a training template");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Guid[] ids)
        {
            if (ids == null || !ids.Any())
            {
                _logger.LogError("No ids been found");
                return false;
            }
            foreach (var id in ids)
            {
               
                var training = new Training { Id = id };
                try
                {
                    _dataContext.Entry(training).State = EntityState.Deleted;
                    await _dataContext.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while deleting a training template");
                    return false;
                }
            }
            return true;
        }

        public async Task<IEnumerable<TrainingViewModel>> GetAllAsync()
        {
            return await _dataContext.TrainingTemplates.Select(x => new TrainingViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Category = x.Category,
                Description = x.Description,
            }).ToListAsync();
        }

        public async Task<TrainingViewModel> GetByIdAsync(Guid id)
        {
                return await _dataContext.TrainingTemplates.Select(x => new TrainingViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Category = x.Category,
                    Description = x.Description,
                }).FirstOrDefaultAsync();
        }

        public async Task<TrainingViewModel> GetByTitleAsync(string name)
        {
            return await _dataContext.TrainingTemplates.ProjectToType<TrainingViewModel>().FirstOrDefaultAsync(x => x.Title == name);
        }

        public async Task<TrainingViewModel> GetByCategoryAsync(Category category)
        {
            return await _dataContext.TrainingTemplates.ProjectToType<TrainingViewModel>().FirstOrDefaultAsync(x => x.Category == category);
        }

    }
}
