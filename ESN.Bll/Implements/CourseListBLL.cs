using ESN.Dal;
using ESN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESN.Bll
{
    public class CourseListBLL : ICourseListBLL
    {
        protected readonly ICourseListDAL courseListDAL;
        public CourseListBLL()
        {
            this.courseListDAL = new CourseListDAL();
        }

        public bool deleteCourseList(int id)
        {
            return courseListDAL.DeleteById(id);
        }

        public IEnumerable<CourseList> GetAll()
        {
            return courseListDAL.GetAll();
        }

        public SearchResult<CourseList> GetTotalTopic()
        {
            return courseListDAL.GetTotalTopic();
        }

        public SearchResult<CourseList> GetCourseListByID(SearchParameter search)
        {
            return courseListDAL.GetCourseListByID(search);
        }

        public SearchResult<CourseList> GetCourseListSingle(SearchParameter search)
        {
            return courseListDAL.GetCourseListSingle(search);
        }
    }
}