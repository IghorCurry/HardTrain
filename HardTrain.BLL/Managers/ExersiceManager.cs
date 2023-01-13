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
        public async Task<ExersiceViewModel> CreateAsync(ExersiceModel model)
        {
            try
            {
                var exersice = model.Adapt<Exersice>();

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

        public async Task<ExersiceViewModel> GetByIdAsync(Guid id)
        {
            try
            {
                //var model = await _dataContext.JobTitles.ProjectToType<JobTitleViewModel>().FirstOrDefaultAsync(x => x.Id == id);

                //if (model is null)
                //{
                //    responseResult.StatusCode = StatusCodes.Status404NotFound;
                //    responseResult.Errors.Add("Model is not found");
                //    return responseResult;
                //}

                //responseResult.Data = model;
                //responseResult.StatusCode = StatusCodes.Status200OK;
                //return responseResult;
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting job title.");
                return null;
            }
        }

        public async Task<IEnumerable<ExersiceViewModel>> GetAllAsync()
        {

            return await _dataContext.Exersices.ProjectToType<ExersiceViewModel>().ToListAsync();

        }


        //public async Task<ResponseResult<bool>> Update(JobTitleUpdateModel model)
        //{
        //    ResponseResult<bool> responseResult = new();

        //    if (model is null)
        //    {
        //        responseResult.StatusCode = StatusCodes.Status400BadRequest;
        //        responseResult.Errors.Add("The job title has not been updated. Model is empty.");
        //        return responseResult;
        //    }

        //    try
        //    {
        //        if (!await IsExisting(model.Id))
        //        {
        //            responseResult.StatusCode = StatusCodes.Status400BadRequest;
        //            responseResult.Errors.Add("The job title has not been updated.");
        //            responseResult.Errors.Add("The job title with such id does not exist.");

        //            return responseResult;
        //        }

        //        if (!await HasUniqueFields(model))
        //        {
        //            responseResult.StatusCode = StatusCodes.Status409Conflict;
        //            responseResult.Errors.Add("The job title has not been updated.");
        //            responseResult.Errors.Add("A job title with such name already exist.");

        //            return responseResult;
        //        }

        //        var jobTitle = model.Adapt<JobTitle>();

        //        _dataContext.Entry(jobTitle).State = EntityState.Modified;

        //        await _dataContext.SaveChangesAsync();
        //        responseResult.StatusCode = StatusCodes.Status204NoContent;
        //        responseResult.Data = true;

        //        return responseResult;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, $"An error occurred while updating job title.");
        //        responseResult.Errors.Add($"An error occurred while updating job titles. Message: {ex.InnerException?.Message ?? ex.Message}");
        //        responseResult.StatusCode = StatusCodes.Status500InternalServerError;
        //        return responseResult;
        //    }
        //}
        //private async Task<bool> HasUniqueFields(JobTitleUpdateModel model)
        //{
        //    return !await _dataContext.JobTitles.AnyAsync(x => x.Name == model.Name && x.Id != model.Id);
        //}
    }
}
