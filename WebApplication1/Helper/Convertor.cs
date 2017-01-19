using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dal.Model;
using WebApplication1.Models;

namespace WebApplication1.Helper
{
    public class Convertor
    {
        public List<CarModel> GetListOfCarModels(List<Car> cars)
        {
            List<CarModel> list = new List<CarModel>();

            foreach (var car in cars)
            {
                var c = new CarModel()
                {
                    CarNumber = car.CarNum,
                    BrandName = car.CarType.Brand,
                    IsManual = car.CarType.IsManual,
                    KM = car.KM,
                    Model = car.CarType.Model,
                    Picture = car.CarPic,
                    PriceExtra = car.CarType.PriceExtraPerDay,
                    PricePerDay = car.CarType.PricePerDay,
                    Year = car.CarType.Year
                };
                list.Add(c);
            }
            return list;
        }

        public CarType GetCarTypeFromSerachModel(SearchCar SearchCar)
        {
            return new CarType()
            {
                Model = SearchCar.Model,
                Brand = SearchCar.Brand,
                IsManual = SearchCar.IsManual
            };
        }

        public CarModel GetCarModel(Car car)
        {
            return new CarModel()
            {
                CarNumber = car.CarNum,
                BrandName = car.CarType.Brand,
                IsManual = car.CarType.IsManual,
                KM = car.KM,
                Model = car.CarType.Model,
                Picture = car.CarPic,
                PriceExtra = car.CarType.PriceExtraPerDay,
                PricePerDay = car.CarType.PricePerDay,
                Year = car.CarType.Year
            };
        }

        public OrderModel GetOrderModelFromCarModel(CarModel tempCar, int id)
        {
            return new OrderModel()
            {
                car = tempCar,
                UserID = id
            };
        }


        public Order getOrderFromOrderModel(OrderModel order)
        {
            return new Order()
            {

                Car = new Car() { CarNum = order.car.CarNumber, CarType = new CarType() { PricePerDay = order.car.PricePerDay } },
                Finish = order.Finish,
                Start = order.Start,
                UserID = order.UserID
            };
        }


    }
}