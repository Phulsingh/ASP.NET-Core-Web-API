using System.ComponentModel.DataAnnotations;

namespace NzWalks.API.Models.DTO
{
    public class UpdateRegionRequestDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Name { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Code must be at least 4 characters long.")]
        [MaxLength(10, ErrorMessage = "Code cannot exceed 10 characters.")]
        public string Code { get; set; }
        public string? RegionImageUrl { get; set; } = null;
    }
}
