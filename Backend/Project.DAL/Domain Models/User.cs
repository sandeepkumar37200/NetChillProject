using Project.DAL.Domain_Models;
using Project.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.DAL
{
    public class User : BaseDomain
    {

        [Required(ErrorMessage = "Please enter FullName")]
        [Display(Name = "FullName")]
        [StringLength(225)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Please enter correct email")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public bool SubscriptionStatus { get; set; } = true;

        public bool IsAdmin { get; set; } = false; //IsAdmin
        public ICollection<UserMovie> UserMovie { get; set; }

       
    }
}