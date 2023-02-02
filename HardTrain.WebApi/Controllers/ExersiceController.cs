using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using HardTrain.BLL.Contracts;
using HardTrain.BLL.Managers;
using HardTrain.BLL.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Net;
using HardTrain.DAL.Enums;
using HardTrain.DAL.Entities.TrainingScope;
using HardTrain.BLL.Models.ExersiceModels;

namespace HardTrain.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ExersiceController : ControllerBase
{
    private readonly IExersiceManager _exersiceManager;
    private readonly IMapper _mapper;

    public ExersiceController(IExersiceManager exersiceManager, IMapper mapper)
    {
        _exersiceManager = exersiceManager;
        _mapper = mapper;

    }

    [HttpGet("get-all")]
    public async Task<IActionResult> Get()
    {

        var V = _mapper.Map<List<ExersiceViewModel>>(await _exersiceManager.GetAllAsync());

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(await _exersiceManager.GetAllAsync());
    }


    [HttpGet("{id}/get-by-id")]
    //[Authorize]
    [ProducesResponseType(200, Type = typeof(Exersice))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Get(Guid id)
    {
        if (!await _exersiceManager.IsExists(id))
            return NotFound();

        var exersice = _mapper.Map<ExersiceViewModel>(await _exersiceManager.GetByIdAsync(id));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(await _exersiceManager.GetByIdAsync(id));
    }
    [HttpGet("{title}/get-by-title")]
    [ProducesResponseType(200, Type = typeof(Exersice))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Get(string title)
    {
        return Ok(await _exersiceManager.GetByTitleAsync(title));
    }

    [HttpPost("create")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
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
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update(Guid id, ExersiceUpdateModel exersice)
    {

        if (id == default || exersice is null || id != exersice.Id)
        {
            return BadRequest(ModelState);
        }
        var exersiceMap = _mapper.Map<Exersice>(exersice);

        return Ok(await _exersiceManager.UpdateAsync(exersice));
    }

    [HttpDelete("{id}/delete-by-id")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (!await _exersiceManager.IsExists(id))
            return NotFound();

        return Ok(await _exersiceManager.DeleteAsync(id));
    }

    [HttpDelete("bulk")]
    public async Task<IActionResult> Delete(Guid[] ids)
    {
        if (ids.Any())
            return BadRequest();

        return Ok(await _exersiceManager.DeleteAsync(ids));
    }



}
