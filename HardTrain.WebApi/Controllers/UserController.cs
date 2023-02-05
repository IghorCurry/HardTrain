using HardTrain.BLL.Contracts;
using HardTrain.BLL.Models.UserModels;
using HardTrain.DAL.Entities.UserResultScope;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedModules.Infrastructure.Identity.Abstractions;
using SharedPackages.ResponseResultCore.Exceptions;
using SharedPackages.ResponseResultCore.Models;
using System.ComponentModel.DataAnnotations;

namespace HardTrain.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IIdentityManager<User> _identityManager;
        private readonly RoleManager<Role> _roleManager;

        public UserController(IIdentityManager<User> userManager, RoleManager<Role> roleManager)
            => (_identityManager, _roleManager) = (userManager, roleManager);

        [HttpGet("get-all")]
        [ProducesResponseType(typeof(HttpResponseResult<IEnumerable<UserViewModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var users = await _identityManager
                .GetAll()
                .ProjectToType<UserViewModel>()
                .ToListAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(HttpResponseResult<UserViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = await _identityManager.GetUserAsync(id);

            return Ok(user.Adapt<UserViewModel>() with { Roles = await _identityManager.GetRolesAsync(user.Id) });
        }

        [Authorize]
        [HttpGet("who-am-i")]
        [ProducesResponseType(typeof(HttpResponseResult<UserViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCurrentUser()
        {
            var user = await _identityManager.GetUserAsync(HttpContext.User);

            return Ok(user.Adapt<UserViewModel>() with { Roles = await _identityManager.GetRolesAsync(user.Id) });

        }

        [HttpPost]
        [ProducesResponseType(typeof(HttpResponseResult<UserViewModel>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(UserCreateModel model)
        {
            var user = model.Adapt<User>();
            var result = await _identityManager.UserManager.CreateAsync(user);
            await _identityManager.UserManager.AddToRoleAsync(user, "Client");
            return Ok(user);
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(HttpResponseResult<UserViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(Guid id, UserUpdateModel model)
        {
            if (id != model?.Id)
                return BadRequest("Id from route does match id in model within body");

            var user = await _identityManager.UserManager.UpdateAsync(model.Adapt<User>());

            return Ok(user);
        }

        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _identityManager.DeleteAsync(id));
        }

        [HttpGet("is-unique-email")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpResponseResult<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(HttpResponseResult<object>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> IsUniqueEmail([EmailAddress] string email)
        {
            return Ok(await _identityManager.IsUniqueEmailAsync(email));
        }
    }
}

