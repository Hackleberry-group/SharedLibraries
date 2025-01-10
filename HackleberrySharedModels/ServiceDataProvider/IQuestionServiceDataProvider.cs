using HackleberrySharedModels.DTOs.Questions;

namespace HackleberrySharedModels.ServiceDataProviders;

public interface IQuestionServiceDataProvider
{
    IEnumerable<BaseQuestionDto> GetQuestionsOfExercise(Guid exerciseId);
}