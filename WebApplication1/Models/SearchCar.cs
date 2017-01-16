using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class SearchCar
    {
        public bool IsManual { get; set; }
        public int Year { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        [Display(Name = "By expretion")]
        public string FreeSearch { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Start { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Finish { get; set; }
    }
}