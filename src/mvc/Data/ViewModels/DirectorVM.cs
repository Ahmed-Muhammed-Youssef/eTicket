using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace mvc.Data.ViewModels
{
    public class DirectorVM
    {
        [Required]
        [DisplayName("Full Name")]
        public string FullName { get; set; } = "";

        [Required]
        [DisplayName("Bio")]
        public string Bio { get; set; } = "";
        public IFormFile? ImageFile { get; set; }
    }
}
