using FashionApp.Shared.Entities.Abstract;

namespace FashionApp.Entities.Concrete
{
    public class Message : EntityBase, IEntity
    {
        public int UserId { get; set; }
        public int ReceiverId { get; set; }
        public string Content { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
