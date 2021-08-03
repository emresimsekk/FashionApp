using AutoMapper;
using FashionApp.Entities.Concrete;
using FashionApp.Entities.Dtos.ApplicationUsers;
using FashionApp.Entities.Dtos.User;
using FashionApp.Services.Abstract;
using FashionApp.Shared.Utilities.Result.Abstract;
using FashionApp.Shared.Utilities.Result.ComplexTypes;
using FashionApp.Shared.Utilities.Result.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FashionApp.Services.Concrete
{
    public class ApplicationUserManager : IApplicationUser
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public ApplicationUserManager(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IDataResult<ApplicationUserDto>> Add(ApplicationUserAddDto applicationUserAddDto)
        {
            var user = _mapper.Map<ApplicationUser>(applicationUserAddDto);
            var result = await _userManager.CreateAsync(user, applicationUserAddDto.PasswordHash);

            if (!result.Succeeded)
            {
                return new DataResult<ApplicationUserDto>(ResultStatus.Error, String.Concat(result.Errors.AsEnumerable().Select(err => err.Description)), new ApplicationUserDto
                {
                    ApplicationUser = null,
                    ResultStatus = ResultStatus.Error,
                    Message = String.Concat(result.Errors.AsEnumerable().Select(err => err.Description)),
                    IsSuccessful = false
                });
            }

            return new DataResult<ApplicationUserDto>(ResultStatus.Succes, "Kullanıcı başarıyla kaydedildi !", new ApplicationUserDto
            {
                ApplicationUser = user,
                ResultStatus = ResultStatus.Succes,
                Message = "Kullanıcı başarıyla kaydedildi !",
                IsSuccessful = true

            });

        }
    }
}
