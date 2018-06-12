using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESN.Dal;
using ESN.Model;

namespace ESN.Bll
{
    public class DepartmentBLL : IDepartmentBLL
    {
        protected readonly DepartmentDAL departmentDAL;
        public DepartmentBLL()
        {
            this.departmentDAL = new DepartmentDAL();
        }
        public SearchResult<MSDepartment> GetDepartment(SearchParameter search)
        {
            return departmentDAL.GetDepartment(search);
        }
    }
}