using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public List<Car> SearchCar(CarType car, DateTime start, DateTime finish)
        {
            List<Car> list;
            using (_db = new RentCarEntities())
            {
                list = _db.CarTypes.Where(x=> x.IsManual.Equals(car.IsManual)  && x.Model.Equals(car.Model) && x.Brand.Equals(car.Brand)).Where(n=> n.)
                    //.Include("CarType").ToList();
            }
            return list;
        }
    }
}
