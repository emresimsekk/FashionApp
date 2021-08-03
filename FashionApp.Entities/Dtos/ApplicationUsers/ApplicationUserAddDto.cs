using FashionApp.Shared.Entities.Abstract;

namespace FashionApp.Entities.Dtos.User
{
    public class ApplicationUserAddDto : DtoGetBase
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
    }
}
