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

        public List<Car> GetCarsForManager()
        {
            List<Car> list;
            using (_db = new RentCarEntities())
            {
                list =
                    _db.Cars.Include("CarType").ToList();
            }
            return list;

        }

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
                user = _db.Users.Include("UserType").Single(x => x.UserID == id && x.IsValidUSer == true);
            }
            return user;
        }

        public User IsValidLogin(string userName, string pass)
        {
            User user = null;
            using (_db = new RentCarEntities())
            {
                user = _db.Users.FirstOrDefault(x => x.UserName == userName && x.Password.Equals(pass) && x.IsValidUSer == true);
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
                users = _db.Users.Where(x => x.IsValidUSer == true).ToList();
            }
            return users;
        }

        public CarType PriceTypeCarByCar(Car car)
        {
            CarType carType = null;
            using (_db = new RentCarEntities())
            {
                carType = _db.CarTypes.First(x => x.CarTypeID == car.CarTypeID);
            }
            return carType;
        }


        public void DeleteCarByCarNum(string id)
        {
            using (_db = new RentCarEntities())
            {
                var car = _db.Cars.FirstOrDefault(x => x.CarNum.Equals(id));
                if (car != null)
                    _db.Cars.Remove(car);
                _db.SaveChanges();
            }
        }

        public List<UserType> GetUserTypes()
        {
            List<UserType> types = null;
            using (_db = new RentCarEntities())
            {
                types = _db.UserTypes.ToList();
            }
            return types;
        }

        public void UpdateUser(Dal.Model.User dbUser)
        {
            using (_db = new RentCarEntities())
            {
                _db.Entry(dbUser).State = EntityState.Modified;
                _db.SaveChanges();


            }
        }

        public UserType GetUserTypeByID(int userTypeId)
        {
            UserType type = null;
            using (_db = new RentCarEntities())
            {
                type = _db.UserTypes.FirstOrDefault(x => x.UserTypeID == userTypeId);
            }
            return type;
        }

        public void DeleteUserByID(int id)
        {
            using (_db = new RentCarEntities())
            {
                var user = _db.Users.FirstOrDefault(x => x.UserID.Equals(id));
                if (user != null)
                    user.IsValidUSer = false;
                _db.Entry(user).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }

        public void AddNewUser(User newUser)
        {
            using (_db = new RentCarEntities())
            {
                var user = _db.Users.Add(newUser);
                _db.SaveChanges();
            }
        }

        public Order GetOrderByOrderID(int id)
        {
            Order order = null;
            using (_db = new RentCarEntities())
            {
                order = _db.Orders.FirstOrDefault(i => i.OrderID == id);
            }
            return order;
        }

        public void UpdateOrder(Order dbOrder)
        {
            using (_db = new RentCarEntities())
            {
                _db.Entry(dbOrder).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }
    }
}
