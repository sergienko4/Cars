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
                list =
                    _db.Cars.Where(x => x.IsFix.Equals(true) && x.IsRentable.Equals(true)).Include("CarType").ToList();
            }
            return list;

        }

        public Car GetCarByCarNum(string num)
        {
            Car car = null;
            using (_db = new RentCarEntities())
            {
                car = _db.Cars.Include("CarType").First(x => x.CarNum.Equals(num));
            }
            return car;
        }

        public List<Car> SearchCar(CarType car)
        {
            List<Car> list = null;
            using (_db = new RentCarEntities())
            {
                var listTypes =
                    _db.CarTypes.Where(
                        x =>
                            x.IsManual.Equals(car.IsManual) && (car.Model == null || x.Model.Equals(car.Model)) &&
                            (car.Brand == null || x.Brand.Equals(car.Brand))).Select(x => x.CarTypeID).ToList();
                list = _db.Cars.Where(x => listTypes.Contains(x.CarTypeID) && x.IsRentable).Include("CarType").ToList();
            }
            return list;
        }

        public User GetUserByID(int id)
        {
            User user = null;
            using (_db = new RentCarEntities())
            {
                user = _db.Users.Include("UserType").Single(x => x.UserID == id);
            }
            return user;
        }

        public User IsValidLogin(string userName, string pass)
        {
            User user = null;
            using (_db = new RentCarEntities())
            {
                user = _db.Users.FirstOrDefault(x => x.UserName == userName && x.Password.Equals(pass));
            }
            return user;
        }


        public void MakeNewOrder(Order order)
        {
            using (_db = new RentCarEntities())
            {
                _db.Orders.Add(order);
                _db.SaveChanges();
            }
        }

        public void UpdateCar(Car car)
        {
            using (_db = new RentCarEntities())
            {
                _db.Entry(car).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }

        public List<Order> GetClientOrders(int userUserId)
        {
            List<Order> orders = null;
            using (_db = new RentCarEntities())
            {
                orders = _db.Orders.Where(x => x.UserID == userUserId).ToList();
            }
            return orders;
        }

        public Order GetOrderByCarID(int CarId)
        {
           Order order = null;
            using (_db = new RentCarEntities())
            {
                order = _db.Orders.FirstOrDefault(x => x.CarID == CarId && (x.Returned == null));
            }
            return order;

        }

        public void CloseOrder(Order order)
        {
            using (_db = new RentCarEntities())
            {
                _db.Entry(order).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }

        public List<Order> GetAllOrders()
        {
            List<Order> orders = null;
            using (_db = new RentCarEntities())
            {
                orders = _db.Orders.ToList();
            }
            return orders;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = null;
            using (_db = new RentCarEntities())
            {
                users = _db.Users.ToList();
            }
            return users;
        }
    }
}
