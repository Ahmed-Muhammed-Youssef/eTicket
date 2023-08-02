using mvc.Data.Base;

namespace mvc.Models
{
    public class Image : IEntityBase
    {
        private static string defaultImagePath = "images/default_image.jpg";
        public int Id { get; set; }
        public string ImagePath { get; set; } = defaultImagePath;
        public IFormFile? ImageFile { get; set; }


        public static Image DefaultImageFactory()
        {
            return new Image() { ImagePath = defaultImagePath };
        }
    }
}
