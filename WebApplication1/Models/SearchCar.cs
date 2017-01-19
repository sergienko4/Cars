using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class SearchCar 
    {
       [Display(Name = "Is the car manual")]
        public bool IsManual { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        //[DataType(DataType.Date)]
        //[Display(Name = "Puck up")]
        //public DateTime Start { get; set; }
        //[DataType(DataType.Date)]
        //[Display(Name = "Return")]
        //public DateTime Finish { get; set; }
    }
}