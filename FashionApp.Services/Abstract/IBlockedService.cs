using FashionApp.Entities.Dtos.Blockeds;
using FashionApp.Shared.Utilities.Result.Abstract;
using System.Threading.Tasks;

namespace FashionApp.Services.Abstract
{
    public interface IBlockedService
    {
        Task<IDataResult<BlockedListDto>> GetAll(int userId);
        Task<IDataResult<BlockedDto>> Add(BlockedAddDto blockedAddDto);
        Task<IDataResult<BlockedDto>> Update(BlockedUpdateDto blockedUpdateDto);

    }
}
