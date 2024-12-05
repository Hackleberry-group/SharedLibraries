using System.Net;

namespace HackleberrySharedModels.Exceptions
{
    public class InternalErrorException : ApiException
    {
        public override HttpStatusCode StatusCode { get; protected set; } = HttpStatusCode.InternalServerError;
    }
}
