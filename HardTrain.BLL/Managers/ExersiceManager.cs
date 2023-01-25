using AutoMapper;
using HardTrain.BLL.Contracts;
using HardTrain.BLL.Models;
using HardTrain.DAL;
using HardTrain.DAL.Entities.ExersiceEntities;
using HardTrain.DAL.Enums;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardTrain.BLL.Managers
{
    public class ExersiceManager : IExersiceManager
    {
        private readonly DataContext _dataContext;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public ExersiceManager(DataContext context, ILogger<ExersiceManager> logger)
        {
            _dataContext = context;
            _logger = logger;
        }
        public async Task<ExersiceViewModel> CreateExersiceAsync(ExersiceCreateModel model)
        {
            try
            {
                Exersice exersice = new Exersice();
                exersice.Id = model.Id;
                exersice.Description = model.Description;
                exersice.Title = model.Title;
                exersice.Category = model.Category;

                //var exersice = model.Adapt<Exersice>();

                _dataContext.Exersices.Add(exersice);
                await _dataContext.SaveChangesAsync();
                return exersice.Adapt<ExersiceViewModel>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while creating a job title.");
                return null;
            }
        }



        public async Task<ExersiceViewModel> GetByIdAsync(Guid id)
        {
            try
            {
                //var model = await _dataContext.Exersices.Select(x => new ExersiceViewModel
                return await _dataContext.Exersices.Select(x => new ExersiceViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Category = x.Category,
                    Description = x.Description,
                }).FirstOrDefaultAsync(x => x.Id == id);

                //return model; 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting job title.");
                return null;
            }
        }

        public async Task<ExersiceViewModel> GetByTitleAsync(string title)
        {
            return await _dataContext.Exersices.ProjectToType<ExersiceViewModel>().FirstOrDefaultAsync(x => x.Title == title);
        }

        public async Task<IEnumerable<ExersiceViewModel>> GetAllAsync()
        {
            return await _dataContext.Exersices.Select(x => new ExersiceViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Category = x.Category,
                Description = x.Description,
            }).ToListAsync();

        }

        public async Task<bool> ExersiceExists(Guid id)
        {
            return await _dataContext.Exersices.AnyAsync(p => p.Id == id);
        }

        //public Task<ExersiceViewModel> UpdateAsync(ExersiceUpdateModel model)
        //{
        //    throw new NotImplementedException();
        //}


        public async Task<ExersiceViewModel> UpdateAsync(ExersiceUpdateModel model)
        {
            try
            {
                var exersice = model.Adapt<Exersice>();
                var exersice2 = new Exersice
                {
                    Title = model.Title,
                    Id = model.Id,
                    Category = model.Category,
                    Description = model.Description,
                };

                _dataContext.Entry(exersice).State = EntityState.Modified;

                //_dataContext.Update(exersice2);

                await _dataContext.SaveChangesAsync();

                return exersice.Adapt<ExersiceViewModel>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating job title.");
                return null;
            }
        }

        //    //private async Task<bool> HasUniqueFields(JobTitleUpdateModel model)
        //    //{
        //    //    return !await _dataContext.JobTitles.AnyAsync(x => x.Name == model.Name && x.Id != model.Id);
        //    //}



        public async Task<bool> DeleteAsync(Guid id)
        {
            
            var exersice = new Exersice { Id = id };

            try
            {
                _dataContext.Entry(exersice).State = EntityState.Deleted;
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting a job title.");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Guid[] ids)
        {

            if (ids is null || !ids.Any())
            {
                return false;
            }
            
            foreach (var id in ids)
            {
                var exersice = new Exersice { Id = id };

                try
                {
                    _dataContext.Entry(exersice).State = EntityState.Deleted;
                    await _dataContext.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"An error occurred while deleting a job title.");
                    return false;
                }
                return false;
            }
            return true;
        }
    }
}
