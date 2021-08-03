using FashionApp.Entities.Concrete;
using FashionApp.Shared.Entities.Abstract;

namespace FashionApp.Entities.Dtos.Blockeds
{
    public class BlockedDto : DtoGetBase
    {
        public Blocked Blocked { get; set; }
    }
}
