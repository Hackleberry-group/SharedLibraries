using HackleberrySharedModels.DTOs.Questions;

namespace HackleberrySharedModels.ServiceDataProviders;

public interface IQuestionServiceDataProvider
{
    Task<IEnumerable<BaseQuestionDto>> GetQuestionsOfExerciseAsync(Guid exerciseId);
}