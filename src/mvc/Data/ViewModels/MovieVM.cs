using mvc.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace mvc.Data.ViewModels
{
    public class MovieVM
    {
        public int Id { get; set; }
        public IFormFile? ImageFile { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Movie name")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Price is required")]
        [Display(Name  = "Prince in $")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Description")]
        public string Description { get; set; } = "";

        [Required(ErrorMessage = "Strat date is required")]
        [Display(Name = "Strat date")]
        public DateTime StratDate { get; set; }

        [Required(ErrorMessage = "End date is required")]
        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Movie category is required")]
        [Display(Name = "Category")]
        public MovieCategory MovieCategory { get; set; }

        [Required(ErrorMessage = "Producer is required")]
        [Display(Name = "Producer")]
        public int ProducerId { get; set; }

        [Required(ErrorMessage = "Cinema is required")]
        [Display(Name = "Cinema")]
        public int CinemaId { get; set; }

        [Required(ErrorMessage = "At least 1 actor is required")]
        [Display(Name = "Actors")]
        public IEnumerable<int> ActorIds { get; set; } = new List<int>();
    }
}
