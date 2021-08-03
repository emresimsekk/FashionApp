using AutoMapper;
using FashionApp.Data.Abstract;
using FashionApp.Entities.Concrete;
using FashionApp.Entities.Dtos.FullyCombines;
using FashionApp.Services.Abstract;
using FashionApp.Shared.Utilities.Result.Abstract;
using FashionApp.Shared.Utilities.Result.ComplexTypes;
using FashionApp.Shared.Utilities.Result.Concrete;
using System.Threading.Tasks;

namespace FashionApp.Services.Concrete
{
    public class FullyCombineManager : IFullyCombineService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FullyCombineManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<FullyCombineDto>> Add(FullyCombineAddDto fullyCombineAddDto)
        {
            var fullyCombine = _mapper.Map<FullyCombine>(fullyCombineAddDto);

            var addedFullyCombine = await _unitOfWork.FullyCombines.AddAsync(fullyCombine);
            await _unitOfWork.SaveAsync();

            return new DataResult<FullyCombineDto>(ResultStatus.Succes, "Combine bilgileri başarıyla eklenmiştir !", new FullyCombineDto
            {
                FullyCombine = addedFullyCombine,
                ResultStatus = ResultStatus.Succes,
                Message = "Combine bilgileri başarıyla eklenmiştir !",
                IsSuccessful = true

            });
        }
    }
}
