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
        public List<Car> GetCarsForManager()
        {
            var result = _db.GetCarsForManager().ToList();
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

        public void UpdateCar(Car car)
        {
            var dbCar = _db.GetCarByCarNum(car.CarNum);

            dbCar.KM = car.KM;
            dbCar.IsRentable = car.IsRentable;
            dbCar.IsFix = car.IsFix;
            dbCar.CarNum = car.CarNum;
            _db.UpdateCar(dbCar);
        }

        public List<Car> GetCars()
        {
            return _db.GetCars();
        }

        public void DeleteCarByCarNum(string id)
        {
            _db.DeleteCarByCarNum(id);
        }

        public List<UserType> GetCarTypes()
        {
            return _db.GetUserTypes();
        }

        public void UpdateUser(User user, int userTypeId)
        {
            var dbUserType = _db.GetUserTypeByID(userTypeId);
            var dbUser = GetUserByID(user.UserID);
            dbUser.UserTypeID = userTypeId;
            dbUser.FullName = user.FullName;
            dbUser.Gender = user.Gender;
            dbUser.Password = user.Password;
            dbUser.UserName = user.UserName;
            _db.UpdateUser(dbUser);

        }

        public void DeleteUserByID(int id)
        {
            _db.DeleteUserByID(id);
        }

        public void AddNewUser(User newUser)
        {
            _db.AddNewUser(newUser);
        }

        public Order GetOrderByID(int id)
        {
            return _db.GetOrderByOrderID(id);
        }

        public void UpdateOrder(Order order)
        {
            var dbOrder = GetOrderByID(order.OrderID);
            dbOrder.Start = order.Start;
            dbOrder.Finish = order.Finish;
            if (order.Returned != default(DateTime) && order.Returned != null)
                dbOrder.Returned = order.Returned;
            _db.UpdateOrder(dbOrder);
        }

        public void DeleteOrderByID(int id)
        {
            var order = GetOrderByID(id);
            _db.DeleteOrderByID(order);
            var car = _db.GetCarByID(order.CarID);
            car.IsRentable = true;
            _db.UpdateCar(car);
        }
    }
}
