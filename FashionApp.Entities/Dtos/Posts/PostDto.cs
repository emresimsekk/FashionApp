using FashionApp.Entities.Concrete;
using FashionApp.Shared.Entities.Abstract;
using System.Text.Json.Serialization;

namespace FashionApp.Entities.Dtos.Posts
{
    public class PostDto : DtoGetBase
    {
        public Post Post { get; set; }

        [JsonIgnore]
        public int LikeCount { get; set; }

        [JsonIgnore]
        public int CommentCount { get; set; }

    }
}
