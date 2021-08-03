using FashionApp.Entities.Concrete;
using FashionApp.Shared.Entities.Abstract;
using System.Collections.Generic;

namespace FashionApp.Entities.Dtos.Blockeds
{
    public class BlockedListDto : DtoGetBase
    {
        public IList<Blocked> Blockeds { get; set; }
    }
}
