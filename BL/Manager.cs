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


        public Car GetCarByCarID(int carNumber)
        {
            throw new NotImplementedException();
        }

        
    }
}
