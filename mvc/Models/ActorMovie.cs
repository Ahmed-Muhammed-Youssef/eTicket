namespace mvc.Models
{
    public class ActorMovie
    {
        public int ActorId { get; set; }
        public int MovieId { get; set; }

        // Navigation Properties
        public Movie? Movie { get; set; }
        public Actor? Actor { get; set; }
    }
}
