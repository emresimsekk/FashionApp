using AutoMapper;
using FashionApp.Data.Abstract;
using FashionApp.Entities.Concrete;
using FashionApp.Entities.Dtos.Tags;
using FashionApp.Services.Abstract;
using FashionApp.Shared.Utilities.Result.Abstract;
using FashionApp.Shared.Utilities.Result.ComplexTypes;
using FashionApp.Shared.Utilities.Result.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FashionApp.Services.Concrete
{

    public class TagManager : ITagService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TagManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<TagListDto>> AddRange(IList<TagAddDto> tagAddDto)
        {
            var tags = _mapper.Map<List<Tag>>(tagAddDto);
            await _unitOfWork.Tags.AddRangeAsync(tags);
            await _unitOfWork.SaveAsync();

            return new DataResult<TagListDto>(ResultStatus.Succes, "Resimler başarıyla eklenmiştir !", new TagListDto
            {
                Tags = tags,
                ResultStatus = ResultStatus.Succes,
                Message = "Etiketler başarıyla eklenmiştir !",
                IsSuccessful = true
            });
        }
    }
}
