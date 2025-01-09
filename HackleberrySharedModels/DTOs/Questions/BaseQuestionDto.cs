using System.ComponentModel.DataAnnotations;
using HackleberrySharedModels.DTOs.Answers;
using HackleberrySharedModels.DTOs.Questions.Interface;
using HackleberrySharedModels.Enums;

namespace HackleberrySharedModels.DTOs.Questions;

public record BaseQuestionDto : IValidatableQuestion
{
    public Guid Id { get; set; }
    public string? Explanation { get; init; }
    [Required] public QuestionTypesEnum QuestionType { get; init; }
    public IEnumerable<AnswerOptionDto> AnswerOptions { get; set; } = new HashSet<AnswerOptionDto>();
    [Required] public Guid ExerciseId { get; init; }


    public virtual IEnumerable<ValidationResult> ValidateQuestion(ValidationContext validationContext)
    {
        if (!AnswerOptions.Any())
        {
            yield return new ValidationResult($"{GetNameOfQuestionType()} must have at least one answer option",
                [nameof(AnswerOptions)]);
        }
    }


    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var validationResults = ValidateQuestion(validationContext);

        foreach (var validationResult in validationResults)
        {
            yield return validationResult;
        }
    }
    
    protected string GetNameOfQuestionType()
    {
        return QuestionType + " Question";
    }
}