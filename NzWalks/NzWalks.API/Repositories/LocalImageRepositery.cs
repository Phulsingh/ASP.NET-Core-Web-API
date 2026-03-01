using NzWalks.API.Data;
using NzWalks.API.Models.Domain;


namespace NzWalks.API.Repositories
{
    public class LocalImageRepositery : IImageRepositery
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccesser;
        private readonly NZWalksDbContext dbContext;

        public LocalImageRepositery(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccesser, NZWalksDbContext dbContext  )
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccesser = httpContextAccesser;
            this.dbContext = dbContext;
        }

        public async Task<Images> Upload(Images image)
        {
            var localFilePath = Path.Combine(webHostEnvironment.WebRootPath, "Images", image.FileName);
            //Upload Image to Local Storage
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            //
            // Return the Image Details
            var urlFilePath =
    $"{httpContextAccesser.HttpContext.Request.Scheme}://" +
    $"{httpContextAccesser.HttpContext.Request.Host}" +
    $"{httpContextAccesser.HttpContext.Request.PathBase}/static/Images/{image.FileName}{image.FileExtension}";

            image.FilePath = urlFilePath;

            // FIX: Use Set<Images>() to get the DbSet for Images
            await dbContext.Images.AddAsync(image);
            await dbContext.SaveChangesAsync();

            return image;
        }
    }
}
