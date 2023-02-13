using HardTrain.BLL.Abstractions;
using HardTrain.BLL.Models.CommentModels;
using HardTrain.BLL.Models.ExersiceModels;
using HardTrain.BLL.Models.PostModels;
using HardTrain.DAL.Entities.PostScope;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HardTrain.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentManager _commentManager;
        public CommentController(ICommentManager commentManager)
        {
            _commentManager = commentManager;
        }

        [HttpGet("get-all")]
        [ProducesResponseType(typeof(IEnumerable<ExersiceViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _commentManager.GetAllAsync());
        }
        [HttpPost("create")]
        [ProducesResponseType(typeof(ExersiceViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(CommentCreateModel comment)
        {
            if (comment == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _commentManager.CreateCommentAsync(comment));
        }
        [HttpDelete("{id}/delete-by-id")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _commentManager.DeleteAsync(id));
        }
    }
}
