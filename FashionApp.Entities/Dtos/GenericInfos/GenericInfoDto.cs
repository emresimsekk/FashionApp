using FashionApp.Entities.Concrete;
using FashionApp.Shared.Entities.Abstract;

namespace FashionApp.Entities.Dtos.GenericInfos
{
    public class GenericInfoDto : DtoGetBase
    {
        public GenericInfo GenericInfo { get; set; }
    }
}
