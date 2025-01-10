using HackleberrySharedModels.DTOs.Questions;
using HackleberrySharedModels.IInterserviceHttpCalls;

namespace HackleberrySharedModels.ServiceDataProviders;

public class QuestionServiceDataProvider : IQuestionServiceDataProvider
{
    private const string _questionsEndpoint = "/questions";
    // TODO Does josh means like this ?
    private readonly IInterserviceHttpCall _interServiceClient;

    private HttpClient client => _interServiceClient.GetConfiguredClient();

    // Or Configure here for all the question stuff ?
    public QuestionServiceDataProvider(string serviceUrl, IHttpClientFactory httpClientFactory)
    {
        var questionServiceUrl = Uri(new Uri(serviceUrl), _questionsEndpoint);
        _interServiceClient = new InterServiceHttpCall(questionServiceUrl.ToString(), httpClientFactory);
    }
    
    public IEnumerable<BaseQuestionDto> GetQuestionsOfExercise(Guid exerciseId)
    {
        try
        {
            var response = client.GetAsync($"{nameof(exerciseId)}={exerciseId}").Result;
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<IEnumerable<BaseQuestionDto>>(content);
        }
        catch (Exception e)
        {
            // Log the error
            throw;
        }
    }
    
}