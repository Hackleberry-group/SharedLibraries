using System.Collections.Generic;
using System.Text.Json.Serialization;
using HackleberrySharedModels.DTOs.Questions;
using HackleberrySharedModels.Enums;

namespace HackleberrySharedModels.Config.JsonConverters
{
    public static class JsonConvertorProvider
    {
        public static IEnumerable<JsonConverter> GetAllConvertorsForQuestionJson()
        {
            return new HashSet<JsonConverter>
            {
                new JsonStringEnumConverter(),
                new AnswerOptionDtoConvertor(),
                new BaseQuestionDtoConvertor()
            };
        }
    }
}