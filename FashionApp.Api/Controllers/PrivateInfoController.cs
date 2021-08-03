using FashionApp.Entities.Dtos.PrivateInfos;
using FashionApp.Services.Abstract;
using FashionApp.Shared.Utilities.Result.ComplexTypes;
using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FashionApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class PrivateInfoController : ControllerBase
    {
        private readonly IPrivateInfoService _privateInfoService;

        public PrivateInfoController(IPrivateInfoService privateInfoService)
        {
            _privateInfoService = privateInfoService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] PrivateInfoAddDto privateInfoAddDto)
        {
            privateInfoAddDto.UserId =Convert.ToInt32(((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier).Value);

            if (ModelState.IsValid)
            {

                var result = await _privateInfoService.Add(privateInfoAddDto);
                if (result.ResultStatus == ResultStatus.Succes)
                {
                    return Created(string.Empty, result.Data);
                }
                return BadRequest(result.Data);
            }

            return NotFound();
        }

        [HttpGet("{privateInfoId}")]
        public async Task<ActionResult> Get(int privateInfoId)
        {
            var result = await _privateInfoService.Get(privateInfoId);
            return Ok(result.Data);
        }

        [HttpGet("{privateInfoId}")]
        public async Task<ActionResult> GetByUser(int privateInfoId)
        {
            var result = await _privateInfoService.GetByUser(privateInfoId);
            return Ok(result.Data);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult> GetUserId(int userId)
        {
            var result = await _privateInfoService.GetUserId(userId);
            return Ok(result.Data);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult> GetByUserId(int userId)
        {
            var result = await _privateInfoService.GetByUserId(userId);
            return Ok(result.Data);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] PrivateInfoUpdateDto privateInfoUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _privateInfoService.Update(privateInfoUpdateDto);
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
