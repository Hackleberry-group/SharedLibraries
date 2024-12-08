using System.Net;

namespace HackleberrySharedModels.Exceptions
{
    public class NotFoundException : ApiException
    {
        public override HttpStatusCode StatusCode { get; protected set; } = HttpStatusCode.NotFound;
        
        public NotFoundException()
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}