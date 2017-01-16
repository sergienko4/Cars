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
                //list.Add(new CarModel()
                //{
                //    CarNumber = car.CarNum,
                //    BrandName = car.Brand,
                //    IsManual = car.IsManual,
                //    KM = car.KM,
                //    Model = car.Model,
                //    Picture = car.Picture,
                //    PriceExtra = car.TypeCar.PriceExtra,
                //    PricePerDay = car.TypeCar.PricePerDay,
                //    Year = car.TypeCar.Year
                //});
            }
            return list;
        }


        public CarModel GetCarModel(Car car)
        {
            return new CarModel()
            {
                //CarNumber = car.CarNumber,
                //BrandName = car.TypeCar.BrandName,
                //IsManual = car.TypeCar.IsManual,
                //KM = car.KM,
                //Model = car.TypeCar.Model,
                //Picture = car.Picture,
                //PriceExtra = car.TypeCar.PriceExtra,
                //PricePerDay = car.TypeCar.PricePerDay,
                //Year = car.TypeCar.Year
            };
        }
    }
}