using System.Net;

namespace HackleberrySharedModels.Exceptions
{
    public class ForbiddenException : ApiException
    {
        public override HttpStatusCode StatusCode { get; protected set; } = HttpStatusCode.Forbidden;
        
        public ForbiddenException()
        {
        }

        public ForbiddenException(string message) : base(message)
        {
        }

        public ForbiddenException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}