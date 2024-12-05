using System.Net;

namespace HackleberrySharedModels.Exceptions
{
    public class AlreadyExistsException : ApiException
    {
        public override HttpStatusCode StatusCode { get; protected set; } = HttpStatusCode.Conflict;
    }
}
