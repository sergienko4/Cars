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
        private readonly GetDataFromDB _db = new GetDataFromDB();
        public List<Car> GetCars()
        {
            var result = _db.GetCars().ToList();
            return result;
        }


        public Car GetCarByCarNum(string carNumber)
        {
            return _db.GetCarByCarNum(carNumber);
        }

        public List<Car> SearchCar(CarType car)
        {
            return _db.SearchCar(car);
        }

        public User GetUserByID(int id)
        {
            return _db.GetUserByID(id);
        }

        public User IsValidLogin(string userName, string pass)
        {
            return _db.IsValidLogin(userName, pass);
        }

        public void MakeOrder(Order newOrder)
        {
            Car car = GetCarByCarNum(newOrder.Car.CarNum);
            Order order = new Order()
            {
                UserID = newOrder.UserID,
                CarID = car.CarID,
                Start = newOrder.Start,
                Finish = newOrder.Finish

            };
            _db.MakeNewOrder(order);
            ChangeCarStateRent(car);
            _db.UpdateCar(car);
        }

        public double GetCarBack(Car car)
        {
            Car myCar = GetCarByCarNum(car.CarNum);
            myCar.KM = car.KM;
            myCar.IsFix = car.IsFix;
            ChangeCarStateRent(myCar);
            _db.UpdateCar(myCar);

            Order order = _db.GetOrderByCarID(myCar.CarID);
            order.Returned = DateTime.Now;
            _db.CloseOrder(order);
           return GetFinalPrice(myCar, order);


        }

        private double GetFinalPrice(Car car, Order order)
        {
            decimal price = 0;
            CarType carType = _db.PriceTypeCarByCar(car);
            if (order.Returned >= order.Finish)
            {
                var extra = Math.Abs(order.Finish.Subtract((DateTime)order.Returned).Days);
                price = extra * carType.PriceExtraPerDay;
            }

            var result = order.Finish.Subtract(order.Start).Days;
            price += result * carType.PricePerDay;
            return Convert.ToDouble(price);

        }
        private void ChangeCarStateRent(Car car)
        {
            car.IsRentable = !car.IsRentable;
        }

        public List<Order> GetClientOrders(int userUserId)
        {
            return _db.GetClientOrders(userUserId);
        }

        public List<Order> GetAllOrders()
        {
            return _db.GetAllOrders();
        }

        public List<User> GetAllUsers()
        {
            return _db.GetAllUsers();
        }
    }
}
