﻿using mvc.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace mvc.Data.ViewModels
{
    public class CinemaVM
    {
        [Required]
        [DisplayName("Name")]
        public string Name { get; set; } = "";

        [Required]
        [DisplayName("Description")]
        public string Description { get; set; } = "";
        public Image Image { get; set; } = new Image();
    }
}
