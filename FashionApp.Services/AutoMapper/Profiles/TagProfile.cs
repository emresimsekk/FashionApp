using AutoMapper;
using FashionApp.Entities.Concrete;
using FashionApp.Entities.Dtos.Tags;
using System;

namespace FashionApp.Services.AutoMapper.Profiles
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<TagAddDto, Tag>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
        }
    }
}
