using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Registration
    {
        [Required]
        [Display(Name = "User name")]
        public string User { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        public string ID { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public char Gender { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Pass { get; set; }

        [Required]
        [Compare("Pass")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public int UserTypeID { get; set; }
    }

}