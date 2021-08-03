using FashionApp.Shared.Entities.Abstract;

namespace FashionApp.Entities.Concrete
{
    public class Blocked : EntityBase, IEntity
    {
        public int UserId { get; set; }
        public int BlockedId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
