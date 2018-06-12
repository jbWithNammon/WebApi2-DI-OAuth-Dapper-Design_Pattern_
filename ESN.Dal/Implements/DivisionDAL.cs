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
    public class DivisionDAL : Repository<MSDivision>, IDivisionDAL
    {
        protected readonly IDBFactory DbFactory;


        public DivisionDAL() : this(new DBFactory())
        {
            MSDivision cus = new MSDivision();
        }

        public DivisionDAL(IDBFactory dbFactory)
            : base(dbFactory.Connection)
        {
            this.DbFactory = dbFactory;
        }

        public SearchResult<MSDivision> GetDivision(SearchParameter search)
        {
            const string column = @"SELECT MSDivision.*";
            const string source = @"FROM MSDivision ";
            var result = new SearchResult<MSDivision>();
            var query = search.CreateQuery(column, source);
            try
            {
                using (var multi = this.DbFactory.Connection.QueryMultiple(query))
                {
                    var count = multi.Read<int>().FirstOrDefault();
                    var resultList = multi.Read<MSDivision>(true);
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
