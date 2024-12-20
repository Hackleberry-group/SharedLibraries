using System.Net;

namespace HackleberrySharedModels.Exceptions
{
    public class InternalErrorException : ApiException
    {
        public override HttpStatusCode StatusCode { get; protected set; } = HttpStatusCode.InternalServerError;
        
        public InternalErrorException() { }
        
        public InternalErrorException(string message) : base(message) { }

        public InternalErrorException(string message, Exception innerException) : base(message, innerException) { }
    }
}
