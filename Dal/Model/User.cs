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
        public string FirstName;
        [Required]
        public string LastName;
        [DataType("YYYY-MM-DD")]
        public DateTime Birthday;
        [Required]
        Gender MyGender;
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Pass;

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

