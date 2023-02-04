using HardTrain.BLL.Contracts;
using HardTrain.BLL.Models.TrainingResultModels;
using HardTrain.DAL.Entities.UserResultScope;
using Microsoft.AspNetCore.Mvc;

namespace HardTrain.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingResultController : Controller
    {
        private readonly ITrainingResultManager _trainingResultManager;
        //private readonly IMapper _mapper;
        public TrainingResultController(ITrainingResultManager trainingResultManager)
        {
            _trainingResultManager = trainingResultManager;
            /*_mapper = mapper*/
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> Get()
        {

            //var training = _mapper.Map<List<TrainingResultViewModel>>(await _trainingResultManager.GetAllAsync());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _trainingResultManager.GetAllAsync());
        }


        [HttpGet("{id}/get-by-id")]
        //[Authorize]
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
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create(TrainingResultCreateModel training)
        {
            if (training == null)
                return BadRequest();


            return Ok(await _trainingResultManager.CreateTrainingResultAsync(training));
        }

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(Guid id, TrainingResultUpdateModel training)
        {

            if (id == default || training is null || id != training.Id)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _trainingResultManager.UpdateAsync(training));
        }

        [HttpDelete("{id}/delete-by-id")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!await _trainingResultManager.IsExists(id))
                return NotFound();

            return Ok(await _trainingResultManager.DeleteAsync(id));
        }

        [HttpDelete("bulk")]
        public async Task<IActionResult> Delete(Guid[] ids)
        {
            if (ids.Any())
                return BadRequest();

            return Ok(await _trainingResultManager.DeleteAsync(ids));
        }

    }
}

