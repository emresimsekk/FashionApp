using AutoMapper;
using FashionApp.Entities.Concrete;
using FashionApp.Entities.Dtos.PrivateInfos;
using System;

namespace FashionApp.Services.AutoMapper.Profiles
{
    public class PrivateInfoProfile : Profile
    {
        public PrivateInfoProfile()
        {
            CreateMap<PrivateInfoAddDto, PrivateInfo>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<PrivateInfoUpdateDto, PrivateInfo>().ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<PrivateInfo, PrivateInfoUpdateDto>();
        }
    }
}
