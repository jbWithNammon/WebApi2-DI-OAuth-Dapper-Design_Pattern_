using ESN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESN.Dal
{
    public interface ICourseListDAL : IRepository<CourseList>
    {
        IEnumerable<CourseList> GetCourseListAll();
        SearchResult<CourseList> GetCourseListByID(SearchParameter search);
        SearchResult<CourseList> GetCourseListSingle(SearchParameter search);
        SearchResult<CourseList> GetTotalTopic();
        void Dispose();
    }
}
