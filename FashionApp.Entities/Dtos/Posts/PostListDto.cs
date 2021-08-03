using FashionApp.Entities.Concrete;
using FashionApp.Shared.Entities.Abstract;
using System.Collections.Generic;

namespace FashionApp.Entities.Dtos.Posts
{
    public class PostListDto : DtoGetBase
    {
        public IList<Post> Posts { get; set; }
    }
}
