using mvc.Data.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    public class Actor : IEntityBase
    {
        public int Id { get; set; }

        [DisplayName("Profile Picture")]
        [Required]
        public string? ProfilePictureUrl { get; set; }

        [DisplayName("Full Name")]
        [Required]
        public string? FullName { get; set; }

        [DisplayName("Bio")]
        [Required]
        public string? Bio { get; set; }

        // Navigation Properties
        public IEnumerable<ActorMovie>? ActorsMovies { get; set; }
    }
}
