using HackleberrySharedModels.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

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

        var errorResponse = new ErrorResponse();

        switch (exception)
        {
            case ValidationException validationException:
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                errorResponse.Message = "Validation failed";
                break;

            case UnauthorizedAccessException:
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                errorResponse.Message = "Unauthorized access";
                break;

            case InvalidOperationException invalidOpException:
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                errorResponse.Message = invalidOpException.Message ?? "Invalid operation requested.";
                break;

            case NotFoundException notFoundException:
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                errorResponse.Message = notFoundException.Message ?? "Resource not found.";
                break;

            case AlreadyExistsException alreadyExistsException:
                context.Response.StatusCode = StatusCodes.Status409Conflict;
                errorResponse.Message = alreadyExistsException.Message ?? "Resource already exists.";
                break;

            case ForbiddenException forbiddenException:
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                errorResponse.Message = forbiddenException.Message ?? "Forbidden access.";
                break;

            case BadRequestException badRequestException:
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                errorResponse.Message = badRequestException.Message ?? "Bad request.";
                break;

            case InternalErrorException internalErrorException:
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                errorResponse.Message = internalErrorException.Message ?? "Internal server error.";
                break;

            default:
                _logger.LogError(exception, "An unexpected error occurred");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                errorResponse.Message = "An internal server error occurred";
                break;
        }

        await context.Response.WriteAsJsonAsync(errorResponse);
    }
}