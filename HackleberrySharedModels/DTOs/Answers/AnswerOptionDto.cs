using System.ComponentModel.DataAnnotations;
using HackleberrySharedModels.DTOs.Answers.Interface;
using HackleberrySharedModels.Enums;

namespace HackleberrySharedModels.DTOs.Answers;

public record AnswerOptionDto : IValidateAnswerOption
{
    public Guid Id { get; set; }
    [Required] public string Text { get; init; }
    public string? CodeBlockFinder { get; init; }
    public AnswerOptionTypeEnum AnswerType { get; init; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        return ValidateAnswerOption(validationContext);
    }

    public virtual IEnumerable<ValidationResult> ValidateAnswerOption(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();
        if (string.IsNullOrWhiteSpace(Text))
        {
            results.Add(new ValidationResult($"{nameof(Text)} is required", new[] { nameof(Text) }));
        }

        return results;
    }
}