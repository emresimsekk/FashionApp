using AutoMapper;
using FashionApp.Entities.Concrete;
using FashionApp.Entities.Dtos.GenericInfos;
using System;

namespace FashionApp.Services.AutoMapper.Profiles
{
    public class GenericInfoProfile : Profile
    {
        public GenericInfoProfile()
        {
            CreateMap<GenericInfoAddDto, GenericInfo>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<GenericInfoUpdateDto, GenericInfo>().ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<GenericInfo, GenericInfoUpdateDto>();
        }
    }
}
