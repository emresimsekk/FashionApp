using FashionApp.Shared.Entities.Abstract;

namespace FashionApp.Entities.Concrete
{
    public class Comment : EntityBase, IEntity
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }

        public Post Post { get; set; }
    }
}
