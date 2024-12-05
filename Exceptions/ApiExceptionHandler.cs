using System.Web.Http.ExceptionHandling;

namespace HackleberrySharedModels.Middleware
{
    public class ApiExceptionHandler : IExceptionHandler
    {
        public Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
