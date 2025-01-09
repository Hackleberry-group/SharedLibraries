using System.ComponentModel.DataAnnotations;

namespace HackleberrySharedModels.DTOs.Questions.Interface;

public interface IValidatableQuestion : IValidatableObject
{
    IEnumerable<ValidationResult> ValidateQuestion(ValidationContext validationContext);
}