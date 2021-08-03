using FashionApp.Entities.Dtos.GenericInfos;
using FashionApp.Services.Abstract;
using FashionApp.Shared.Utilities.Result.ComplexTypes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FashionApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GenericInfoController : ControllerBase
    {
        private readonly IGenericInfoService _genericInfoService;

        public GenericInfoController(IGenericInfoService genericInfoService)
        {
            _genericInfoService = genericInfoService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] GenericInfoAddDto genericInfoAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _genericInfoService.Add(genericInfoAddDto);
                if (result.ResultStatus == ResultStatus.Succes)
                {
                    return Created(string.Empty, result.Data);
                }
                return BadRequest(result.Data);

            }

            return NotFound();

        }

        [HttpGet("{genericInfoId}")]
        public async Task<ActionResult> Get(int genericInfoId)
        {
            var result = await _genericInfoService.Get(genericInfoId);
            return Ok(result.Data);
        }

        [HttpGet("{genericInfoId}")]
        public async Task<ActionResult> GetByUser(int genericInfoId)
        {
            var result = await _genericInfoService.GetByUser(genericInfoId);
            return Ok(result.Data);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult> GetUserId(int userId)
        {
            var result = await _genericInfoService.GetUserId(userId);
            return Ok(result.Data);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult> GetByUserId(int userId)
        {
            var result = await _genericInfoService.GetByUserId(userId);
            return Ok(result.Data);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] GenericInfoUpdateDto genericInfoUpdateDto)
        {

            if (ModelState.IsValid)
            {
                var result = await _genericInfoService.Update(genericInfoUpdateDto);
                if (result.ResultStatus == ResultStatus.Succes)
                {
                    return Created(string.Empty, result.Data);
                }
                return BadRequest(result.Data);
            }
            return NotFound();

        }
    }
}
