using System.Net;

namespace HackleberrySharedModels.Exceptions
{
    public class AlreadyExistsException : ApiException
    {
        public override HttpStatusCode StatusCode { get; protected set; } = HttpStatusCode.Conflict;

        public AlreadyExistsException()
        {
        }

        public AlreadyExistsException(string message) : base(message)
        {
        }

        public AlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}