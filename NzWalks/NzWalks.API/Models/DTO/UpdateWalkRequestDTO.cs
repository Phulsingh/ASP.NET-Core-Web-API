using System.ComponentModel.DataAnnotations;

namespace NzWalks.API.Models.DTO
{
    public class UpdateWalkRequestDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Name { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
        [MaxLength(500, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Description { get; set; }
        public string? WalkImageUrl { get; set; } = null;

        [Required]
        [MinLength(1, ErrorMessage = "LengthInKm must be greater than 0.")]
        [MaxLength(1000, ErrorMessage = "LengthInKm cannot exceed 1000.")]
        public double LengthInKm { get; set; }
        [Required]
        public Guid DifficultyId { get; set; }
        [Required]
        public Guid RegionId { get; set; }
    }
}
