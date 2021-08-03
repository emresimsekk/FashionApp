using FashionApp.Entities.Concrete;
using FashionApp.Shared.Entities.Abstract;

namespace FashionApp.Entities.Dtos.PrivateInfos
{
    public class PrivateInfoDto : DtoGetBase
    {
        public PrivateInfo PrivateInfo { get; set; }
    }
}
