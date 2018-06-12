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
    public class WorkExperienceDAL : Repository<MSWorkExperience>, IWorkExperienceDAL
    {
        protected readonly IDBFactory DbFactory;


        public WorkExperienceDAL() : this(new DBFactory())
        {
            MSWorkExperience cus = new MSWorkExperience();
        }

        public WorkExperienceDAL(IDBFactory dbFactory)
            : base(dbFactory.Connection)
        {
            this.DbFactory = dbFactory;
        }

        public SearchResult<MSWorkExperience> GetWorkExp(SearchParameter search)
        {
            const string column = @"SELECT MSWorkExperience.*";
            const string source = @"FROM MSWorkExperience ";
            var result = new SearchResult<MSWorkExperience>();
            var query = search.CreateQuery(column, source);
            try
            {
                using (var multi = this.DbFactory.Connection.QueryMultiple(query))
                {
                    var count = multi.Read<int>().FirstOrDefault();
                    var resultList = multi.Read<MSWorkExperience>(true);
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
