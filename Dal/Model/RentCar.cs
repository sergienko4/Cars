using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dal.Model
{
    public class RentCar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RentID;
        [DataType("YYYY-MM-DD")]

        public DateTime Start { get; set; }
        [Required]
        [DataType("YYYY-MM-DD")]

        public DateTime End { get; set; }
        [DataType("YYYY-MM-DD")]
        public DateTime DateReturned { get; set; }

        public virtual User UserID{ get; set; }
        public virtual Car CarID { get; set; }
         

    }
}