using FashionApp.Data.Abstract;
using FashionApp.Data.Concrete.EntityFramework.Context;
using FashionApp.Data.Concrete.EntityFramework.Repositories;
using System.Threading.Tasks;

namespace FashionApp.Data.Concrete.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FashionAppContext _context;

#pragma warning disable CS0649 // Field 'UnitOfWork._efApplicationUserRepository' is never assigned to, and will always have its default value null
        private EfApplicationUserRepository _efApplicationUserRepository;
#pragma warning restore CS0649 // Field 'UnitOfWork._efApplicationUserRepository' is never assigned to, and will always have its default value null
#pragma warning disable CS0649 // Field 'UnitOfWork._efBlockedRepository' is never assigned to, and will always have its default value null
        private EfBlockedRepository _efBlockedRepository;
#pragma warning restore CS0649 // Field 'UnitOfWork._efBlockedRepository' is never assigned to, and will always have its default value null
#pragma warning disable CS0649 // Field 'UnitOfWork._efFollowRepository' is never assigned to, and will always have its default value null
        private EfFollowRepository _efFollowRepository;
#pragma warning restore CS0649 // Field 'UnitOfWork._efFollowRepository' is never assigned to, and will always have its default value null
#pragma warning disable CS0649 // Field 'UnitOfWork._efmessageRepository' is never assigned to, and will always have its default value null
        private EfMessageRepository _efmessageRepository;
#pragma warning restore CS0649 // Field 'UnitOfWork._efmessageRepository' is never assigned to, and will always have its default value null
#pragma warning disable CS0649 // Field 'UnitOfWork._efGenericInfoRepository' is never assigned to, and will always have its default value null
        private EfGenericInfoRepository _efGenericInfoRepository;
#pragma warning restore CS0649 // Field 'UnitOfWork._efGenericInfoRepository' is never assigned to, and will always have its default value null
#pragma warning disable CS0649 // Field 'UnitOfWork._efPrivateInfoRepository' is never assigned to, and will always have its default value null
        private EfPrivateInfoRepository _efPrivateInfoRepository;
#pragma warning restore CS0649 // Field 'UnitOfWork._efPrivateInfoRepository' is never assigned to, and will always have its default value null
#pragma warning disable CS0649 // Field 'UnitOfWork._efPostRepository' is never assigned to, and will always have its default value null
        private EfPostRepository _efPostRepository;
#pragma warning restore CS0649 // Field 'UnitOfWork._efPostRepository' is never assigned to, and will always have its default value null
#pragma warning disable CS0649 // Field 'UnitOfWork._efLikeRepository' is never assigned to, and will always have its default value null
        private EfLikeRepository _efLikeRepository;
#pragma warning restore CS0649 // Field 'UnitOfWork._efLikeRepository' is never assigned to, and will always have its default value null
#pragma warning disable CS0649 // Field 'UnitOfWork._efCommentRepository' is never assigned to, and will always have its default value null
        private EfCommentRepository _efCommentRepository;
#pragma warning restore CS0649 // Field 'UnitOfWork._efCommentRepository' is never assigned to, and will always have its default value null
#pragma warning disable CS0649 // Field 'UnitOfWork._efFullyCombineRepository' is never assigned to, and will always have its default value null
        private EfFullyCombineRepository _efFullyCombineRepository;
#pragma warning restore CS0649 // Field 'UnitOfWork._efFullyCombineRepository' is never assigned to, and will always have its default value null
#pragma warning disable CS0649 // Field 'UnitOfWork._efImageRepository' is never assigned to, and will always have its default value null
        private EfImageRepository _efImageRepository;
#pragma warning restore CS0649 // Field 'UnitOfWork._efImageRepository' is never assigned to, and will always have its default value null
#pragma warning disable CS0649 // Field 'UnitOfWork._efTagRepository' is never assigned to, and will always have its default value null
        private EfTagRepository _efTagRepository;
#pragma warning restore CS0649 // Field 'UnitOfWork._efTagRepository' is never assigned to, and will always have its default value null
#pragma warning disable CS0649 // Field 'UnitOfWork._efBodySizeRepository' is never assigned to, and will always have its default value null
        private EfBodySizeRepository _efBodySizeRepository;
#pragma warning restore CS0649 // Field 'UnitOfWork._efBodySizeRepository' is never assigned to, and will always have its default value null
#pragma warning disable CS0649 // Field 'UnitOfWork._efColorRepository' is never assigned to, and will always have its default value null
        private EfColorRepository _efColorRepository;
#pragma warning restore CS0649 // Field 'UnitOfWork._efColorRepository' is never assigned to, and will always have its default value null
        public UnitOfWork(FashionAppContext context)
        {
            _context = context;
        }
        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public IApplicationUserRepository ApplicationUsers => _efApplicationUserRepository ?? new EfApplicationUserRepository(_context);

        public IBlockedRepository Blockeds => _efBlockedRepository ?? new EfBlockedRepository(_context);

        public IFollowRepository Follows => _efFollowRepository ?? new EfFollowRepository(_context);

        public IMessageRepository Messages => _efmessageRepository ?? new EfMessageRepository(_context);

        public IGenericInfoRepository GenericInfos => _efGenericInfoRepository ?? new EfGenericInfoRepository(_context);

        public IPrivateInfoRepository PrivateInfos => _efPrivateInfoRepository ?? new EfPrivateInfoRepository(_context);

        public IPostRepository Posts => _efPostRepository ?? new EfPostRepository(_context);

        public ILikeRepository Likes => _efLikeRepository ?? new EfLikeRepository(_context);

        public ICommentRepository Comments => _efCommentRepository ?? new EfCommentRepository(_context);

        public IFullyCombineRepository FullyCombines => _efFullyCombineRepository ?? new EfFullyCombineRepository(_context);

        public IImageRepository Images => _efImageRepository ?? new EfImageRepository(_context);

        public ITagRepository Tags => _efTagRepository ?? new EfTagRepository(_context);

        public IBodySizeRepository BodySizes => _efBodySizeRepository ?? new EfBodySizeRepository(_context);

        public IColorRepository Colors => _efColorRepository ?? new EfColorRepository(_context);

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
