using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CarModel
    {
        public int KM { get; set; }
        public string Picture { get; set; }
        public string CarNumber { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public decimal PricePerDay { get; set; }
        public decimal PriceExtra { get; set; }
        public int Year { get; set; }
        public bool IsManual { get; set; }
    }
}