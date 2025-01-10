using System.ComponentModel.DataAnnotations;

namespace HackleberrySharedModels.DTOs.Answers.Interface;

public interface IValidateAnswerOption : IValidatableObject
{
    IEnumerable<ValidationResult> ValidateAnswerOption(ValidationContext validationContext);
}