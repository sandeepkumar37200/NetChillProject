using Project.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project.DAL.Domain_Models
{
    public class Movie : BaseDomain
    {

        [Required(ErrorMessage = "Plese enter movie name ")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)] // keyword 
        public string Category { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime YOR { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime AvailableDate { get; set; }

        [Required]
        [StringLength(8000)]
        public string Description { get; set; }


        public bool IsFeatured { get; set; } = false;

        public string MoviesPoster { get; set; }

        public string ContentPath { get; set; }

        public ICollection<UserMovie> UserMovie { get; set; }

    }
}
