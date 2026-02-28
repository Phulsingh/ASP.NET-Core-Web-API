using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NzWalks.API.Models.DTO;

namespace NzWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> UploadImage([FromForm] ImageUploadRequestDTO request)

        {
            ValidationFileUpload(request);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok("File Uploaded Successfully");
        }

        private void ValidationFileUpload(ImageUploadRequestDTO request)
        {
            var allowedExtension = new string[] { ".jpg", ".jpeg", ".png", ".gif" };

            if (!allowedExtension.Contains(Path.GetExtension(request.File.FileName)))
            {
                ModelState.AddModelError("File", "UnSupported File Extension");
            }
            if (request.File.Length > 10485760)
            {
                ModelState.AddModelError("File", "File Size Exceeds 10MB");

            }
        }
    }
}
