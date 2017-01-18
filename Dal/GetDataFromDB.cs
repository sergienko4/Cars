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
                list = _db.Cars.Where(x => x.IsFix.Equals(true) && x.IsRentable.Equals(true)).Include("CarType").ToList();
            }
            return list;

        }

        public Car GetCarByCarNum(string num)
        {
            Car car = null;
            using (_db = new RentCarEntities())
            {
                car = _db.Cars.FirstOrDefault(x => x.CarNum.Equals(num));
            }
            return car;
        }

        public List<Car> SearchCar(CarType car, DateTime start, DateTime finish)
        {
            List<Car> list = null;
            using (_db = new RentCarEntities())
            {
               // list = _db.CarTypes.Where(x => x.IsManual.Equals(car.IsManual) && x.Model.Equals(car.Model) && x.Brand.Equals(car.Brand)).Where(n => n.)
                    //.Include("CarType").ToList();
            }
            return list;
        }

        public void RentCar(Car car)
        {
            using (_db = new RentCarEntities())
            {
                _db.Entry(car).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }
    }
}
