namespace HackleberryExceptions;

class InternalServerErrorResponse : ErrorResponse
{
	public string TraceId { get; set; }
}