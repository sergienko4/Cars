using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dal.Model;

namespace BL
{
    public class Manager
    {
        private GetDataFromDB _db = new GetDataFromDB();
        public List<Car> GetCars()
        {
            var result = _db.GetCars().ToList();
            return result;
        }


        public Car GetCarByCarNum(string carNumber)
        {
            var result = _db.GetCarByCarNum(carNumber);
            return result;
        }

        public void RentCar(string carNume, DateTime starTime, DateTime fini)
        {
            //TODO rent car order 
            //var car = GetCarByCarNum(carNume);
            //car.IsRentable = false;
            //car.Orders.Add(new Order()
            //{
            //    Car =  car, Start = 
            //});
            //_db.RentCar(car);
        }
        public List<Car> SearchCar(CarType car, DateTime start, DateTime finish)
        {
           return _db.SearchCar(car, start, finish);
        }
    }
}
