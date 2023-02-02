using HardTrain.BLL.Contracts;
using HardTrain.BLL.Models.ExersiceModels;
using HardTrain.BLL.Models.UserModels;
using HardTrain.DAL;
using HardTrain.DAL.Entities.TrainingScope;
using HardTrain.DAL.Entities.UserResultScope;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace HardTrain.BLL.Managers
{
    public class UserManager : IUserManager
    {
        private readonly DataContext _dataContext;
        private readonly ILogger _logger;

        public UserManager(DataContext context, ILogger<UserManager> logger)
        {
            _dataContext = context;
            _logger = logger;
        }
        public async Task<UserViewModel> CreateUserAsync(UserCreateModel model)
        {
            try
            {
                //User user = new User();
                //user.FirstName = model.FirstName;
                //user.LastName = model.LastName;
                //user.Email = model.Email;
                var user = model.Adapt<User>();

                _dataContext.Users.Add(user);
                await _dataContext.SaveChangesAsync();
                return user.Adapt<UserViewModel>();//need to be replaced
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while creating a job title.");
                return null;
            }
        }


        public async Task<bool> DeleteAsync(Guid id)
        {
            var user = new User { Id = id };

            _dataContext.Entry(user).State = EntityState.Deleted;
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
                    var user = new User { Id = id };

                    _dataContext.Entry(user).State = EntityState.Deleted;
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

        public async Task<IEnumerable<UserViewModel>> GetAllAsync()
        {
            return await _dataContext.Users.Select(x => new UserViewModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                TrainingResults = x.TrainingResults,
            }).ToListAsync();
        }

        public async Task<UserViewModel> GetByIdAsync(Guid id)
        {
            try
            {
                return await _dataContext.Users.Select(x => new UserViewModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    TrainingResults = x.TrainingResults,
                }).FirstOrDefaultAsync(x => x.Id == id);

                //return model; 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting job title.");
                return null;
            }
        }

        public async Task<bool> IsExists(Guid id)
        {
            return await _dataContext.Users.AnyAsync(p => p.Id == id);
        }

        public async Task<UserViewModel> UpdateAsync(UserUpdateModel model)
        {
            try
            {
                //var user = model.Adapt<User>();
                var user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    TrainingResults = model.TrainingResults,
                    
                };

                _dataContext.Entry(user).State = EntityState.Modified;

                //_dataContext.Update(exersice2);

                await _dataContext.SaveChangesAsync();

                return user.Adapt<UserViewModel>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating job title.");
                return null;
            }
        }
    }
}
