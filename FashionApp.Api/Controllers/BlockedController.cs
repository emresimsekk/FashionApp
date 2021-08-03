using FashionApp.Entities.Dtos.Blockeds;
using FashionApp.Services.Abstract;
using FashionApp.Shared.Utilities.Result.ComplexTypes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FashionApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlockedController : ControllerBase
    {
        private readonly IBlockedService _blockedService;

        public BlockedController(IBlockedService blockedService)
        {
            _blockedService = blockedService;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult> GetAll(int userId)
        {
            var result = await _blockedService.GetAll(userId);
            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] BlockedAddDto blockedAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _blockedService.Add(blockedAddDto);
                if (result.ResultStatus == ResultStatus.Succes)
                {
                    return Created(string.Empty, result.Data);
                }
                return BadRequest(result.Data);
            }

            return NotFound(null);

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] BlockedUpdateDto blockedUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _blockedService.Update(blockedUpdateDto);
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
