using Azure;
using Azure.Data.Tables;

namespace HackleberryModels.Responses
{
    public class LevelResponse
    {
        public int LevelNumber { get; set; }
        public int RequiredXP { get; set; }
    }
}
