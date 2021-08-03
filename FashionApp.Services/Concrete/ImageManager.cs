using AutoMapper;
using FashionApp.Data.Abstract;
using FashionApp.Entities.Concrete;
using FashionApp.Entities.Dtos.Images;
using FashionApp.Services.Abstract;
using FashionApp.Shared.Utilities.Result.Abstract;
using FashionApp.Shared.Utilities.Result.ComplexTypes;
using FashionApp.Shared.Utilities.Result.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FashionApp.Services.Concrete
{
    public class ImageManager : IImageService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ImageManager(IMapper mapper, IUnitOfWork unitOfWork, IFullyCombineService fullyCombineService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<ImageListDto>> AddRange(IList<ImageAddDto> imageAddDto)
        {
            var image = _mapper.Map<List<Image>>(imageAddDto);
            await _unitOfWork.Images.AddRangeAsync(image);
            await _unitOfWork.SaveAsync();

            return new DataResult<ImageListDto>(ResultStatus.Succes, "Resimler başarıyla eklenmiştir !", new ImageListDto
            {
                Images = image,
                ResultStatus = ResultStatus.Succes,
                Message = "Resimler başarıyla eklenmiştir !",
                IsSuccessful = true
            });
        }
    }
}
