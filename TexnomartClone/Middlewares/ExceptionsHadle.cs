using Newtonsoft.Json;
using TexnomartClone.Application.Common.Exceptions;
using TexnomartClone.Application.DTOs.Common;

namespace TexnomartClone.Middlewares;

public class ExceptionsHadle(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (StatusCodeException exception)
        {
            await ClientErrorHandleAsync(context, exception);
        }
        catch (Exception exception)
        {
            await ServerErrorHandleAsync(context, exception);
        }
    }


    public async Task ServerErrorHandleAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        var result = new ErrorMessage()
        {
            Message = exception.Message,
            StatusCode = 500
        };
        context.Response.StatusCode = 500;

        await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
    }

    public async Task ClientErrorHandleAsync(HttpContext context, StatusCodeException exeption)
    {
        context.Response.ContentType = "application/json";
        var result = new ErrorMessage()
        {
            Message = exeption.Message,
            StatusCode = (int)exeption.Code,
        };
        context.Response.StatusCode = result.StatusCode;

        await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
    }
}
