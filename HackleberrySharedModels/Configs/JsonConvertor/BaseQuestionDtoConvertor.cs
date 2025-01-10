using System.Text.Json;
using System.Text.Json.Serialization;
using HackleberrySharedModels.DTOs.Questions;
using HackleberrySharedModels.Enums;
using HackleberrySharedModels.Config.CustomExtensions;

namespace HackleberrySharedModels.Config.JsonConverters;

public class BaseQuestionDtoConvertor : JsonConverter<BaseQuestionDto>
{
    public override BaseQuestionDto Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDoc = JsonDocument.ParseValue(ref reader);
        var rootElement = jsonDoc.RootElement;
        if (!rootElement.TryGetProperty("QuestionType", out var questionTypeProperty,
                StringComparison.OrdinalIgnoreCase))
        {
            throw new JsonException("Missing QuestionType property");
        }

        var questionTypeString = questionTypeProperty.GetString();
        if (questionTypeString == null)
        {
            throw new JsonException("QuestionType property is null");
        }

        var questionTypesEnum =
            (QuestionTypesEnum)Enum.Parse(typeof(QuestionTypesEnum), questionTypeString, true);

        return (questionTypesEnum switch
        {
            QuestionTypesEnum.MultipleChoice => JsonSerializer.Deserialize<MultipleChoiceQuestionDto>(
                rootElement.GetRawText(), options),
            QuestionTypesEnum.TrueFalse => JsonSerializer.Deserialize<TrueOrFalseQuestionDto>(
                rootElement.GetRawText(),
                options),
            QuestionTypesEnum.Dropdown => JsonSerializer.Deserialize<DropDownQuestionDto>(rootElement.GetRawText(),
                options),
            QuestionTypesEnum.Matching => JsonSerializer.Deserialize<MatchingQuestionDto>(rootElement.GetRawText(),
                options),
            QuestionTypesEnum.DragAndDrop => JsonSerializer.Deserialize<DragAndDropQuestionDto>(
                rootElement.GetRawText(),
                options),
            // Add cases for other types
            _ => throw new JsonException($"Invalid QuestionType value: {questionTypeString}")
        })!;
    }

    public override void Write(Utf8JsonWriter writer, BaseQuestionDto value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}