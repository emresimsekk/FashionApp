using FashionApp.Entities.Concrete;
using FashionApp.Shared.Entities.Abstract;
using System.Collections.Generic;

namespace FashionApp.Entities.Dtos.Follows
{
    public class FollowListDto : DtoGetBase
    {
        public IList<Follow> Follows { get; set; }
    }
}
