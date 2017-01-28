using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class OrderModel
    {
        public int id { get; set; }
        public CarModel car{ get; set; }
      
        public int UserID { get; set; }
        [Required]
        [DataType(DataType.Date)]

        public DateTime Start { get; set; }
        [Required]
        [DataType(DataType.Date)]

        public DateTime Finish { get; set; }

        public double ToCharge { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Returned { get; set; }
    }
}