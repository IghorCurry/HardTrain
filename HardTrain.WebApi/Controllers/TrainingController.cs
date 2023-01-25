using AutoMapper;
using HardTrain.BLL.Contracts;
using HardTrain.BLL.Managers;
using HardTrain.BLL.Models;
using HardTrain.DAL.Entities.ExersiceEntities;
using HardTrain.DAL.Enums;
using Microsoft.AspNetCore.Mvc;

namespace HardTrain.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingManager _trainingManager;
        private readonly IMapper _mapper;

        public TrainingController(ITrainingManager trainingManager, IMapper mapper)
        {
            _trainingManager = trainingManager;
            _mapper = mapper;
        }
        
        [HttpGet("get-all")]
        public async Task<IActionResult> Get()
        {

            var V = _mapper.Map<List<TrainingViewModel>>(await _trainingManager.GetAllAsync());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _trainingManager.GetAllAsync());
        }


        [HttpGet("{id}/get-by-id")]
        [ProducesResponseType(200, Type = typeof(Training))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Get(Guid id)
        {
            if (!await _trainingManager.TrainingExists(id))
                return NotFound();

            var exersice = _mapper.Map<TrainingViewModel>(await _trainingManager.GetByIdAsync(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _trainingManager.GetByIdAsync(id));
        }
        [HttpGet("{title}/get-by-title")]
        [ProducesResponseType(200, Type = typeof(Training))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Get(string title)
        {
            return Ok(await _trainingManager.GetByTitleAsync(title));
        }
        
        [HttpGet("{category}/get-by-category")]
        [ProducesResponseType(200, Type = typeof(Training))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Get(Category category)
        {
            return Ok(await _trainingManager.GetByCategoryAsync(category));
        }

        [HttpPost("create")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create(TrainingCreateModel training)
        {
            if (training == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var trainingMap = _mapper.Map<Training>(training);

            return Ok(await _trainingManager.CreateTrainingAsync(training));
        }

        [HttpPut("update")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(Guid id, TrainingUpdateModel training)
        {

            if (id == default || training is null || id != training.Id)
            {
                return BadRequest(ModelState);
            }
            var trainingMap = _mapper.Map<Training>(training);

            return Ok(await _trainingManager.UpdateAsync(training));
        }

        [HttpDelete("{id}/delete-by-id")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!await _trainingManager.TrainingExists(id))
            {
                return NotFound();
            }
            else
            {
                var exersiceToDelete = _trainingManager.GetByIdAsync(id);
                return Ok(await _trainingManager.DeleteAsync(id));
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
        }

        [HttpDelete("{ids}/delete-by-ids")]
        public async Task<IActionResult> Delete(Guid[] ids)
        {
            return Ok(await _trainingManager.DeleteAsync(ids));
        }

    }
}

