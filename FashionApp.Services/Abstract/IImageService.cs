using FashionApp.Entities.Dtos.Images;
using FashionApp.Shared.Utilities.Result.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FashionApp.Services.Abstract
{
    public interface IImageService
    {
        Task<IDataResult<ImageListDto>> AddRange(IList<ImageAddDto> imageAddDto);

    }
}
