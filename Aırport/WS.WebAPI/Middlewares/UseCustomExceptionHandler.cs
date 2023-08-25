using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;
using WS.Business.CustomExceptions;

namespace WS.WebAPI.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            //UseExceptionHandler  .net içindeki zaten exceptionları yakalayabilen bir 
            //middleware

            app.UseExceptionHandler(config =>
            {
                //run metodu response döndürmek için kullanılır
                config.Run(async context =>
                {
                    //aşağıdaki 2 satırla yakalanan exception tipindeki nesneyi elimize alıyoruz
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = exceptionFeature.Error;

                    var statuscode = StatusCodes.Status500InternalServerError;

                    switch (exception)
                    {
                        case BadRequestException:
                            statuscode = StatusCodes.Status400BadRequest;
                            break;
                        case NotFoundException:
                            statuscode = StatusCodes.Status404NotFound;
                            break;
                        default:
                        break;
                    }

                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = statuscode;

                    var response = ApiResponse<NoData>.Fail(statuscode, exception.Message);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}
