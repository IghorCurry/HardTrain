using HardTrain.BLL.Models.UserModels;
using HardTrain.DAL;
using HardTrain.DAL.Entities.UserResultScope;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedModules.Application.Common.Abstractions;
using SharedModules.Infrastructure.Identity.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace HardTrain.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IIdentityManager<User> _identityManager;
        private readonly DataContext _dataContext;
        private readonly RoleManager<Role> _roleManager;

        public UserController(IIdentityManager<User> userManager, RoleManager<Role> roleManager, DataContext dataContext)
        {
            _identityManager = userManager;
            _roleManager = roleManager;
            _dataContext = dataContext;
        }
           
        [HttpGet("get-all")]
        [ProducesResponseType(typeof(IEnumerable<UserViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var users = await _identityManager
                .GetAll()
                .ProjectToType<UserViewModel>()
                .ToListAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = await _identityManager.GetUserAsync(id);

            return Ok(user.Adapt<UserViewModel>() with { Roles = await _identityManager.GetRolesAsync(user.Id) });
        }

        [Authorize]
        [HttpGet("who-am-i")]
        [ProducesResponseType(typeof(UserViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCurrentUser()
        {
            var user = await _identityManager.GetUserAsync(HttpContext.User);

            return Ok(user.Adapt<UserViewModel>() with { Roles = await _identityManager.GetRolesAsync(user.Id) });

        }

        [HttpPost("assign-role")]
        [ProducesResponseType(typeof(UserViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AssingRole(Guid userId, string roleName)
        {
            var user = await _identityManager.GetUserAsync(userId);
            await _identityManager.UserManager.AddToRoleAsync(user, roleName);
            return Ok(true);
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(UserViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(UserCreateModel model)
        {
            var user = model.Adapt<User>();
            user.SecurityStamp = Guid.NewGuid().ToString();
            var result = await _identityManager.UserManager.CreateAsync(user, model.Password);
            //_dataContext.SaveChanges();
            await _identityManager.UserManager.AddToRoleAsync(user, "Client");
            return Ok(user);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UserViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(Guid id, UserUpdateModel model)
        {
            if (id != model?.Id)
                return BadRequest("Id from route does match id in model within body");

            var user = await _identityManager.UserManager.UpdateAsync(model.Adapt<User>());

            return Ok(user);
        }

        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _identityManager.DeleteAsync(id));
        }

        [HttpGet("is-unique-email")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> IsUniqueEmail([EmailAddress] string email)
        {
            return Ok(await _identityManager.IsUniqueEmailAsync(email));
        }
    }
}

