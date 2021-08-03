using AutoMapper;
using FashionApp.Data.Abstract;
using FashionApp.Entities.Concrete;
using FashionApp.Entities.Dtos.Follows;
using FashionApp.Services.Abstract;
using FashionApp.Shared.Utilities.Result.Abstract;
using FashionApp.Shared.Utilities.Result.ComplexTypes;
using FashionApp.Shared.Utilities.Result.Concrete;
using System;
using System.Threading.Tasks;

namespace FashionApp.Services.Concrete
{
    public class FollowManager : IFollowService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FollowManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<FollowDto>> Add(FollowAddDto followAddDto)
        {
            var isUser = await _unitOfWork.ApplicationUsers.AnyAsync(u => u.Id == followAddDto.UserId);
            if (!isUser)
            {
                return new DataResult<FollowDto>(ResultStatus.Error, "Böyle bir kullanıcı bulunamadı !", new FollowDto
                {
                    Follow = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "Böyle bir kullanıcı bulunamadı !",
                    IsSuccessful = false
                });
            }

            var isFollowedUser = await _unitOfWork.ApplicationUsers.AnyAsync(u => u.Id == followAddDto.FollowedId);
            if (!isFollowedUser)
            {
                return new DataResult<FollowDto>(ResultStatus.Error, "Takip edilecek kullanıcı bulunamadı !", new FollowDto
                {
                    Follow = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "Takip edilecek kullanıcı bulunamadı !",
                    IsSuccessful = false
                });
            }

            var isFollowed = await _unitOfWork.Follows.AnyAsync(b => b.FollowedId == followAddDto.FollowedId);
            if (isFollowed)
            {
                return new DataResult<FollowDto>(ResultStatus.Error, "Bu kullanıcı daha önceden takip edildi !", new FollowDto
                {
                    Follow = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "Bu kullanıcı daha önceden takip edildi !",
                    IsSuccessful = true
                });
            }

            //mapping
            var follow = _mapper.Map<Follow>(followAddDto);
            var addedfollowed = await _unitOfWork.Follows.AddAsync(follow);
            await _unitOfWork.SaveAsync();

            return new DataResult<FollowDto>(ResultStatus.Succes, "Kullanıcı başarıyla takip edildi !", new FollowDto
            {
                Follow = addedfollowed,
                ResultStatus = ResultStatus.Succes,
                Message = "Kullanıcı başarıyla takip edildi !",
                IsSuccessful = true

            });
        }

        public async Task<IDataResult<FollowListDto>> GetAll(int userId)
        {
            var follows = await _unitOfWork.Follows.GetAllAsync(f => f.UserId == userId && f.IsActive == true, f => f.ApplicationUser);
            if (follows.Count > -1)
            {
                return new DataResult<FollowListDto>(ResultStatus.Succes, new FollowListDto
                {
                    Follows = follows,
                    ResultStatus = ResultStatus.Succes,
                    IsSuccessful = true
                });
            }
            return new DataResult<FollowListDto>(ResultStatus.Error, "Böyle bir kullanıcı bilgisi bulunamadı !", new FollowListDto
            {
                Follows = null,
                ResultStatus = ResultStatus.Error,
                Message = "Böyle bir kullanıcı bilgisi bulunamadı !",
                IsSuccessful = true
            });
        }

        public async Task<IDataResult<FollowDto>> Update(FollowUpdateDto followUpdateDto)
        {
            var isUser = await _unitOfWork.ApplicationUsers.AnyAsync(u => u.Id == followUpdateDto.UserId);
            if (!isUser)
            {
                return new DataResult<FollowDto>(ResultStatus.Error, "Böyle bir kullanıcı bulunamadı !", new FollowDto
                {
                    Follow = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "Böyle bir kullanıcı bulunamadı !",
                    IsSuccessful = false
                });
            }

            var isFollowedUser = await _unitOfWork.ApplicationUsers.AnyAsync(u => u.Id == followUpdateDto.FollowedId);
            if (!isFollowedUser)
            {
                return new DataResult<FollowDto>(ResultStatus.Error, "Takip edilecek kullanıcı bulunamadı !", new FollowDto
                {
                    Follow = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "Takip edilecek kullanıcı bulunamadı !",
                    IsSuccessful = false
                });
            }

            var oldFollow = await _unitOfWork.Follows.GetAsync(b => b.Id == followUpdateDto.Id && b.IsActive == true);
            if (oldFollow == null)
            {
                return new DataResult<FollowDto>(ResultStatus.Error, "Böyle bir kullanıcı bilgisi bulunamadı !", new FollowDto
                {
                    Follow = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "Böyle bir kullanıcı bilgisi bulunamadı !",
                    IsSuccessful = true
                });
            }

            var followed = _mapper.Map<FollowUpdateDto, Follow>(followUpdateDto, oldFollow);
            followed.ModifiedDate = DateTime.Now;
            followed.IsActive = false;
            var updatedFollow = await _unitOfWork.Follows.UpdateAsync(followed);
            await _unitOfWork.SaveAsync();

            return new DataResult<FollowDto>(ResultStatus.Succes, "Kullanıcı takibi kaldırılmıştır !", new FollowDto
            {
                Follow = updatedFollow,
                ResultStatus = ResultStatus.Succes,
                Message = "Kullanıcı takibi kaldırılmıştır !",
                IsSuccessful = true

            });


        }
    }
}
