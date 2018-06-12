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
    public class CourseListDAL : Repository<CourseList>, ICourseListDAL
    {
        protected readonly IDBFactory DbFactory;

        protected readonly IDBFactory SubDbFactory;
        public CourseListDAL() : this(new DBFactory())
        {
            CourseList cus = new CourseList();
        }

        public CourseListDAL(IDBFactory dbFactory)
            : base(dbFactory.Connection)
        {
            this.DbFactory = dbFactory;
        }

        public IEnumerable<CourseList> GetCourseListAll()
        {
            return base.GetAll();
        }

        public SearchResult<CourseList> GetCourseListByID(SearchParameter search)
        {
            const string column = @"SELECT CourseList.*,MSContentType.Id AS MSContentTypeID, MSContentType.*";
            const string source = @"FROM CourseList LEFT JOIN MSContentType 
                                    ON MSContentType.ID = CourseList.ContentID";
            var result = new SearchResult<CourseList>();
            var query = search.CreateQuery(column, source);
            try
            {
                using (var multi = this.DbFactory.Connection.QueryMultiple(query))
                {
                    var count = multi.Read<int>().FirstOrDefault();
                    var resultList = multi.Read<CourseList, MSContentType, CourseList>((courseList, masterContentType) =>
                    {
                        courseList.ContentMaster = masterContentType;
                        return courseList;
                    }, "MSContentTypeID");
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

        public SearchResult<CourseList> GetCourseListSingle(SearchParameter search)
        {
            const string column = @"SELECT CourseList.*";
            const string source = @"FROM CourseList ";
            var result = new SearchResult<CourseList>();
            var query = search.CreateQuery(column, source);
            try
            {
                using (var multi = this.DbFactory.Connection.QueryMultiple(query))
                {
                    var count = multi.Read<int>().FirstOrDefault();
                    var resultList = multi.Read<CourseList>(true);
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

        public SearchResult<CourseList> GetTotalTopic()
        {
            SearchParameter search = new SearchParameter();
            search.ClearFilterList();
            search.SortTable = "CourseList";
            search.SortColumn = "CourseID";
            search.SortAscending = true;
            const string column = @"SELECT CourseList.CourseID,count(1) as TotalTopic";
            const string source = @"FROM CourseList GROUP BY CourseID";
            var result = new SearchResult<CourseList>();
            var query = search.CreateQuery(column, source);
            try
            {
                using (var multi = this.DbFactory.Connection.QueryMultiple(query))
                {
                    var count = multi.Read<int>().FirstOrDefault();
                    var resultList = multi.Read<CourseList>(true);
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
