using AutoMapper;
using FashionApp.Data.Abstract;
using FashionApp.Entities.Concrete;
using FashionApp.Entities.Dtos.GenericInfos;
using FashionApp.Services.Abstract;
using FashionApp.Shared.Utilities.Result.Abstract;
using FashionApp.Shared.Utilities.Result.ComplexTypes;
using FashionApp.Shared.Utilities.Result.Concrete;
using System;
using System.Threading.Tasks;

namespace FashionApp.Services.Concrete
{
    public class GenericInfoManager : IGenericInfoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GenericInfoManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<GenericInfoDto>> Add(GenericInfoAddDto genericInfoAddDto)
        {
            var isUser = await _unitOfWork.ApplicationUsers.AnyAsync(u => u.Id == genericInfoAddDto.UserId);
            if (!isUser)
            {
                return new DataResult<GenericInfoDto>(ResultStatus.Error, "Böyle bir kullanıcı bulunamadı !", new GenericInfoDto
                {
                    GenericInfo = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "Böyle bir kullanıcı bulunamadı !",
                    IsSuccessful = true

                });
            }

            var isGenericInfo = await _unitOfWork.GenericInfos.AnyAsync(g => g.ApplicationUser.Id == genericInfoAddDto.UserId);
            if (isGenericInfo)
            {
                return new DataResult<GenericInfoDto>(ResultStatus.Error, "Genel bilgiler daha önceden kaydedilmiştir !", new GenericInfoDto
                {
                    GenericInfo = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "Genel bilgiler daha önceden kaydedilmiştir !",
                    IsSuccessful = false
                });
            }

            var genericInfo = _mapper.Map<GenericInfo>(genericInfoAddDto);
            var addedGenericInfo = await _unitOfWork.GenericInfos.AddAsync(genericInfo);
            await _unitOfWork.SaveAsync();

            return new DataResult<GenericInfoDto>(ResultStatus.Succes, "Genel bilgiler başarıyla eklenmiştir !", new GenericInfoDto
            {
                GenericInfo = addedGenericInfo,
                ResultStatus = ResultStatus.Succes,
                Message = "Genel bilgiler başarıyla eklenmiştir !",
                IsSuccessful = true

            });



        }

        public async Task<IDataResult<GenericInfoDto>> Get(int genericInfoId)
        {
            var genericInfo = await _unitOfWork.GenericInfos.GetAsync(g => g.Id == genericInfoId);
            if (genericInfo == null)
            {
                return new DataResult<GenericInfoDto>(ResultStatus.Error, "Böyle bir kullanıcı bilgisi bulunamadı !", new GenericInfoDto
                {
                    GenericInfo = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "Böyle bir kullanıcı bilgisi bulunamadı !",
                    IsSuccessful = true
                });
            }

            return new DataResult<GenericInfoDto>(ResultStatus.Succes, new GenericInfoDto
            {
                GenericInfo = genericInfo,
                ResultStatus = ResultStatus.Succes,
                IsSuccessful = true
            });

        }

        public async Task<IDataResult<GenericInfoDto>> GetByUser(int genericInfoId)
        {
            var genericInfoByUser = await _unitOfWork.GenericInfos.GetAsync(g => g.Id == genericInfoId, u => u.ApplicationUser);
            if (genericInfoByUser == null)
            {
                return new DataResult<GenericInfoDto>(ResultStatus.Error, "Böyle bir kullanıcı bilgisi bulunamadı !", new GenericInfoDto
                {
                    GenericInfo = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "Böyle bir kullanıcı bilgisi bulunamadı !",
                    IsSuccessful = true
                });
            }

            return new DataResult<GenericInfoDto>(ResultStatus.Succes, new GenericInfoDto
            {
                GenericInfo = genericInfoByUser,
                ResultStatus = ResultStatus.Succes,
                IsSuccessful = true
            });

        }

        public async Task<IDataResult<GenericInfoDto>> GetUserId(int userId)
        {
            var genericInfo = await _unitOfWork.GenericInfos.GetAsync(g => g.UserId == userId);
            if (genericInfo == null)
            {
                return new DataResult<GenericInfoDto>(ResultStatus.Error, "Böyle bir kullanıcı bilgisi bulunamadı !", new GenericInfoDto
                {
                    GenericInfo = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "Böyle bir kullanıcı bilgisi bulunamadı !",
                    IsSuccessful = true
                });
            }

            return new DataResult<GenericInfoDto>(ResultStatus.Succes, new GenericInfoDto
            {
                GenericInfo = genericInfo,
                ResultStatus = ResultStatus.Succes,
                IsSuccessful = true
            });

        }

        public async Task<IDataResult<GenericInfoDto>> GetByUserId(int userId)
        {
            var genericInfoByUser = await _unitOfWork.GenericInfos.GetAsync(g => g.UserId == userId, u => u.ApplicationUser);
            if (genericInfoByUser == null)
            {
                return new DataResult<GenericInfoDto>(ResultStatus.Error, "Böyle bir kullanıcı bilgisi bulunamadı !", new GenericInfoDto
                {
                    GenericInfo = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "Böyle bir kullanıcı bilgisi bulunamadı !",
                    IsSuccessful = true
                });
            }

            return new DataResult<GenericInfoDto>(ResultStatus.Succes, new GenericInfoDto
            {
                GenericInfo = genericInfoByUser,
                ResultStatus = ResultStatus.Succes,
                IsSuccessful = true
            });

        }

        public async Task<IDataResult<GenericInfoDto>> Update(GenericInfoUpdateDto genericInfoUpdateDto)
        {
            var isUser = await _unitOfWork.ApplicationUsers.AnyAsync(u => u.Id == genericInfoUpdateDto.UserId);
            if (!isUser)
            {
                return new DataResult<GenericInfoDto>(ResultStatus.Error, "Böyle bir kullanıcı bilgisi bulunamadı !", new GenericInfoDto
                {
                    GenericInfo = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "Böyle bir kullanıcı bilgisi bulunamadı !",
                    IsSuccessful = true
                });
            }

            var oldGenericInfo = await _unitOfWork.GenericInfos.GetAsync(g => g.Id == genericInfoUpdateDto.Id && g.UserId == genericInfoUpdateDto.UserId);
            if (oldGenericInfo == null)
            {
                return new DataResult<GenericInfoDto>(ResultStatus.Error, "Genel bilgiler bilgisi bulunamadı !", new GenericInfoDto
                {
                    GenericInfo = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "Genel bilgiler bilgisi bulunamadı !",
                    IsSuccessful = true
                });
            }

            var genericInfo = _mapper.Map<GenericInfoUpdateDto, GenericInfo>(genericInfoUpdateDto, oldGenericInfo);
            genericInfo.ModifiedDate = DateTime.Now;
            var updatedGenericInfo = await _unitOfWork.GenericInfos.UpdateAsync(genericInfo);
            await _unitOfWork.SaveAsync();

            return new DataResult<GenericInfoDto>(ResultStatus.Succes, "Genel bilgileri başarıyla güncellenmiştir !", new GenericInfoDto
            {
                GenericInfo = updatedGenericInfo,
                ResultStatus = ResultStatus.Succes,
                Message = "Genel bilgileri başarıyla güncellenmiştir !",
                IsSuccessful = true

            });

        }
    }
}
