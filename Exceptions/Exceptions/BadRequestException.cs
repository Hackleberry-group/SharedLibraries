using System.Net;

namespace HackleberrySharedModels.Exceptions;

public class BadRequestException : ApiException
{
    public override HttpStatusCode StatusCode { get; protected set; } = HttpStatusCode.BadRequest;
        
    public BadRequestException()
    {
    }

    public BadRequestException(string message) : base(message)
    {
    }

    public BadRequestException(string message, Exception innerException) : base(message, innerException)
    {
    }
    
}