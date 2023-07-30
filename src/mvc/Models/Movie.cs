using mvc.Data.Base;
using mvc.Data.Enums;

namespace mvc.Models
{
    public class Movie : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public string Description { get; set; } = "";
        public DateTime StratDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }

        // Foreign Keys
        public int DirectorId { get; set; }
        public int CinemaId { get; set; }
        public int ImageId { get; set; }

        // Navigation Properties
        public IEnumerable<ActorMovie> ActorsMovies { get; set; } = new List<ActorMovie>();
        public Director Director { get; set; } = new Director();
        public Cinema Cinema { get; set; } = new Cinema();
        public Image Image { get; set; } = Image.DefaultImageFactory();
    }
}
