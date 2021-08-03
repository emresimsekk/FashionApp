using FashionApp.Entities.Concrete;
using FashionApp.Shared.Entities.Abstract;
using System.Collections.Generic;

namespace FashionApp.Entities.Dtos.Likes
{
    public class LikeListDto : DtoGetBase
    {
        public IList<Like> Likes { get; set; }


    }
}
