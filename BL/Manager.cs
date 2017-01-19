﻿using System;
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

        public void GetCarBack(Car car)
        {
            Car myCar = GetCarByCarNum(car.CarNum);
            myCar.KM = car.KM;
            myCar.IsFix = car.IsFix;
            ChangeCarStateRent(myCar);
            _db.UpdateCar(myCar);

            Order order = _db.GetOrderByCarID(myCar.CarID);
            order.Returned = DateTime.Now;
            _db.CloseOrder(order);
        }

        private void ChangeCarStateRent(Car car)
        {
            car.IsRentable = !car.IsRentable;
        }

        public List<Order> GetClientOrders(int userUserId)
        {
            return _db.GetClientOrders(userUserId);
        }
    }
}
