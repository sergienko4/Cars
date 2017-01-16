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
                list.Add(new CarModel()
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
            });
        }
            return list;
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
}
}