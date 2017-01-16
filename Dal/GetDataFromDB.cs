using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Model;

namespace Dal
{
   public class GetDataFromDB
    {
        RentCarEntities _db;

        public List<Car> GetCars()
        {
            List<Car> list;
            using (_db = new RentCarEntities())
            {
                list = _db.Cars.Include("CarType").ToList();
            }
            return list;

        }
    }
}
