using HardTrain.DAL.Entities.UserResultScope;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedModules.Infrastructure.Identity.Models.RoleModels;

namespace HardTrain.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<Role> _roleManager;

        public RoleController(RoleManager<Role> roleManager)
            => _roleManager = roleManager;

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RoleViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _roleManager.Roles.ProjectToType<RoleViewModel>().ToListAsync();
            return Ok(roles);
        }
    }
}
