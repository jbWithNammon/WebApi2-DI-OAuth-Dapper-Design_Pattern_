using ESN.Dal;
using ESN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESN.Bll
{
    public class CourseContentBLL : ICourseContentBLL
    {
        protected readonly ICourseContentDAL courseContentDAL;
        public CourseContentBLL()
        {
            this.courseContentDAL = new CourseContentDAL();
        }
        public IEnumerable<CourseContent> GetAll()
        {
            return courseContentDAL.GetAll();
        }

        public SearchResult<CourseContent> GetCourseContentByID(SearchParameter search)
        {
            return courseContentDAL.GetCourseContentByID(search);
        }
    }
}
