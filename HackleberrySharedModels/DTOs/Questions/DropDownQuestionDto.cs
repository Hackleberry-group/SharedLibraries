using System.ComponentModel.DataAnnotations;

namespace HackleberrySharedModels.DTOs.Questions;

public record DropDownQuestionDto : BaseCodeBlockTextableQuestionDto
{
    public override IEnumerable<ValidationResult> ValidateQuestion(ValidationContext validationContext)
    {
        foreach (var validationResult in base.ValidateQuestion(validationContext))
        {
            yield return validationResult;
        }

        if (string.IsNullOrWhiteSpace(CodeBlockText))
        {
            yield return new ValidationResult($"{GetNameOfQuestionType()} must have a code block text",
                new[] { nameof(CodeBlockText) });
        }
    }
}