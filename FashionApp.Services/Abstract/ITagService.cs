using FashionApp.Entities.Dtos.Tags;
using FashionApp.Shared.Utilities.Result.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FashionApp.Services.Abstract
{
    public interface ITagService
    {
        Task<IDataResult<TagListDto>> AddRange(IList<TagAddDto> tagAddDto);
    }
}
