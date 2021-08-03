using FashionApp.Shared.Utilities.Result.Concrete;
using FashionApp.Shared.Utilities.Result.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FashionApp.Shared.Utilities.Result.Extensions
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";

                    var error = context.Features.Get<IExceptionHandlerFeature>();
                    if (error != null)
                    {
                        var ex = error.Error;

                        ErrorDto errorDto = new ErrorDto();
                        errorDto.Status = 500;
                        errorDto.Errors.Add(ex.Message);
                        if (ex is CustomException)
                            errorDto.isShow = true;
                        else
                            errorDto.isShow = false;

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(errorDto));
                    }
                });


            });
        }
    }
}
