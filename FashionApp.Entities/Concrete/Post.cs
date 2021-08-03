using FashionApp.Shared.Entities.Abstract;
using System.Collections.Generic;

namespace FashionApp.Entities.Concrete
{
    public class Post : EntityBase, IEntity
    {
        public int UserId { get; set; }
        public int FullyCombinedId { get; set; }
        public string Description { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public FullyCombine FullyCombine { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
