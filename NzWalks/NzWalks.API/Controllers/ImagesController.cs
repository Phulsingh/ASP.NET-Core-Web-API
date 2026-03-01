using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NzWalks.API.Models.Domain;
using NzWalks.API.Models.DTO;
using NzWalks.API.Repositories;



namespace NzWalks.API.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepositery imageRepositery;

        public ImagesController(IImageRepositery imageRepositery)
        {
            this.imageRepositery = imageRepositery;
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> UploadImage([FromForm] ImageUploadRequestDTO request)

        {
            ValidationFileUpload(request);

            if (request.File == null)
            {
                ModelState.AddModelError("File", "File is required");
                return BadRequest(ModelState);
            }

            if (ModelState.IsValid)
            {
                //Convert DTO to Domain Model 
                var imageDomainModel = new Images
                {
                     File = request.File,
                     FileExtension = Path.GetExtension(request.File.FileName),
                     FileSizeInBytes = request.File.Length,
                     FileName = request.FileName,
                     FileDescription = request.FileDescription,
                };

                //User repositery to upload imageto Local Storage and save details in Database
                await imageRepositery.Upload(imageDomainModel);
                Console.WriteLine("Succesfuly uploaded the Image");

            }

            return BadRequest(ModelState);
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
