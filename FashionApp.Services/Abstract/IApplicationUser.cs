using FashionApp.Entities.Dtos.ApplicationUsers;
using FashionApp.Entities.Dtos.User;
using FashionApp.Shared.Utilities.Result.Abstract;
using System.Threading.Tasks;

namespace FashionApp.Services.Abstract
{
    public interface IApplicationUser
    {
        Task<IDataResult<ApplicationUserDto>> Add(ApplicationUserAddDto applicationUserAddDto);
    }
}
