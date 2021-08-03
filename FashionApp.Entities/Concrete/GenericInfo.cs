using FashionApp.Shared.Entities.Abstract;

namespace FashionApp.Entities.Concrete
{
    public class GenericInfo : EntityBase, IEntity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Thumbnail { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
