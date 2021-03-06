using FashionApp.Shared.Entities.Abstract;
using System.Collections.Generic;

namespace FashionApp.Entities.Concrete
{
    public class Color : EntityBase, IEntity
    {
        public string Name { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
