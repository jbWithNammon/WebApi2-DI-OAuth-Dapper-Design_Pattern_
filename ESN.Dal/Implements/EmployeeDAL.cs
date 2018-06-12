using Dapper;
using ESN.Dal.Infrastructure;
using ESN.Model;
using ESN.Util.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESN.Dal
{
    public class EmployeeDAL : Repository<Employee>, IEmployeeDAL
    {
        protected readonly IDBFactory DbFactory;


        public EmployeeDAL() : this(new DBFactory())
        {
            Employee cus = new Employee();
        }

        public EmployeeDAL(IDBFactory dbFactory)
            : base(dbFactory.Connection)
        {
            this.DbFactory = dbFactory;
        }

        public SearchResult<Employee> GetEmployee(SearchParameter search)
        {
            const string column = @"SELECT Employee.*
                                    ,MSDivision.Id AS MSDivisionID
                                    ,MSDivision.*
                                    ,MSDepartment.Id AS MSDepartmentID
                                    ,MSDepartment.*
                                    ,MSPosition.Id AS MSPositionID
                                    ,MSPosition.*";
            const string source = @"FROM Employee LEFT JOIN MSDepartment 
                                    ON MSDepartment.ID = Employee.DeptID
                                    LEFT JOIN MSDivision
                                    ON MSDivision.ID = Employee.DivID
                                    LEFT JOIN MSPosition
                                    ON MSPosition.ID = Employee.PositionID";
            var result = new SearchResult<Employee>();
            var query = search.CreateQuery(column, source);
            try
            {
                using (var multi = this.DbFactory.Connection.QueryMultiple(query))
                {
                    var count = multi.Read<int>().FirstOrDefault();
                    var resultList = multi.Read<Employee, MSDepartment, MSDivision, MSPosition, Employee>((employee, department,division,position) =>
                    {
                        employee.Department = department;
                        employee.Division = division;
                        employee.Position = position;
                        return employee;
                    }, "MSDivisionID,MSDepartmentID,MSPositionID");
                    result.ResultList = resultList.AsQueryable();
                    result.TotalRecord = count;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }
    }
}
