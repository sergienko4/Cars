using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dal.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID;
        [Required]
        [Display(Name = "First name ")]
        public string FirstName;
        [Required]
        [Display(Name = "Last name")]
        public string LastName;
        [DataType(DataType.Date)]
        public DateTime Birthday;
        [Required]
        [Display(Name = "Gender")]
        Gender MyGender;
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Pass;
        [Required]
        [Compare("Pass")]
        [Display(Name = "Confirm Password")]

        public string ConfirmPassword { get; set; }

        public string Pic;
        [Required]
        UserType type;

        enum Gender
        {
            Male,
            Female
        };

        enum UserType
        {
            Manager,
            Worker,
            Clinet

        }
    }


}

