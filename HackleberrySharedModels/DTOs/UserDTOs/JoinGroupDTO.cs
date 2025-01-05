using System.ComponentModel.DataAnnotations;

namespace HackleberrySharedModels.DTOs.UserDTOs;

public class JoinGroupDTO
{ 
    [Required(ErrorMessage = "Join code is required.")]
    [StringLength(4, ErrorMessage = "Join code must be 4 characters long.")]
    public string JoinCode { get; set; }

}