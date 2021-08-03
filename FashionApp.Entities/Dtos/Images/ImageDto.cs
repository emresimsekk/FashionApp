using FashionApp.Entities.Concrete;
using FashionApp.Shared.Entities.Abstract;

namespace FashionApp.Entities.Dtos.Images
{
    public class ImageDto : DtoGetBase
    {
        public Image Image { get; set; }
    }
}
