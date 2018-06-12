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
    public class PositionDAL : Repository<MSPosition>, IPositionDAL
    {
        protected readonly IDBFactory DbFactory;


        public PositionDAL() : this(new DBFactory())
        {
            MSPosition cus = new MSPosition();
        }

        public PositionDAL(IDBFactory dbFactory)
            : base(dbFactory.Connection)
        {
            this.DbFactory = dbFactory;
        }

        public SearchResult<MSPosition> GetPosition(SearchParameter search)
        {
            const string column = @"SELECT MSPosition.*";
            const string source = @"FROM MSPosition ";
            var result = new SearchResult<MSPosition>();
            var query = search.CreateQuery(column, source);
            try
            {
                using (var multi = this.DbFactory.Connection.QueryMultiple(query))
                {
                    var count = multi.Read<int>().FirstOrDefault();
                    var resultList = multi.Read<MSPosition>(true);
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
