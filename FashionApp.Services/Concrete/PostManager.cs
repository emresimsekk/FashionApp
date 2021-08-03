using AutoMapper;
using FashionApp.Data.Abstract;
using FashionApp.Entities.Concrete;
using FashionApp.Entities.Dtos.Posts;
using FashionApp.Services.Abstract;
using FashionApp.Shared.Utilities.Result.Abstract;
using FashionApp.Shared.Utilities.Result.ComplexTypes;
using FashionApp.Shared.Utilities.Result.Concrete;
using System.Linq;
using System.Threading.Tasks;

namespace FashionApp.Services.Concrete
{
    public class PostManager : IPostService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFullyCombineService _fullyCombineService;
        private readonly IImageService _imageService;
        private readonly ITagService _tagService;

        public PostManager(IMapper mapper, IUnitOfWork unitOfWork, IFullyCombineService fullyCombineService, IImageService imageService, ITagService tagService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _fullyCombineService = fullyCombineService;
            _imageService = imageService;
            _tagService = tagService;
        }

        public async Task<IDataResult<PostDto>> Add(PostAddDto postAddDto)
        {

            var addedFullyCombine = await _fullyCombineService.Add(postAddDto.FullyCombineAddDto);

            postAddDto.FullyCombineAddDto.imageAddDto.ToList().ForEach(x =>
            {
                x.FullyCombineId = addedFullyCombine.Data.FullyCombine.Id;
            });

            var addedImage = await _imageService.AddRange(postAddDto.FullyCombineAddDto.imageAddDto);

            postAddDto.FullyCombineAddDto.tagAddDtos.ToList().ForEach(x =>
            {
                x.FullyCombineId = addedFullyCombine.Data.FullyCombine.Id;
            });

            var addedTag = await _tagService.AddRange(postAddDto.FullyCombineAddDto.tagAddDtos);

            postAddDto.FullyCombinedId = addedFullyCombine.Data.FullyCombine.Id;

            var post = _mapper.Map<Post>(postAddDto);


            var addedPost = await _unitOfWork.Posts.AddAsync(post);

            await _unitOfWork.SaveAsync();



            return new DataResult<PostDto>(ResultStatus.Succes, "Genel bilgiler başarıyla eklenmiştir !", new PostDto
            {

                ResultStatus = ResultStatus.Succes,
                Message = "Genel bilgiler başarıyla eklenmiştir !",
                IsSuccessful = true

            });
        }

        public async Task<IDataResult<PostDto>> Get(int postId)
        {
            var post = await _unitOfWork.Posts.GetAsync(p => p.Id == postId, f => f.FullyCombine, l => l.Likes, c => c.Comments, i => i.FullyCombine.Images, t => t.FullyCombine.Tags);
            var likeCount = post.Likes.Count();
            var commentCount = post.Comments.Count();
            if (post == null)
            {
                return new DataResult<PostDto>(ResultStatus.Error, "Böyle bir post bilgisi bulunamadı !", new PostDto
                {
                    Post = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "Böyle bir post bilgisi bulunamadı !",
                    IsSuccessful = true
                });
            }

            return new DataResult<PostDto>(ResultStatus.Error, new PostDto
            {
                LikeCount = likeCount,
                CommentCount = commentCount,
                Post = post,
                ResultStatus = ResultStatus.Succes,
                IsSuccessful = true
            });
        }

        public async Task<IDataResult<PostListDto>> GetAll(int userId)
        {
            var posts = await _unitOfWork.Posts.GetAllAsync(p => p.UserId == userId && p.IsActive == true, f => f.FullyCombine, i => i.FullyCombine.Images, t => t.FullyCombine.Tags);
            if (posts.Count > -1)
            {
                return new DataResult<PostListDto>(ResultStatus.Succes, new PostListDto
                {
                    Posts = posts,
                    ResultStatus = ResultStatus.Succes,
                    IsSuccessful = true
                });

            }

            return new DataResult<PostListDto>(ResultStatus.Error, "Böyle bir post bilgisi bulunamadı !", new PostListDto
            {
                Posts = null,
                ResultStatus = ResultStatus.Error,
                Message = "Böyle bir post bilgisi bulunamadı !",
                IsSuccessful = true
            });
        }
    }
}
