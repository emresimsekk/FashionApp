using FashionApp.Shared.Entities.Abstract;
using System.Collections.Generic;

namespace FashionApp.Entities.Concrete
{
    public class FullyCombine : EntityBase, IEntity
    {
        public string Path { get; set; }
        public Post Post { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
