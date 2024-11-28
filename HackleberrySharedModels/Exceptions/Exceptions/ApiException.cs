using System.Net;

namespace HackleberrySharedModels.Exceptions
{
    public abstract class ApiException : Exception
    {
        public abstract HttpStatusCode StatusCode { get; protected set; }
    }
}
