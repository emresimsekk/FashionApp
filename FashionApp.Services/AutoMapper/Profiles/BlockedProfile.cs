using AutoMapper;
using FashionApp.Entities.Concrete;
using FashionApp.Entities.Dtos.Blockeds;
using System;

namespace FashionApp.Services.AutoMapper.Profiles
{
    public class BlockedProfile : Profile
    {
        public BlockedProfile()
        {
            CreateMap<BlockedAddDto, Blocked>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<BlockedUpdateDto, Blocked>().ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Blocked, BlockedUpdateDto>();
        }
    }
}
