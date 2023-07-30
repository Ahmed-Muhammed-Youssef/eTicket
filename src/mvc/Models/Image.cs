using mvc.Data.Base;

namespace mvc.Models
{
    public class Image : IEntityBase
    {
        public int Id { get; set; }
        public string ImagePath { get; set; } = "";
        public IFormFile? ImageFile { get; set; }


        public static Image DefaultImageFactory()
        {
            return new Image() { ImagePath = "images/default_image.jpg" };
        }
    }
}
