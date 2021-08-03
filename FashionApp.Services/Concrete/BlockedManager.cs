using AutoMapper;
using FashionApp.Data.Abstract;
using FashionApp.Entities.Concrete;
using FashionApp.Entities.Dtos.Blockeds;
using FashionApp.Services.Abstract;
using FashionApp.Shared.Utilities.Result.Abstract;
using FashionApp.Shared.Utilities.Result.ComplexTypes;
using FashionApp.Shared.Utilities.Result.Concrete;
using System;
using System.Threading.Tasks;

namespace FashionApp.Services.Concrete
{
    public class BlockedManager : IBlockedService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BlockedManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<BlockedDto>> Add(BlockedAddDto blockedAddDto)
        {
            var isUser = await _unitOfWork.ApplicationUsers.AnyAsync(u => u.Id == blockedAddDto.UserId);
            if (!isUser)
            {
                return new DataResult<BlockedDto>(ResultStatus.Error, "Böyle bir kullanıcı bulunamadı !", new BlockedDto
                {
                    Blocked = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "Böyle bir kullanıcı bulunamadı !",
                    IsSuccessful = false
                });
            }

            var isBlockedUser = await _unitOfWork.ApplicationUsers.AnyAsync(u => u.Id == blockedAddDto.BlockedId);
            if (!isBlockedUser)
            {
                return new DataResult<BlockedDto>(ResultStatus.Error, "Engellenecek kullanıcı bulunamadı !", new BlockedDto
                {
                    Blocked = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "Engellenecek kullanıcı bulunamadı !",
                    IsSuccessful = false
                });
            }

            var isBlocked = await _unitOfWork.Blockeds.AnyAsync(b => b.BlockedId == blockedAddDto.BlockedId);
            if (isBlocked)
            {
                return new DataResult<BlockedDto>(ResultStatus.Error, "Kullanıcıyı bir daha engelleyemezsin !", new BlockedDto
                {
                    Blocked = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "Kullanıcıyı bir daha engelleyemezsin !",
                    IsSuccessful = false
                });
            }

            var blocked = _mapper.Map<Blocked>(blockedAddDto);
            var addedblocked = await _unitOfWork.Blockeds.AddAsync(blocked);
            await _unitOfWork.SaveAsync();
            return new DataResult<BlockedDto>(ResultStatus.Succes, "Kullanıcı başarıyla engellenmiştir !", new BlockedDto
            {
                Blocked = addedblocked,
                ResultStatus = ResultStatus.Succes,
                Message = "Kullanıcı başarıyla engellenmiştir !",
                IsSuccessful = true

            });






        }

        public async Task<IDataResult<BlockedListDto>> GetAll(int userId)
        {
            var blockeds = await _unitOfWork.Blockeds.GetAllAsync(b => b.UserId == userId && b.IsActive == true, b => b.ApplicationUser);
            if (blockeds.Count > -1)
            {
                return new DataResult<BlockedListDto>(ResultStatus.Succes, new BlockedListDto
                {
                    Blockeds = blockeds,
                    ResultStatus = ResultStatus.Succes,
                    IsSuccessful = true
                });
            }
            return new DataResult<BlockedListDto>(ResultStatus.Error, "Böyle bir kullanıcı bilgisi bulunamadı !", new BlockedListDto
            {
                Blockeds = null,
                ResultStatus = ResultStatus.Error,
                Message = "Böyle bir kullanıcı bilgisi bulunamadı !",
                IsSuccessful = true
            });
        }

        public async Task<IDataResult<BlockedDto>> Update(BlockedUpdateDto blockedUpdateDto)
        {
            var isUser = await _unitOfWork.ApplicationUsers.AnyAsync(u => u.Id == blockedUpdateDto.UserId);
            if (!isUser)
            {
                return new DataResult<BlockedDto>(ResultStatus.Error, "Böyle bir kullanıcı bulunamadı !", new BlockedDto
                {
                    Blocked = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "Böyle bir kullanıcı bulunamadı !",
                    IsSuccessful = false
                });
            }

            var isBlockedUser = await _unitOfWork.ApplicationUsers.AnyAsync(u => u.Id == blockedUpdateDto.BlockedId);
            if (!isBlockedUser)
            {
                return new DataResult<BlockedDto>(ResultStatus.Error, "Engellenecek kullanıcı bulunamadı !", new BlockedDto
                {
                    Blocked = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "Engellenecek kullanıcı bulunamadı !",
                    IsSuccessful = false
                });
            }

            var oldBlocked = await _unitOfWork.Blockeds.GetAsync(b => b.Id == blockedUpdateDto.Id && b.IsActive == true);
            if (oldBlocked == null)
            {
                return new DataResult<BlockedDto>(ResultStatus.Error, "Böyle bir kullanıcı bilgisi bulunamadı !", new BlockedDto
                {
                    Blocked = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "Böyle bir kullanıcı bilgisi bulunamadı !",
                    IsSuccessful = true
                });
            }

            var blocked = _mapper.Map<BlockedUpdateDto, Blocked>(blockedUpdateDto, oldBlocked);
            blocked.ModifiedDate = DateTime.Now;
            blocked.IsActive = false;
            var updatedBlocked = await _unitOfWork.Blockeds.UpdateAsync(blocked);
            await _unitOfWork.SaveAsync();

            return new DataResult<BlockedDto>(ResultStatus.Succes, "Kullanıcı engeli kaldırılmıştır !", new BlockedDto
            {
                Blocked = updatedBlocked,
                ResultStatus = ResultStatus.Succes,
                Message = "Kullanıcı engeli kaldırılmıştır !",
                IsSuccessful = true

            });


        }
    }
}
