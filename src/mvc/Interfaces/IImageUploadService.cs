using mvc.Models;

namespace mvc.Interfaces
{
    public interface IImageUploadService
    {
        public Task<string> UploadAsync(Image image, string imageId);
    }
}
