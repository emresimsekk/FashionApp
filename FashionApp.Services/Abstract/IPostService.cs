using FashionApp.Entities.Dtos.Posts;
using FashionApp.Shared.Utilities.Result.Abstract;
using System.Threading.Tasks;

namespace FashionApp.Services.Abstract
{
    public interface IPostService
    {
        Task<IDataResult<PostListDto>> GetAll(int userId);
        Task<IDataResult<PostDto>> Add(PostAddDto postAddDto);
        Task<IDataResult<PostDto>> Get(int postId);
    }
}
