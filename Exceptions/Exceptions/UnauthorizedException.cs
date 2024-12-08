using System.Net;

namespace HackleberrySharedModels.Exceptions
{
    public class UnauthorizedException : ApiException
    {
        public override HttpStatusCode StatusCode { get; protected set; } = HttpStatusCode.Unauthorized;

        public UnauthorizedException()
        {
        }


        public UnauthorizedException(string message) : base(message)
        {
        }

        public UnauthorizedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}