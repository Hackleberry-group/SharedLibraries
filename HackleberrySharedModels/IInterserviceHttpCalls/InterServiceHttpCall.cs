using System.Net.Http;

namespace HackleberrySharedModels.InterMicroserviceHttpCalls;

public class BaseServiceHttpCall : IBaseServiceHttpCall
{
    public string ServiceUrl { get; set; }
    // Hidden Only get the Configured one 
    public HttpClient _httpClient { get; set; }
    

    public virtual HttpClient GetConfiguredClient()
    {
        // TODO: Set Up the Http Client 
        return _httpClient;
    }
    
    //TODO: Use Builder Pattern to Cofigure the client 
}