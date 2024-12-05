using System.Net;

namespace HackleberrySharedModels.Exceptions
{
    public class UnauthorizedException : ApiException
    {
        public override HttpStatusCode StatusCode { get; protected set; } = HttpStatusCode.Unauthorized;
    }
}
