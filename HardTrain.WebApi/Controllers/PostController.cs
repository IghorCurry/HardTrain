using HardTrain.BLL.Abstractions;
using HardTrain.BLL.Managers;
using HardTrain.BLL.Models.ExersiceModels;
using HardTrain.BLL.Models.PostModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HardTrain.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostManager _postManager;
        public PostController(IPostManager postManager)
        {
            _postManager = postManager;
        }

        [HttpGet("get-all")]
        [ProducesResponseType(typeof(IEnumerable<ExersiceViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _postManager.GetAllAsync());
        }
        [Authorize(Policy = "RequireManager")]
        [HttpPost("create")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExersiceViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(PostCreateModel post)
        {
            if (post == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _postManager.CreatePostAsync(post));
        }
        [Authorize(Policy = "RequireManager")]
        [HttpPut("update")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExersiceViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(Guid id, PostUpdateModel post)
        {

            if (id == default || post is null || id != post.Id)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _postManager.UpdateAsync(post));
        }

        [HttpDelete("{id}/delete-by-id")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid id)
        {
           
            return Ok(await _postManager.DeleteAsync(id));
        }
    }
}
