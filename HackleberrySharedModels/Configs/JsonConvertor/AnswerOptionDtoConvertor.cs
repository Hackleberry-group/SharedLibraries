using System.Text.Json;
using System.Text.Json.Serialization;
using HackleberrySharedModels.DTOs.Answers;
using HackleberrySharedModels.Enums;
using HackleberrySharedModels.Config.CustomExtensions;

namespace HackleberrySharedModels.Config.JsonConverters;

public class AnswerOptionDtoConvertor : JsonConverter<AnswerOptionDto>
{
    public override AnswerOptionDto Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDoc = JsonDocument.ParseValue(ref reader);
        var rootElement = jsonDoc.RootElement;
        if (!rootElement.TryGetProperty("AnswerType", out var answerTypeProperty,
                StringComparison.OrdinalIgnoreCase))
        {
            throw new JsonException("Missing AnswerType property");
        }

        var answerTypeString = answerTypeProperty.GetString();
        if (answerTypeString == null)
        {
            throw new JsonException("AnswerType property is null");
        }

        var answerType = (AnswerOptionTypeEnum)Enum.Parse(typeof(AnswerOptionTypeEnum), answerTypeString, true);

        return answerType switch
        {
            AnswerOptionTypeEnum.MatchingAnswerOption => JsonSerializer.Deserialize<MatchingAnswerOptionDto>(
                rootElement.GetRawText(), options),
            AnswerOptionTypeEnum.MultipleChoiceAnswerOption => JsonSerializer
                .Deserialize<MultipleChoiceAnswerOptionDto>(
                    rootElement.GetRawText(), options),
            AnswerOptionTypeEnum.CreateMatchingAnswerOption => JsonSerializer
                .Deserialize<CreateMatchingAnswerOptionDto>(
                    rootElement.GetRawText(), options),
            _ => throw new JsonException($"Invalid AnswerTypeName value: {answerTypeString}")
        };
    }

    public override void Write(Utf8JsonWriter writer, AnswerOptionDto value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}