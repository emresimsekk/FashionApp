using FashionApp.Entities.Dtos.FullyCombines;
using FashionApp.Shared.Utilities.Result.Abstract;
using System.Threading.Tasks;

namespace FashionApp.Services.Abstract
{
    public interface IFullyCombineService
    {
        Task<IDataResult<FullyCombineDto>> Add(FullyCombineAddDto fullyCombineAddDto);


    }
}
