using FashionApp.Entities.Concrete;
using FashionApp.Shared.Entities.Abstract;
using System.Collections.Generic;

namespace FashionApp.Entities.Dtos.Tags
{
    public class TagListDto : DtoGetBase
    {
        public IList<Tag> Tags { get; set; }
    }
}
