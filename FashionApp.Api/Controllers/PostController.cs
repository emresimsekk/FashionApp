using FashionApp.Entities.Dtos.Posts;
using FashionApp.Services.Abstract;
using FashionApp.Shared.Utilities.Result.ComplexTypes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FashionApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PostAddDto postAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _postService.Add(postAddDto);
                if (result.ResultStatus == ResultStatus.Succes)
                {
                    return Created(string.Empty, result.Data);
                }
                return BadRequest(result.Data);

            }

            return NotFound();

        }


        [HttpGet("{userId}")]
        public async Task<ActionResult> GetAll(int userId)
        {
            var result = await _postService.GetAll(userId);
            return Ok(result.Data);
        }
        [HttpGet("{postId}")]
        public async Task<ActionResult> Get(int postId)
        {
            var result = await _postService.Get(postId);
            return Ok(result.Data);
        }
    }
}
