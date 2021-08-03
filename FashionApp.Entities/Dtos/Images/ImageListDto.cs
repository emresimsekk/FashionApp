using FashionApp.Entities.Concrete;
using FashionApp.Shared.Entities.Abstract;
using System.Collections.Generic;

namespace FashionApp.Entities.Dtos.Images
{
    public class ImageListDto : DtoGetBase
    {
        public IList<Image> Images { get; set; }
    }
}
