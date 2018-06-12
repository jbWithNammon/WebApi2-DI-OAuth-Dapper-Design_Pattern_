using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESN.Dal;
using ESN.Model;

namespace ESN.Bll
{
    public class EmployeeBLL : IEmployeeBLL
    {
        protected readonly IEmployeeDAL employeeDAL;
        public EmployeeBLL()
        {
            this.employeeDAL = new EmployeeDAL();
        }
        public IEnumerable<Employee> GetAll()
        {
            return employeeDAL.GetAll();
        }

        public SearchResult<Employee> GetEmployee(SearchParameter search)
        {
            return employeeDAL.GetEmployee(search);
        }
    }
}
