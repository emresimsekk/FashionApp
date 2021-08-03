using FashionApp.Shared.Entities.Abstract;

namespace FashionApp.Entities.Concrete
{
    public class Tag : EntityBase, IEntity
    {
        public int FullyCombineId { get; set; }
        public string Name { get; set; }

        public FullyCombine FullyCombine { get; set; }
    }
}
