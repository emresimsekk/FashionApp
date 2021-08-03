using FashionApp.Shared.Entities.Abstract;

namespace FashionApp.Entities.Concrete
{
    public class Image : EntityBase, IEntity
    {
        public int FullyCombineId { get; set; }
        public int BodySizeId { get; set; }
        public int ColorId { get; set; }
        public string Path { get; set; }
        public string Brand { get; set; }

        public FullyCombine FullyCombine { get; set; }
        public BodySize BodySize { get; set; }
        public Color Color { get; set; }

    }
}
