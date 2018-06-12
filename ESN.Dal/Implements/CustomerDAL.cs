using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESN.Dal.Infrastructure;
using ESN.Model;

namespace ESN.Dal
{
   public class CustomerDAL : Repository<Course>, ICustomerDAL
    {
        protected readonly IDBFactory DbFactory;

        protected readonly IDBFactory SubDbFactory;
        public CustomerDAL() : this(new DBFactory())
        {
            Course cus = new Course();
        }

        public CustomerDAL(IDBFactory dbFactory)
            : base(dbFactory.Connection)
        {
            this.DbFactory = dbFactory;
        }
    }
}
