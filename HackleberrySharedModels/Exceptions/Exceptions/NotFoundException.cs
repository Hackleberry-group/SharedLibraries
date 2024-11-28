using System.Net;

namespace HackleberrySharedModels.Exceptions
{
    public class NotFoundException : ApiException
    {
        public override HttpStatusCode StatusCode { get; protected set; } = HttpStatusCode.NotFound;
    }
}
