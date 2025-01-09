using System.Net.Http;

namespace HackleberrySharedModels.IInterserviceHttpCalls;

public interface IInterserviceHttpCall
{
    public string ServiceUrl { get; set; }
    // Hidden Only get the Configured one 
    public HttpClient _httpClient { get; set; }


    public HttpClient GetConfiguredClient();
}