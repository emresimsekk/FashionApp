using AutoMapper;
using FashionApp.Entities.Concrete;
using FashionApp.Entities.Dtos.Follows;
using System;

namespace FashionApp.Services.AutoMapper.Profiles
{
    public class FollowProfile : Profile
    {
        public FollowProfile()
        {
            CreateMap<FollowAddDto, Follow>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<FollowUpdateDto, Follow>().ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Follow, FollowUpdateDto>();
        }
    }
}
