using FashionApp.Data.Abstract;
using FashionApp.Data.Concrete.EntityFramework;
using FashionApp.Data.Concrete.EntityFramework.Context;
using FashionApp.Services.Abstract;
using FashionApp.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace FashionApp.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollecion)
        {
            serviceCollecion.AddDbContext<FashionAppContext>();
            serviceCollecion.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollecion.AddScoped<IGenericInfoService, GenericInfoManager>();
            serviceCollecion.AddScoped<IPrivateInfoService, PrivateInfoManager>();
            serviceCollecion.AddScoped<IBlockedService, BlockedManager>();
            serviceCollecion.AddScoped<IFollowService, FollowManager>();
            serviceCollecion.AddScoped<IPostService, PostManager>();
            serviceCollecion.AddScoped<IFullyCombineService, FullyCombineManager>();
            serviceCollecion.AddScoped<IImageService, ImageManager>();
            serviceCollecion.AddScoped<ITagService, TagManager>();
            serviceCollecion.AddScoped<ITagService, TagManager>();
            //serviceCollecion.AddScoped<IApplicationUser, ApplicationUserManager>();


            return serviceCollecion;
        }
    }
}
