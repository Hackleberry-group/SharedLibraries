using System.Net;

namespace HackleberrySharedModels.Exceptions
{
    public class ForbiddenException : ApiException
    {
        public override HttpStatusCode StatusCode { get; protected set; } = HttpStatusCode.Forbidden;
    }
}
