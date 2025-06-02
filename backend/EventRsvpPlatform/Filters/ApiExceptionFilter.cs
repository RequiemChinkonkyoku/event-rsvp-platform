using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EventRsvpPlatform.Filters;

public class ApiExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var errorResponse = new
        {
            success = false,
            message = context.Exception.Message
        };

        context.Result = context.Exception switch
        {
            KeyNotFoundException => new NotFoundObjectResult(errorResponse),
            ArgumentException => new BadRequestObjectResult(errorResponse),
            _ => new ObjectResult(errorResponse) { StatusCode = 500 }
        };
    }
}