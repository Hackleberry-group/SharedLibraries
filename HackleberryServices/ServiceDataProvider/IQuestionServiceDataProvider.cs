using HackleberrySharedModels.DTOs.Questions;

namespace HackleberryServices.Services.ServiceDataProviders;

public interface IQuestionServiceDataProvider
{
    IEnumerable<BaseQuestionDto> GetQuestionsOfExercise(Guid exerciseId);
}