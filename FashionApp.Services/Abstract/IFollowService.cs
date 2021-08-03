using FashionApp.Entities.Dtos.Follows;
using FashionApp.Shared.Utilities.Result.Abstract;
using System.Threading.Tasks;

namespace FashionApp.Services.Abstract
{
    public interface IFollowService
    {
        Task<IDataResult<FollowListDto>> GetAll(int userId);
        Task<IDataResult<FollowDto>> Add(FollowAddDto followAddDto);
        Task<IDataResult<FollowDto>> Update(FollowUpdateDto followUpdateDto);

    }
}
