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
    public class DepartmentDAL : Repository<MSDepartment>,IDepartmentDAL
    {
        protected readonly IDBFactory DbFactory;


        public DepartmentDAL() : this(new DBFactory())
        {
            MSDepartment cus = new MSDepartment();
        }

        public DepartmentDAL(IDBFactory dbFactory)
            : base(dbFactory.Connection)
        {
            this.DbFactory = dbFactory;
        }

        public SearchResult<MSDepartment> GetDepartment(SearchParameter search)
        {
            const string column = @"SELECT MSDepartment.*";
            const string source = @"FROM MSDepartment ";
            var result = new SearchResult<MSDepartment>();
            var query = search.CreateQuery(column, source);
            try
            {
                using (var multi = this.DbFactory.Connection.QueryMultiple(query))
                {
                    var count = multi.Read<int>().FirstOrDefault();
                    var resultList = multi.Read<MSDepartment>(true);
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
