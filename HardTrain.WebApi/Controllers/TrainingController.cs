using HardTrain.BLL.Contracts;
using HardTrain.BLL.Models.TrainingModels;
using HardTrain.DAL.Entities.TrainingScope;
using Microsoft.AspNetCore.Mvc;

namespace HardTrain.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainingController : Controller
    {
        private readonly ITrainingManager _trainingManager;

        public TrainingController(ITrainingManager trainingManager)
        {
            _trainingManager = trainingManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            //var V = _mapper.Map<List<TrainingViewModel>>(await _trainingManager.GetAllAsync());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _trainingManager.GetAllAsync());
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Training))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Get(Guid id)
        {
            if (!await _trainingManager.IsExists(id))
                return NotFound();

            //var training = _mapper.Map<TrainingViewModel>(await _trainingManager.GetByIdAsync(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _trainingManager.GetByIdAsync(id));
        }
        //[HttpGet("{title}")]
        //[ProducesResponseType(200, Type = typeof(Training))]
        //[ProducesResponseType(400)]
        //public async Task<IActionResult> Get(string title)
        //{
        //    return Ok(await _trainingManager.GetByTitleAsync(title));
        //}

        //[HttpGet("{category}")]
        //[ProducesResponseType(200, Type = typeof(Training))]
        //[ProducesResponseType(400)]
        //public async Task<IActionResult> Get(Category category)
        //{
        //    return Ok(await _trainingManager.GetByCategoryAsync(category));
        //}

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create(TrainingCreateModel training)
        {
            if (training == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //var trainingMap = _mapper.Map<Training>(training);

            return Ok(await _trainingManager.CreateTrainingAsync(training));
        }

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(Guid id, TrainingUpdateModel training)
        {

            if (id == default || training is null || id != training.Id)
            {
                return BadRequest(ModelState);
            }
            //var trainingMap = _mapper.Map<Training>(training);

            return Ok(await _trainingManager.UpdateAsync(training));
        }

        [HttpDelete]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!await _trainingManager.IsExists(id))
            {
                return NotFound();
            }
            else
            {
                var trainingToDelete = _trainingManager.GetByIdAsync(id);
                return Ok(await _trainingManager.DeleteAsync(id));
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
        }

        [HttpDelete("bulk")]
        public async Task<IActionResult> Delete(Guid[] ids)
        {
            return Ok(await _trainingManager.DeleteAsync(ids));
        }

        [HttpPost("add-exersice")]
        public async Task<IActionResult> AddExersice(Guid trainingId, Guid exersiceId)
        {
            return Ok(await _trainingManager.AddExersiceAsync(trainingId, exersiceId));
        }

        [HttpDelete("remove-exersice")]
        public async Task<IActionResult> RemoveExersice(Guid trainingId, Guid exersiceId)
        {
            return Ok(await _trainingManager.RemoveExersiceAsync(trainingId, exersiceId));
        }
    }
}

