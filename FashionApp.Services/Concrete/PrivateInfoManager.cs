using AutoMapper;
using FashionApp.Data.Abstract;
using FashionApp.Entities.Concrete;
using FashionApp.Entities.Dtos.PrivateInfos;
using FashionApp.Services.Abstract;
using FashionApp.Shared.Utilities.Result.Abstract;
using FashionApp.Shared.Utilities.Result.ComplexTypes;
using FashionApp.Shared.Utilities.Result.Concrete;
using System;
using System.Threading.Tasks;

namespace FashionApp.Services.Concrete
{
    public class PrivateInfoManager : IPrivateInfoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PrivateInfoManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<PrivateInfoDto>> Add(PrivateInfoAddDto privateInfoAddDto)
        {
            var isUser = await _unitOfWork.ApplicationUsers.AnyAsync(u => u.Id == privateInfoAddDto.UserId);
            if (!isUser)
            {
                return new DataResult<PrivateInfoDto>(ResultStatus.Error, "Böyle bir kullanıcı bulunamadı !", new PrivateInfoDto
                {
                    PrivateInfo = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "Böyle bir kullanıcı bulunamadı !",
                    IsSuccessful = false
                });
            }

            var isPrivateInfo = await _unitOfWork.PrivateInfos.AnyAsync(u => u.UserId == privateInfoAddDto.UserId);
            if (isPrivateInfo)
            {
                return new DataResult<PrivateInfoDto>(ResultStatus.Error, "Kişisel bilgiler daha önceden kaydedilmiştir !", new PrivateInfoDto
                {
                    PrivateInfo = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "Kişisel bilgiler daha önceden kaydedilmiştir !",
                    IsSuccessful = false
                });
            }

            var privateInfo = _mapper.Map<PrivateInfo>(privateInfoAddDto);
            var addedPrivateInfo = await _unitOfWork.PrivateInfos.AddAsync(privateInfo);
            await _unitOfWork.SaveAsync();
            return new DataResult<PrivateInfoDto>(ResultStatus.Succes, "Kişisel bilgiler başarıyla eklenmiştir !", new PrivateInfoDto
            {
                PrivateInfo = addedPrivateInfo,
                ResultStatus = ResultStatus.Succes,
                Message = "Kişisel bilgiler başarıyla eklenmiştir !",
                IsSuccessful = true
            });
        }

        public async Task<IDataResult<PrivateInfoDto>> Get(int privateInfoId)
        {
            var privateInfo = await _unitOfWork.PrivateInfos.GetAsync(p => p.Id == privateInfoId);
            if (privateInfo == null)
            {
                return new DataResult<PrivateInfoDto>(ResultStatus.Error, "Böyle bir kullanıcı bilgisi bulunamadı !", new PrivateInfoDto
                {
                    PrivateInfo = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "Böyle bir kullanıcı bilgisi bulunamadı !",
                    IsSuccessful = true
                });
            }

            return new DataResult<PrivateInfoDto>(ResultStatus.Succes, new PrivateInfoDto
            {
                PrivateInfo = privateInfo,
                ResultStatus = ResultStatus.Succes,
                IsSuccessful = true
            });

        }

        public async Task<IDataResult<PrivateInfoDto>> GetByUser(int privateInfoId)
        {
            var privateInfoByUser = await _unitOfWork.PrivateInfos.GetAsync(p => p.Id == privateInfoId, u => u.ApplicationUser);
            if (privateInfoByUser == null)
            {
                return new DataResult<PrivateInfoDto>(ResultStatus.Error, "Böyle bir kullanıcı bilgisi bulunamadı !", new PrivateInfoDto
                {
                    PrivateInfo = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "Böyle bir kullanıcı bilgisi bulunamadı !",
                    IsSuccessful = true
                });
            }

            return new DataResult<PrivateInfoDto>(ResultStatus.Succes, new PrivateInfoDto
            {
                PrivateInfo = privateInfoByUser,
                ResultStatus = ResultStatus.Succes,
                IsSuccessful = true
            });

        }

        public async Task<IDataResult<PrivateInfoDto>> GetByUserId(int userId)
        {
            var privateInfoByUser = await _unitOfWork.PrivateInfos.GetAsync(p => p.UserId == userId, u => u.ApplicationUser);

            if (privateInfoByUser == null)
            {
                return new DataResult<PrivateInfoDto>(ResultStatus.Error, "Böyle bir kullanıcı bilgisi bulunamadı !", new PrivateInfoDto
                {
                    PrivateInfo = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "Böyle bir kullanıcı bilgisi bulunamadı !",
                    IsSuccessful = true
                });
            }

            return new DataResult<PrivateInfoDto>(ResultStatus.Succes, new PrivateInfoDto
            {
                PrivateInfo = privateInfoByUser,
                ResultStatus = ResultStatus.Succes,
                IsSuccessful = true
            });

        }

        public async Task<IDataResult<PrivateInfoDto>> GetUserId(int userId)
        {
            var privateInfo = await _unitOfWork.PrivateInfos.GetAsync(p => p.UserId == userId);
            if (privateInfo == null)
            {
                return new DataResult<PrivateInfoDto>(ResultStatus.Error, "Böyle bir kullanıcı bilgisi bulunamadı !", new PrivateInfoDto
                {
                    PrivateInfo = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "Böyle bir kullanıcı bilgisi bulunamadı !",
                    IsSuccessful = true
                });
            }

            return new DataResult<PrivateInfoDto>(ResultStatus.Succes, new PrivateInfoDto
            {
                PrivateInfo = privateInfo,
                ResultStatus = ResultStatus.Succes,
                IsSuccessful = true
            });

        }

        public async Task<IDataResult<PrivateInfoDto>> Update(PrivateInfoUpdateDto privateInfoUpdateDto)
        {
            var isUser = await _unitOfWork.ApplicationUsers.AnyAsync(u => u.Id == privateInfoUpdateDto.UserId);
            if (!isUser)
            {
                return new DataResult<PrivateInfoDto>(ResultStatus.Error, "Böyle bir kullanıcı bilgisi bulunamadı !", new PrivateInfoDto
                {
                    PrivateInfo = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "Böyle bir kullanıcı bilgisi bulunamadı !",
                    IsSuccessful = true
                });
            }

            var oldPrivateInfo = await _unitOfWork.PrivateInfos.GetAsync(p => p.Id == privateInfoUpdateDto.Id && p.UserId == privateInfoUpdateDto.UserId);
            if (oldPrivateInfo == null)
            {
                return new DataResult<PrivateInfoDto>(ResultStatus.Error, "Kişisel bilgiler bilgisi bulunamadı !", new PrivateInfoDto
                {
                    PrivateInfo = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "Kişisel bilgiler bilgisi bulunamadı !",
                    IsSuccessful = true
                });
            }

            var privateInfo = _mapper.Map<PrivateInfoUpdateDto, PrivateInfo>(privateInfoUpdateDto, oldPrivateInfo);
            privateInfo.ModifiedDate = DateTime.Now;
            var updatedPrivateInfo = await _unitOfWork.PrivateInfos.UpdateAsync(privateInfo);
            await _unitOfWork.SaveAsync();

            return new DataResult<PrivateInfoDto>(ResultStatus.Succes, "Kişisel bilgiler başarıyla güncellenmiştir !", new PrivateInfoDto
            {
                PrivateInfo = updatedPrivateInfo,
                ResultStatus = ResultStatus.Succes,
                Message = "Kişisel bilgiler  başarıyla güncellenmiştir !",
                IsSuccessful = true
            });


        }
    }
}
