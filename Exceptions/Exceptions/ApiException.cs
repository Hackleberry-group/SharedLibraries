using System.Net;

namespace HackleberrySharedModels.Exceptions
{
    public abstract class ApiException : Exception
    {
        public abstract HttpStatusCode StatusCode { get; protected set; }
        
        protected ApiException()
        {
        }

        protected ApiException(string message) : base(message)
        {
        }

        protected ApiException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public override string ToString()
        {
            return GetType().Name;
        }
    }
}