using mvc.Data.Base;

namespace mvc.Models
{
    public class Cinema : IEntityBase
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Logo { get; set; }
        public string? Description { get; set; }

        // navigation properties
        public IEnumerable<Movie>? Movies { get; set; }
    }
}
