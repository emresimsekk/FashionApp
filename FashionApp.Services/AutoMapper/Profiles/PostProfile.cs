using AutoMapper;
using FashionApp.Entities.Concrete;
using FashionApp.Entities.Dtos.Posts;
using System;

namespace FashionApp.Services.AutoMapper.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<PostAddDto, Post>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
            //CreateMap<GenericInfoUpdateDto, GenericInfo>().ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
            //CreateMap<GenericInfo, GenericInfoUpdateDto>();
        }
    }
}
