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
    public class CourseDAL : Repository<Course>, ICourseDAL
    {
        protected readonly IDBFactory DbFactory;

        protected readonly IDBFactory SubDbFactory;
        public CourseDAL() : this(new DBFactory())
        {
            Course cus = new Course();
        }

        public CourseDAL(IDBFactory dbFactory)
            : base(dbFactory.Connection)
        {
            this.DbFactory = dbFactory;
        }

        public IEnumerable<Course> GetCourseAll()
        {
            return base.GetAll();
        }

        public SearchResult<Course> GetCourseJoin(SearchParameter search)
        {
            const string column = @"SELECT (SELECT Count(1) FROM CourseList WHERE CourseList.CourseID = Course.ID) AS TotalTopic
                                    ,Course.*
                                    ,MSCategory.Id AS MSCategoryID
                                    , MSCategory.*
                                    ,Employee.Id AS EmployeeID
                                    ,Employee.*";
            const string source = @"FROM Course LEFT JOIN MSCategory 
                                    ON MSCategory.ID = Course.CategoryID
                                    LEFT JOIN Employee
                                    ON Employee.ID = Course.UpdateBy";
            var result = new SearchResult<Course>();
            var query = search.CreateQuery(column,source);
            try
            {
                using (var multi = this.DbFactory.Connection.QueryMultiple(query))
                {
                    var count = multi.Read<int>().FirstOrDefault();
                    var resultList = multi.Read<Course, MSCategory,Employee , Course>((course,masterCategory,masterEmployee) => 
                    {
                        course.CatMaster = masterCategory;
                        course.EmpMaster = masterEmployee;
                        return course;
                    }, "MSCategoryID,EmployeeID");
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

        public SearchResult<Course> GetCourseSingle(SearchParameter search)
        {
            const string column = @"SELECT c.*";
            const string source = @"FROM Course ";
            var result = new SearchResult<Course>();
            var query = search.CreateQuery(column, source);
            try
            {
                using (var multi = this.DbFactory.Connection.QueryMultiple(query))
                {
                    var count = multi.Read<int>().FirstOrDefault();
                    var resultList = multi.Read<Course>(true);
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
