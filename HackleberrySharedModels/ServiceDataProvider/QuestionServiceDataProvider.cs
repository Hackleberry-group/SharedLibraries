using HackelberrySharedModels.Dtos.Questions;


namespace HackleberrySharedModels.ServiceDataProviders;

public class QuestionServiceDataProvider : IQuestionServiceDataProvider
{
    private readonly string _baseUrl;
    private const string _questionsEndpoint = "/questions";
    // TODO Does josh means like this ?
    private readonly IInterServiceClient _interServiceClient;
    
    // Or Configure here for all the question stuff ?
    public QuestionServiceDataProvider(string baseUrl, IInterServiceClient interServiceClient)
    {
        _baseUrl = baseUrl;
        _interServiceClient = interServiceClient;
    }
    
    public Task<IEnumerable<BaseQuestionDto>> GetQuestionsOfExerciseAsync(Guid exerciseId)
    {
        
        throw new NotImplementedException();
    }
    
}