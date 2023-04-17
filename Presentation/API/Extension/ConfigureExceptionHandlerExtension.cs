using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace API.Extension
{
    static public class ConfigureExceptionHandlerExtension
    {
        static public void ConfigureExceptionHandler<T>(this WebApplication application, ILogger<T> logger)
        {
            application.UseExceptionHandler(options =>
            {
                options.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = MediaTypeNames.Application.Json;
                    var contextFeatures=context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeatures != null)
                    {
                        logger.LogError(contextFeatures.Error.Message);
                        await context.Response.WriteAsync(JsonSerializer.Serialize(new
                        {
                            StatusCode= context.Response.StatusCode,
                            Message=contextFeatures.Error.Message
                        }));
                    }
                });
            });
        }
    }
}
