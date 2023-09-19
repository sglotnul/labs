using System.ComponentModel.DataAnnotations;
using System.Net;

namespace WebApplication1;

public static class WebApplicationExtensions
{
    public static IApplicationBuilder UseCustomExceptionHandling(this WebApplication builder)
    {
        return builder.Use(async (context, next) =>
        {
            try
            {
                await next.Invoke();
            }
            catch (ValidationException e)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync(GetHtmlResponse(e.Message));
            }
            catch (Exception e)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync(GetHtmlResponse(e.Message));
            }
        });
    }

    private static string GetHtmlResponse(string message)
    {
        return $"""
        <html>
            <meta charset="utf-8">
            <body>
                <h1>{message}</h1>
            </body>
        </html>
        """;
    }
}