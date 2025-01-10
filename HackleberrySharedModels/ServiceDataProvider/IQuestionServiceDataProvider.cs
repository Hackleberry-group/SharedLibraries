using HackelberrySharedModels.Dtos.Questions;

namespace HackleberrySharedModels.ServiceDataProviders;

public class IQuestionServiceDataProvider
{
    Task<IEnumerable<BaseQuestionDto>> GetQuestionsOfExerciseAsync(Guid exerciseId);
}