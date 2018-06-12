using ESN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESN.Bll
{
    public interface ICourseListBLL
    {
        IEnumerable<CourseList> GetAll();
        SearchResult<CourseList> GetCourseListByID(SearchParameter search);
        SearchResult<CourseList> GetTotalTopic();
        SearchResult<CourseList> GetCourseListSingle(SearchParameter search);
        bool deleteCourseList(int id);
    }
}
