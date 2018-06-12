using ESN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESN.Dal
{
    public interface ICustomerDAL : IRepository<Course>
    {
        void Dispose();
    }
}
