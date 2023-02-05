using HardTrain.BLL.Contracts;
using HardTrain.BLL.Models.ExersiceModels;
using HardTrain.BLL.Models.TrainingModels;
using HardTrain.DAL.Entities.TrainingScope;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedPackages.ResponseResultCore.Models;

namespace HardTrain.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ExersiceController : ControllerBase
{
    private readonly IExersiceManager _exersiceManager;

    public ExersiceController(IExersiceManager exersiceManager)
    {
        _exersiceManager = exersiceManager;

    }

    [HttpGet("get-all")]
    [Authorize]
    //[Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(HttpResponseResult<IEnumerable<ExersiceViewModel>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get()
    {

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(await _exersiceManager.GetAllAsync());
    }


    [HttpGet("{id}/get-by-id")]
    [ProducesResponseType(typeof(HttpResponseResult<ExersiceViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get(Guid id)
    {
        if (!await _exersiceManager.IsExists(id))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(await _exersiceManager.GetByIdAsync(id));
    }
    [HttpGet("{title}/get-by-title")]
    [ProducesResponseType(typeof(HttpResponseResult<ExersiceViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get(string title)
    {
        return Ok(await _exersiceManager.GetByTitleAsync(title));
    }

    [HttpPost("create")]
    [ProducesResponseType(typeof(HttpResponseResult<ExersiceViewModel>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create(ExersiceCreateModel exersice)
    {
        if (exersice == null)
            return BadRequest(ModelState);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        //var exersiceMap = _mapper.Map<Exersice>(exersice);

        return Ok(await _exersiceManager.CreateAsync(exersice));
    }

    [HttpPut("update")]
    [ProducesResponseType(typeof(HttpResponseResult<ExersiceViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update(Guid id, ExersiceUpdateModel exersice)
    {

        if (id == default || exersice is null || id != exersice.Id)
        {
            return BadRequest(ModelState);
        }
        //var exersiceMap = _mapper.Map<Exersice>(exersice);

        return Ok(await _exersiceManager.UpdateAsync(exersice));
    }

    [HttpDelete("{id}/delete-by-id")]
    [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (!await _exersiceManager.IsExists(id))
            return NotFound();

        return Ok(await _exersiceManager.DeleteAsync(id));
    }

    [HttpDelete("bulk")]
    [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(Guid[] ids)
    {
        if (ids.Any())
            return BadRequest();

        return Ok(await _exersiceManager.DeleteAsync(ids));
    }



}
