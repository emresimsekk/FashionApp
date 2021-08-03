using FashionApp.Shared.Entities.Abstract;

namespace FashionApp.Entities.Concrete
{
    public class Like : EntityBase, IEntity
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public Post Post { get; set; }

    }
}
