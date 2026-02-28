using Microsoft.AspNetCore.Routing.Constraints;
using System.ComponentModel.DataAnnotations;

namespace NzWalks.API.Models.DTO
{
    public class ImageUploadRequestDTO
    {
        [Required]
        public IFormFile File { get; set; }

        [Required]
        public string FileName { get; set; }
        public string? FileDescription { get; set; }
    }
}
