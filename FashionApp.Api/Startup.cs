using FashionApp.Services.AutoMapper.Profiles;
using FashionApp.Services.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNet.OData.Builder;
//using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace FashionApp.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddAutoMapper(
               typeof(GenericInfoProfile),
               typeof(PrivateInfoProfile),
               typeof(BlockedProfile),
               typeof(FollowProfile),
               typeof(PostProfile),
               typeof(FullyCombineProfile),
               typeof(ImageProfile),
               typeof(TagProfile)
               //typeof(ApplicationUserProfile)
               );

            services.AddControllersWithViews().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,options=> {
                    options.Authority = "http://localhost:1000";
                    options.Audience = "resource_FashionApp_Api";
                    options.RequireHttpsMetadata = false;
                });

            //services.AddOData();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FashionApp.Api", Version = "v1" });
            });
            services.LoadMyServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FashionApp.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            //var builder = new ODataConventionModelBuilder();
            //builder.EntitySet<GenericInfo>("GenericInfosss");


            app.UseEndpoints(endpoints =>
            {
                //endpoints.Select().Expand().OrderBy().Count().Filter();
                //endpoints.MapODataRoute("odata", "odata", builder.GetEdmModel());
                endpoints.MapControllers();
            });
        }
    }
}
