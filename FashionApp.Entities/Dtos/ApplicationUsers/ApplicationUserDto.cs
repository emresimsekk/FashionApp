using FashionApp.Entities.Concrete;
using FashionApp.Shared.Entities.Abstract;

namespace FashionApp.Entities.Dtos.ApplicationUsers
{
    public class ApplicationUserDto : DtoGetBase
    {
        public ApplicationUser ApplicationUser { get; set; }
    }
}
