using BigViewChallenge.Domain.Base;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace BigViewChallenge.Infraestructure.Exception;

public sealed class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> _logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, System.Exception exception, CancellationToken cancellationToken)
    {
        var errorMessage = exception.InnerException is not null ? exception.InnerException.Message : exception.Message;
        System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(exception, true);
        _logger.LogError(exception, string.Concat("Exception occurred: {Message}, ", $"Class: {trace.GetFrame(0).GetMethod().DeclaringType}, ", $"Line: {trace.GetFrame(0).GetFileLineNumber()}"), exception.Message);
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await httpContext.Response
        .WriteAsJsonAsync(new ResponseDTO { Success = false, Data = new { }, Error = errorMessage }, cancellationToken);
        return true;
    }
}
