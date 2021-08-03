using AutoMapper;
using FashionApp.Entities.Concrete;
using FashionApp.Entities.Dtos.User;

namespace FashionApp.Services.AutoMapper.Profiles
{
    public class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            CreateMap<ApplicationUserAddDto, ApplicationUser>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(x => x.UserName))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(x => x.PasswordHash));




        }
    }
}
