using AutoMapper;
using HardTrain.BLL.Contracts;
using HardTrain.BLL.Managers;
using HardTrain.BLL.Models.ExersiceModels;
using HardTrain.BLL.Models.TrainingModels;
using HardTrain.BLL.Models.UserModels;
using HardTrain.DAL.Entities.TrainingScope;
using HardTrain.DAL.Entities.UserResultScope;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HardTrain.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;
        public UserController(IUserManager userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> Get()
        {

            var user = _mapper.Map<List<UserViewModel>>(await _userManager.GetAllAsync());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _userManager.GetAllAsync());
        }


        [HttpGet("{id}/get-by-id")]
        //[Authorize]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Get(Guid id)
        {
            if (!await _userManager.IsExists(id))
                return NotFound();

            var user = await _userManager.GetByIdAsync(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _userManager.GetByIdAsync(id));
        }
        
        [HttpPost("create")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create(UserCreateModel user)
        {
            if (user == null)
                return BadRequest();          


            return Ok(await _userManager.CreateUserAsync(user));
        }
        
        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(Guid id, UserUpdateModel user)
        {

            if (id == default || user is null || id != user.Id)
            {
                return BadRequest(ModelState);
            }
            var trainingMap = _mapper.Map<User>(user);

            return Ok(await _userManager.UpdateAsync(user));
        }

        [HttpDelete("{id}/delete-by-id")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!await _userManager.IsExists(id))
                return NotFound();

            return Ok(await _userManager.DeleteAsync(id));
        }

        [HttpDelete("bulk")]
        public async Task<IActionResult> Delete(Guid[] ids)
        {
            if (ids.Any())
                return BadRequest();

            return Ok(await _userManager.DeleteAsync(ids));
        }

    }
}
