using ESN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESN.Dal
{
    public interface IEmployeeDAL : IRepository<Employee>
    {
        SearchResult<Employee> GetEmployee(SearchParameter search);
        void Dispose();
    }
}
