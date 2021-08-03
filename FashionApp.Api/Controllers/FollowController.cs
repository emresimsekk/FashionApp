using FashionApp.Entities.Dtos.Follows;
using FashionApp.Services.Abstract;
using FashionApp.Shared.Utilities.Result.ComplexTypes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FashionApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FollowController : ControllerBase
    {
        private readonly IFollowService _followService;

        public FollowController(IFollowService followService)
        {
            _followService = followService;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult> GetAll(int userId)
        {
            var result = await _followService.GetAll(userId);
            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] FollowAddDto followAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _followService.Add(followAddDto);
                if (result.ResultStatus == ResultStatus.Succes)
                {
                    return Created(string.Empty, result.Data);
                }
                return BadRequest(result.Data);

            }

            return NotFound(null);

        }


        [HttpPut]
        public async Task<IActionResult> Update([FromForm] FollowUpdateDto followUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _followService.Update(followUpdateDto);
                if (result.ResultStatus == ResultStatus.Succes)
                {
                    return Created(string.Empty, result.Data);
                }
                return BadRequest(result.Data);
            }
            return NotFound(null);

        }
    }
}
