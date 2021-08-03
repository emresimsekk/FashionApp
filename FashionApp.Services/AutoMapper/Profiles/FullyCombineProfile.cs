using AutoMapper;
using FashionApp.Entities.Concrete;
using FashionApp.Entities.Dtos.FullyCombines;
using System;

namespace FashionApp.Services.AutoMapper.Profiles
{
    public class FullyCombineProfile : Profile
    {
        public FullyCombineProfile()
        {

            CreateMap<FullyCombineAddDto, FullyCombine>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));

        }
    }
}
