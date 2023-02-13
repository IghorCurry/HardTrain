using HardTrain.BLL.Abstractions;
using HardTrain.BLL.Models.TrainingResultModels;
using HardTrain.DAL.Entities.UserResultScope;
using Microsoft.AspNetCore.Mvc;

namespace HardTrain.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingResultController : ControllerBase
    {
        private readonly ITrainingResultManager _trainingResultManager;
        //private readonly IMapper _mapper;
        public TrainingResultController(ITrainingResultManager trainingResultManager)
        {
            _trainingResultManager = trainingResultManager;
            /*_mapper = mapper*/
        }

        [HttpGet("get-all")]
        [ProducesResponseType(typeof(IEnumerable<TrainingResultViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _trainingResultManager.GetByCurrentUserAsync());
        }


        [HttpGet("{id}/get-by-id")]
        //[Authorize]
        [ProducesResponseType(typeof(TrainingResultViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(200, Type = typeof(TrainingResult))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Get(Guid id)
        {
            if (!await _trainingResultManager.IsExists(id))
                return NotFound();

            //var training = await _trainingResultManager.GetByIdAsync(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _trainingResultManager.GetByIdAsync(id));
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(TrainingResultViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(TrainingResultCreateModel training)
        {
            if (training == null)
                return BadRequest();


            return Ok(await _trainingResultManager.CreateTrainingResultAsync(training));
        }

        [HttpPut]
        [ProducesResponseType(typeof(TrainingResultViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(Guid id, TrainingResultUpdateModel training)
        {

            if (id == default || training is null || id != training.Id)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _trainingResultManager.UpdateAsync(training));
        }

        [HttpDelete("{id}/delete-by-id")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!await _trainingResultManager.IsExists(id))
                return NotFound();

            return Ok(await _trainingResultManager.DeleteAsync(id));
        }

        [HttpDelete("bulk")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid[] ids)
        {
            if (ids.Any())
                return BadRequest();

            return Ok(await _trainingResultManager.DeleteAsync(ids));
        }

    }
}

