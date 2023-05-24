using mvc.Data.Enums;

namespace mvc.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public DateTime StratDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? ImageUrl { get; set; }
        public MovieCategory MovieCategory { get; set; }

        // Foreign Keys
        public int ProducerId { get; set; }
        public int CinemaId { get; set; }

        // Navigation Properties
        public IEnumerable<ActorMovie>? ActorsMovies { get; set; }
        public Producer? Producer { get; set; }
        public Cinema? Cinema { get; set; }
    }
}
