using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dal.Model
{
    public class TypeCar
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeCarID;
        [Required]
        public string BrandName { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public double PricePerDay { get; set; }
        [Required]
        public double PriceExtra { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public bool IsManual { get; set; }

    }
}