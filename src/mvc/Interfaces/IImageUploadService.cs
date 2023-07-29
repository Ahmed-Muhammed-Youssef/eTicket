using mvc.Models;

namespace mvc.Interfaces
{
    public interface IImageUploadService
    {
        public void Delete(string imagePath);
        public Task<string> UploadAsync(Image image, string imageId);
    }
}
