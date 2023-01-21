using HardTrain.BLL.Contracts;
using HardTrain.BLL.Models;
using HardTrain.DAL;
using HardTrain.DAL.Entities.ExersiceEntities;
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
    public class ExersiceManager : IExersiceManager
    {
        private readonly DataContext _dataContext;
        private readonly ILogger _logger;

        public ExersiceManager(DataContext context, ILogger<ExersiceManager> logger)
        {
            _dataContext = context;
            _logger = logger;
        }
        public async Task<ExersiceViewModel> CreateAsync(ExersiceCreateModel model)
        {
            try
            {
                Exersice exersice = new Exersice();
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
                var model = await _dataContext.Exersices.Select(x => new ExersiceViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Category = x.Category,
                    Description = x.Description,
                }).FirstOrDefaultAsync(x  => x.Id == id);

                return model; 
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


        //public async Task<ExersiceViewModel> UpdateAsync(ExersiceUpdateModel model)
        //{

        //    try
        //    {
        //        var Exersice = model.Adapt<Exersice>();

        //        _dataContext.Entry(Exersice).State = EntityState.Modified;

        //        await _dataContext.SaveChangesAsync();
        //    }
        //    //responseResult.StatusCode = StatusCodes.Status204NoContent;
        //    //responseResult.Data = true;

        //    //return responseResult;

        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, $"An error occurred while updating job title.");
        //        //    responseResult.Errors.Add($"An error occurred while updating job titles. Message: {ex.InnerException?.Message ?? ex.Message}");
        //        //    responseResult.StatusCode = StatusCodes.Status500InternalServerError;
        //        //    return responseResult;
        //        //}
        //    }




        //    //private async Task<bool> HasUniqueFields(JobTitleUpdateModel model)
        //    //{
        //    //    return !await _dataContext.JobTitles.AnyAsync(x => x.Name == model.Name && x.Id != model.Id);
        //    //}


        //}
        //public async Task<ResponseResult<bool>> Delete(Guid id)
        //{
        //    ResponseResult<bool> responseResult = new();

        //    if (id == default)
        //    {
        //        responseResult.StatusCode = StatusCodes.Status400BadRequest;
        //        responseResult.Errors.Add("Invaid ID");
        //        return responseResult;
        //    }
        //    if (!await IsExisting(id))
        //    {
        //        responseResult.StatusCode = StatusCodes.Status400BadRequest;
        //        responseResult.Errors.Add("The entity has not been deleted.");
        //        responseResult.Errors.Add("The entity with such id does not exist.");

        //        return responseResult;
        //    }

        //    var jobTitle = new JobTitle { Id = id };

        //    try
        //    {
        //        _dataContext.Entry(jobTitle).State = EntityState.Deleted;
        //        await _dataContext.SaveChangesAsync();

        //        responseResult.StatusCode = StatusCodes.Status204NoContent;
        //        responseResult.Data = true;

        //        return responseResult;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, $"An error occurred while deleting a job title.");
        //        responseResult.Errors.Add($"An error occurred while deleting a job title. Message: {ex.InnerException?.Message ?? ex.Message}");
        //        responseResult.StatusCode = StatusCodes.Status500InternalServerError;

        //        return responseResult;
        //    }
        //}

        //public async Task<ResponseResult<bool>> Delete(Guid[] ids)
        //{
        //    ResponseResult<bool> responseResult = new();

        //    if (ids is null || !ids.Any())
        //    {
        //        responseResult.StatusCode = StatusCodes.Status400BadRequest;
        //        responseResult.Errors.Add("Invaid IDs");
        //        return responseResult;
        //    }

        //    await using var transaction = await _dataContext.Database.BeginTransactionAsync();

        //    foreach (var id in ids)
        //    {
        //        var deleteResult = await Delete(id);
        //        if (!deleteResult.IsSuccessful)
        //        {
        //            transaction.Rollback();
        //            responseResult.StatusCode = deleteResult.StatusCode;
        //            responseResult.Errors = deleteResult.Errors;
        //            return responseResult;
        //        }
        //    }

        //    try
        //    {
        //        transaction.Commit();
        //        responseResult.StatusCode = StatusCodes.Status204NoContent;
        //        responseResult.Data = true;
        //        return responseResult;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, $"An error occurred while deleting job titles.");
        //        responseResult.Errors.Add($"An error occurred while deleting a job titles. Message: {ex.InnerException?.Message ?? ex.Message}");
        //        responseResult.StatusCode = StatusCodes.Status500InternalServerError;

        //        return responseResult;
        //    }
        //}
    }
}
