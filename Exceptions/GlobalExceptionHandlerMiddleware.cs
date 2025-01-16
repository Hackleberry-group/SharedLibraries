using HackleberrySharedModels.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using Sentry;
using System.Web.Http.Results;
using System.Text.Json;

namespace HackleberryExceptions;

public class GlobalExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

    public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

   private async Task HandleExceptionAsync(HttpContext context, Exception exception)
{
    context.Response.ContentType = "application/json";

    ErrorResponse errorResponse;
    switch (exception)
    {
        case InternalErrorException internalErrorException:
            _logger.LogError(internalErrorException, "An internal error occurred Here");
            SentrySdk.CaptureException(internalErrorException, scope =>
            {
                scope.SetTag("exceptionKnown", true.ToString());
            });
            
            context.Response.StatusCode = (int)internalErrorException.StatusCode;
            errorResponse = new InternalServerErrorResponse
            {
                Message = internalErrorException.Message ?? "Internal server error."
            };
             break;

        case ApiException apiException:
            context.Response.StatusCode = (int)apiException.StatusCode;
            errorResponse = new ErrorResponse
            {
                Message = apiException.Message
            };
            break;

        case ValidationException validationException:
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            errorResponse = new ErrorResponse
            {
                Message = "Validation failed"
            };
            break;

        case InvalidOperationException invalidOpException:
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            errorResponse = new ErrorResponse
            {
                Message = invalidOpException.Message ?? "Invalid operation requested."
            };
            break;

        default:
            SentrySdk.CaptureException(exception, scope =>
            {
                // This tag will help us to filter out the exceptions that are known
                scope.SetTag("exceptionKnown", false.ToString());
            });
            _logger.LogError(exception, "An unexpected error occurred");
            errorResponse = new InternalServerErrorResponse
            {
                Message = "An internal server error occurred that couldn't be handled."
            };
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            break;
    }

    var options = new JsonSerializerOptions
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };
    
    if(errorResponse is InternalServerErrorResponse internalServerErrorResponse)
    {
        internalServerErrorResponse.TraceId = SentrySdk.LastEventId.ToString();
    }

    await context.Response.WriteAsJsonAsync(errorResponse, errorResponse.GetType(), options);
}
}