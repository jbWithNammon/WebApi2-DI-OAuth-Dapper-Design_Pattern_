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
    public class CourseContentDAL : Repository<CourseContent>, ICourseContentDAL
    {
        protected readonly IDBFactory DbFactory;


        public CourseContentDAL() : this(new DBFactory())
        {
            CourseContent cus = new CourseContent();
        }

        public CourseContentDAL(IDBFactory dbFactory)
            : base(dbFactory.Connection)
        {
            this.DbFactory = dbFactory;
        }

        public IEnumerable<CourseContent> GetCourseContentAll()
        {
            return base.GetAll();
        }
        public SearchResult<CourseContent> GetCourseContentByID(SearchParameter search)
        {
            const string column = @"SELECT CourseContent.*";
            const string source = @"FROM CourseContent";
            var result = new SearchResult<CourseContent>();
            var query = search.CreateQuery(column, source);
            try
            {
                using (var multi = this.DbFactory.Connection.QueryMultiple(query))
                {
                    var count = multi.Read<int>().FirstOrDefault();
                    var resultList = multi.Read<CourseContent>(true);
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
