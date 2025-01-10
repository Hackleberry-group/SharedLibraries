using System.Net.Http;

namespace HackleberrySharedModels.IInterserviceHttpCalls;

public class InterServiceHttpCall : IInterserviceHttpCall
{
    public string ServiceUrl { get; set; }
    // Hidden Only get the Configured one 
    public HttpClient _httpClient { get; set; }


    public InterServiceHttpCall(string serviceUrl, IHttpClientFactory httpClientFactory)
    {
        ServiceUrl = serviceUrl;
        var client = httpClientFactory.CreateClient();
        client.BaseAddress = new Uri(ServiceUrl);
        _httpClient = client;
    }


    public virtual HttpClient GetConfiguredClient()
    {
        // TODO: Set Up the Http Client 
        return _httpClient;
    }
    
    //TODO: Use Builder Pattern to Cofigure the client 
}