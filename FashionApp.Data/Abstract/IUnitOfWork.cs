using System;
using System.Threading.Tasks;

namespace FashionApp.Data.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IApplicationUserRepository ApplicationUsers { get; }
        IBlockedRepository Blockeds { get; }
        IFollowRepository Follows { get; }
        IMessageRepository Messages { get; }
        IGenericInfoRepository GenericInfos { get; }
        IPrivateInfoRepository PrivateInfos { get; }
        IPostRepository Posts { get; }
        ILikeRepository Likes { get; }
        ICommentRepository Comments { get; }
        IFullyCombineRepository FullyCombines { get; }
        IImageRepository Images { get; }
        ITagRepository Tags { get; }
        IBodySizeRepository BodySizes { get; }
        IColorRepository Colors { get; }
        Task<int> SaveAsync();
    }
}
