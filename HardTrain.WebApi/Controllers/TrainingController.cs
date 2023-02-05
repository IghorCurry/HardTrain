using HardTrain.BLL.Contracts;
using HardTrain.BLL.Models.TrainingModels;
using HardTrain.DAL.Entities.TrainingScope;
using Microsoft.AspNetCore.Mvc;
using SharedPackages.ResponseResultCore.Models;

namespace HardTrain.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingManager _trainingManager;

        public TrainingController(ITrainingManager trainingManager)
        {
            _trainingManager = trainingManager;
        }

        [HttpGet]
        [ProducesResponseType(typeof(HttpResponseResult<IEnumerable<TrainingViewModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {

            //var V = _mapper.Map<List<TrainingViewModel>>(await _trainingManager.GetAllAsync());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _trainingManager.GetAllAsync());
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(HttpResponseResult<TrainingViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status500InternalServerError)]
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
        [ProducesResponseType(typeof(HttpResponseResult<TrainingViewModel>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status500InternalServerError)]
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
        [ProducesResponseType(typeof(HttpResponseResult<TrainingViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status500InternalServerError)]
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
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status500InternalServerError)]
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
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid[] ids)
        {
            return Ok(await _trainingManager.DeleteAsync(ids));
        }

        [HttpPost("add-exersice")]
        [ProducesResponseType(typeof(HttpResponseResult<TrainingViewModel>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddExersice(Guid trainingId, Guid exersiceId)
        {
            return Ok(await _trainingManager.AddExersiceAsync(trainingId, exersiceId));
        }

        [HttpDelete("remove-exersice")]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RemoveExersice(Guid trainingId, Guid exersiceId)
        {
            return Ok(await _trainingManager.RemoveExersiceAsync(trainingId, exersiceId));
        }
    }
}

