﻿using mvc.Data.Base;

namespace mvc.Models
{
    public class Producer : IEntityBase
    {
        public int Id { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? FullName { get; set; }
        public string? Bio { get; set; }

        // navigation properties
        public IEnumerable<Movie>? Movies { get; set; }
    }
}
