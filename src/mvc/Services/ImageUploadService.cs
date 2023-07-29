using mvc.Interfaces;
using mvc.Models;

namespace mvc.Services
{
    public class ImageUploadService : IImageUploadService
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public ImageUploadService(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
        public void Delete(string imagePath)
        {
            string destinationOnServer = Path.Combine(_hostEnvironment.WebRootPath + "/", imagePath);
            if (File.Exists(destinationOnServer))
            {
                File.Delete(destinationOnServer);
            }
        }
        public async Task<string> UploadAsync(Image image, string imageId)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string extension = Path.GetExtension(image.ImageFile!.FileName);

            string fileName = imageId + '-' + DateTime.Now.ToString("yymmssfff") + extension;

            string destinationOnServer = Path.Combine(wwwRootPath + "/images/", fileName);
            using (var fileStream = new FileStream(destinationOnServer, FileMode.Create))
            {
                await image.ImageFile.CopyToAsync(fileStream);
            }
            return "images/" + fileName;
        }
    }
}
