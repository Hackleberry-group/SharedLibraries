namespace HackleberrySharedModels.DTOs.Questions;

public record AiGeneratedQuestionsDto
{
	public IEnumerable<BaseQuestionDto> Questions { get; init; }
}
