using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dal.Model
{
    public class Car
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarID;

        public int KM { get; set; }

        public string Picture{ get; set; }

        public bool IsCarReadyToRent { get; set; }
        public bool IsCarAvailable { get; set; }
        public int CarNumber { get; set; }
        public virtual TypeCar TypeCar { get; set; }
    }
}