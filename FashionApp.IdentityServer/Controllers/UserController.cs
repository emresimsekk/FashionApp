using FashionApp.Entities.Dtos.User;
using FashionApp.Services.Abstract;
using FashionApp.Shared.Utilities.Result.ComplexTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace FashionApp.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IApplicationUser _applicationUser;

        public UserController(IApplicationUser applicationUser)
        {
            _applicationUser = applicationUser;
        }


        [HttpPost]
        public async Task<IActionResult> SignUp(ApplicationUserAddDto applicationUserAddDto)
        {

            var result = await _applicationUser.Add(applicationUserAddDto);
            if (result.ResultStatus == ResultStatus.Succes)
            {
                return Created(string.Empty, result.Data);
            }
            return BadRequest(result.Data);


        }
    }
}
