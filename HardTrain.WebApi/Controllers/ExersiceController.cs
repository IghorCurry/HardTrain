using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using HardTrain.BLL.Contracts;
using HardTrain.BLL.Managers;
using HardTrain.DAL.Entities.ExersiceEntities;
using HardTrain.BLL.Models;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Get()
        {
            var V = await _exersiceManager.GetAllAsync(); 
            return Ok(await _exersiceManager.GetAllAsync());
        }


        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _exersiceManager.GetByIdAsync(id));
        }
        [HttpGet("{title}")]
        public async Task<IActionResult> Get(string title)
        {
            return Ok(await _exersiceManager.GetByTitleAsync(title));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(ExersiceCreateModel exersice)
        {
            return Ok(await _exersiceManager.CreateAsync(exersice));
        }

    //        [HttpPut("{id}")]
    //        public async Task<IActionResult> Update(Guid id, ExersiceModel exersice)
    //        {

    //            if (id == default || exersice is null || id != exersice.Id)
    //            {

    //            }

    //            return await _exersiceManager.UpdateAsync(exersice);
    //    }

    //        [HttpDelete("{id}")]
    //        public async Task<IActionResult> Delete(Guid id)
    //        {
    //            return await _exersiceManager.DeleteAsync(id)
    //        }

    //        [HttpDelete]
    //        public async Task<IActionResult> Delete([FromBody] Guid[] ids)
    //        {
    //            return await _exersiceManager.DeleteAsync(ids);
    //        }
}

