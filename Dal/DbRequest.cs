using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class DbRequest : DbContext
    {
        public DbRequest() : base("RentCar")
        {
        }

        public System.Data.Entity.DbSet<Model.TypeCar> TypeCar { get; set; }
        public System.Data.Entity.DbSet<Model.Branch> Branch { get; set; }
        public System.Data.Entity.DbSet<Model.Car> Car { get; set; }
        public System.Data.Entity.DbSet<Model.RentCar> RentCar { get; set; }
        public System.Data.Entity.DbSet<Model.User> User { get; set; }
       


    }
}
