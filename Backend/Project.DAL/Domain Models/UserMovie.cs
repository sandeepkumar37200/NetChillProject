using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Project.DAL.Domain_Models
{
    public class UserMovie
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; } 

        public Guid MovieId { get; set; }

        public Movie Movies { get; set; }

        public User Users { get; set; }

    }
}
