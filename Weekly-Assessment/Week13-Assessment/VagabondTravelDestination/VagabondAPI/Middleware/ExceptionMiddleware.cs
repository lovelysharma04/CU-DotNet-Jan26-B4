using System.Net;
using System.Text.Json;
using VagabondAPI.Exceptions;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (DestinationNotFoundException ex)
        {
            await HandleException(context, ex.Message, HttpStatusCode.NotFound);
        }
        catch (Exception ex)
        {
            await HandleException(context, ex.Message, HttpStatusCode.InternalServerError);
        }
    }

    private static Task HandleException(HttpContext context, string message, HttpStatusCode status)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)status;

        var result = JsonSerializer.Serialize(new
        {
            StatusCode = context.Response.StatusCode,
            Message = message
        });

        return context.Response.WriteAsync(result);
    }
}