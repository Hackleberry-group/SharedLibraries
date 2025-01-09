namespace HackleberrySharedModels.DTOs.Questions;

public record BaseTextableQuestionDto : BaseQuestionDto
{
    public string QuestionText { get; set; }
    
}