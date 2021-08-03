using FashionApp.Entities.Concrete;
using FashionApp.Shared.Entities.Abstract;

namespace FashionApp.Entities.Dtos.Follows
{
    public class FollowDto : DtoGetBase
    {
        public Follow Follow { get; set; }
    }
}
