using FashionApp.Entities.Dtos.GenericInfos;
using FashionApp.Shared.Utilities.Result.Abstract;
using System.Threading.Tasks;

namespace FashionApp.Services.Abstract
{
    public interface IGenericInfoService
    {
        Task<IDataResult<GenericInfoDto>> Get(int genericInfoId);
        Task<IDataResult<GenericInfoDto>> Add(GenericInfoAddDto genericInfoAddDto);
        Task<IDataResult<GenericInfoDto>> Update(GenericInfoUpdateDto genericInfoUpdateDto);
        Task<IDataResult<GenericInfoDto>> GetByUser(int genericInfoId);
        Task<IDataResult<GenericInfoDto>> GetUserId(int userId);
        Task<IDataResult<GenericInfoDto>> GetByUserId(int userId);

    }
}
