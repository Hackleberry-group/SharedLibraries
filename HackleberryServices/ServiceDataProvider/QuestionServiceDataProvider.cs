using HackleberrySharedModels.DTOs.Questions;
using System.Text.Json;

namespace HackleberryServices.Services.ServiceDataProviders;

public class QuestionServiceDataProvider : IQuestionServiceDataProvider
{
    private const string _questionsEndpoint = "/questions";
    private readonly HttpClient _client; 
    private readonly JsonSerializerOptions _options; 


    public QuestionServiceDataProvider(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions)
    {
        _client = httpClient;
        _options = jsonSerializerOptions;
    }
    
    public IEnumerable<BaseQuestionDto> GetQuestionsOfExercise(Guid exerciseId)
    {
        try
        {
            var response = _client.GetAsync($"{_questionsEndpoint}?{nameof(exerciseId)}={exerciseId}").Result;
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<IEnumerable<BaseQuestionDto>>(content, _options);
        }
        catch (Exception e)
        {
            // Log the error
            throw;
        }
    }
    
}