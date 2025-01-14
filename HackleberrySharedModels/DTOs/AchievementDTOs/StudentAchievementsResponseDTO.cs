using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackleberryModels.DTOs.AchievementDTOs
{
    public record StudentAchievementsResponseDTO
    {
        public Guid StudentId { get; set; }
        public List<AchievementDetailsDTO> Achievements { get; set; } = new();
    }
}
