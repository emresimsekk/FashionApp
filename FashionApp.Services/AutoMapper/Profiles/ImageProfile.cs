using AutoMapper;
using FashionApp.Entities.Concrete;
using FashionApp.Entities.Dtos.Images;
using System;

namespace FashionApp.Services.AutoMapper.Profiles
{
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<ImageAddDto, Image>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
        }
    }
}
