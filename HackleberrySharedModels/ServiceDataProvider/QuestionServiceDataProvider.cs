using HackleberrySharedModels.DTOs.Questions;
using HackleberrySharedModels.IInterserviceHttpCalls;
using System.Text.Json;

namespace HackleberrySharedModels.ServiceDataProviders;

public class QuestionServiceDataProvider : IQuestionServiceDataProvider
{
    private const string _questionsEndpoint = "/questions";
    private readonly IInterserviceHttpCall _interServiceClient;

    private HttpClient client => _interServiceClient.GetConfiguredClient();
    private readonly JsonSerializerOptions _options; 

    // Or Configure here for all the question stuff ?
    public QuestionServiceDataProvider(string serviceUrl, IHttpClientFactory httpClientFactory, JsonSerializerOptions jsonSerializerOptions)
    {
        var questionServiceUrl = new Uri(new Uri(serviceUrl), _questionsEndpoint);
        _interServiceClient = new InterServiceHttpCall(questionServiceUrl.ToString(), httpClientFactory);
        _options = jsonSerializerOptions;
    }
    
    public IEnumerable<BaseQuestionDto> GetQuestionsOfExercise(Guid exerciseId)
    {
        try
        {
            var response = client.GetAsync($"?{nameof(exerciseId)}={exerciseId}").Result;
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            if(string.IsNullOrEmpty(content))
            {
                return Enumerable.Empty<BaseQuestionDto>();
            }
            return JsonSerializer.Deserialize<IEnumerable<BaseQuestionDto>>(content, _options);
        }
        catch (Exception e)
        {
            // Log the error
            throw;
        }
    }
    
}