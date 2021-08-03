using FashionApp.Entities.Dtos.PrivateInfos;
using FashionApp.Shared.Utilities.Result.Abstract;
using System.Threading.Tasks;

namespace FashionApp.Services.Abstract
{
    public interface IPrivateInfoService
    {
        Task<IDataResult<PrivateInfoDto>> Get(int privateInfoId);
        Task<IDataResult<PrivateInfoDto>> Add(PrivateInfoAddDto privateInfoAddDto);
        Task<IDataResult<PrivateInfoDto>> Update(PrivateInfoUpdateDto privateInfoUpdateDto);
        Task<IDataResult<PrivateInfoDto>> GetByUser(int privateInfoId);
        Task<IDataResult<PrivateInfoDto>> GetUserId(int userId);
        Task<IDataResult<PrivateInfoDto>> GetByUserId(int userId);
    }
}
