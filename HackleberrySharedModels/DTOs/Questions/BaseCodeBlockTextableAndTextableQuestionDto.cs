namespace HackleberrySharedModels.DTOs.Questions;

public record BaseCodeBlockTextableAndTextableQuestionDto :BaseCodeBlockTextableQuestionDto
{
    public string QuestionText { get; init; } 
}