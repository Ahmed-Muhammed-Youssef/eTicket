using mvc.Data.Base;

namespace mvc.Models
{
    public class Director : IEntityBase
    {
        public int Id { get; set; }
        public string FullName { get; set; } = "";
        public string Bio { get; set; } = "";

        // Foreign Keys
        public int ImageId { get; set; }

        // navigation properties
        public IEnumerable<Movie> Movies { get; set; } = new List<Movie>();
        public Image Image { get; set; } = Image.DefaultImageFactory();
    }
}
