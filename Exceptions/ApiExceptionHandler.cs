
using System.Net.Http.Json;
using System.Text.Json;
using System.Web.Http.ExceptionHandling;
using HackleberrySharedModels.Exceptions;

namespace HackleberrySharedModels.Middleware
{
    public class ApiExceptionHandler : IExceptionHandler
    {
        public async Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            var exception = context.Exception;
            var response = context.ExceptionContext.Response;

            if (exception is not ApiException apiException)
            {
                return;
            }

            response.StatusCode = apiException.StatusCode;

            var result = JsonSerializer.Serialize(new
            {
                error = exception.Message ?? exception.GetType().Name,
            });


            if (apiException is InternalErrorException)
            {
                // Todo: Replace with a logger or something else
                Console.WriteLine("There was an internal error.");
                Console.WriteLine(exception.StackTrace);
            }

            response.Content = JsonContent.Create(result);
        }
    }
}