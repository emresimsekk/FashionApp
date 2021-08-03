using FashionApp.Shared.Entities.Abstract;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FashionApp.Entities.Concrete
{
    public class ApplicationUser : IdentityUser<int>, IEntity
    {
        public GenericInfo GenericInfo { get; set; }
        public PrivateInfo PrivateInfo { get; set; }

        public ICollection<Post> Posts { get; set; }
        public ICollection<Blocked> Blockeds { get; set; }
        public ICollection<Follow> Follows { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
