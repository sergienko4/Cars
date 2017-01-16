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
        //private DbRequest _db = new DbRequest();

        public List<Car> GetCars()
        {
            List<Car> list;
            using (RentCarEntities _db = new RentCarEntities())
            {
                list = _db.Cars.ToList();
            }
            return list;

        }
    }
}
