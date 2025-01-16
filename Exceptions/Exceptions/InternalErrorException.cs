using System.Net;

namespace HackleberrySharedModels.Exceptions
{
    public class InternalErrorException : ApiException
    {
        public override HttpStatusCode StatusCode { get; protected set; } = HttpStatusCode.InternalServerError;
        public Guid TraceId { get; set; }

        public InternalErrorException()
        {
            TraceId = Guid.NewGuid();
        }

        public InternalErrorException(string message) : base(message)
        {
            TraceId = Guid.NewGuid();
        }

        public InternalErrorException(string message, Exception innerException) : base(message, innerException)
        {
            TraceId = Guid.NewGuid();
        }
    }
}