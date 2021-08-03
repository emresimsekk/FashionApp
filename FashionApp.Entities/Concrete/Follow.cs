using FashionApp.Shared.Entities.Abstract;

namespace FashionApp.Entities.Concrete
{
    public class Follow : EntityBase, IEntity
    {
        public int UserId { get; set; }
        public int FollowedId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
