namespace HackleberryModels.DTOs.ProgressionServiceDTOs
{
    public record LevelResponseDTO
    {
        public int LevelNumber { get; set; }
        public int RequiredXP { get; set; }
    }
}
