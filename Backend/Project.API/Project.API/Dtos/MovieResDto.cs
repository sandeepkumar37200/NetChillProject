using System;
using System.Collections.Generic;

namespace Project.API.Dtos
{
    public class MovieDetailsResDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime YOR { get; set; }
        public DateTime AvailableDate { get; set; }
        public string Description { get; set; }
        public bool IsFeatured { get; set; }
        public string MoviesPoster { get; set; }
        public string ContentPath { get; set; }
    }

    public class MovieResDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsFeatured { get; set; }
        public string MoviesPoster { get; set; }
        public DateTime YOR { get; set; }
        public string Category { get; set; }
    }
}
