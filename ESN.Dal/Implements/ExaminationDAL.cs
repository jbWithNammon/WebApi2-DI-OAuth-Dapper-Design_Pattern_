using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESN.Dal.Infrastructure;
using ESN.Model;

namespace ESN.Dal
{
    public class ExaminationDAL : Repository<Examination>, IExaminationDAL
    {
        protected readonly IDBFactory DbFactory;

        protected readonly IDBFactory SubDbFactory;
        public ExaminationDAL() : this(new DBFactory())
        {
            Examination category = new Examination();
        }

        public ExaminationDAL(IDBFactory dbFactory) : base(dbFactory.Connection)
        {
            this.DbFactory = dbFactory;
        }

        public List<Examination> GETExaminationAllDAL()
        {
            return base.GetAll().ToList();
        }
    }
}
