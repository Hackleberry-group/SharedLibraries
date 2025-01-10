namespace HackleberryModels.DTOs.ProgressionServiceDTOs
{
    public record LevelRequest
    {
        public int LevelNumber { get; set; }
        public int RequiredXP { get; set; }
    }
}