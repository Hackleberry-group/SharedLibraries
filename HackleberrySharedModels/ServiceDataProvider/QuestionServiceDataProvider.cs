using HackleberrySharedModels.DTOs.Questions;
using HackleberrySharedModels.IInterserviceHttpCalls;

namespace HackleberrySharedModels.ServiceDataProviders;

public class QuestionServiceDataProvider : IQuestionServiceDataProvider
{
    private readonly string _baseUrl;
    private const string _questionsEndpoint = "/questions";
    // TODO Does josh means like this ?
    private readonly IInterserviceHttpCall _interServiceClient;
    
    // Or Configure here for all the question stuff ?
    public QuestionServiceDataProvider(string baseUrl, IInterserviceHttpCall interServiceClient)
    {
        _baseUrl = baseUrl;
        _interServiceClient = interServiceClient;
    }
    
    public Task<IEnumerable<BaseQuestionDto>> GetQuestionsOfExerciseAsync(Guid exerciseId)
    {
        
        throw new NotImplementedException();
    }
    
}