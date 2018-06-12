using ESN.Dal;
using ESN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESN.Bll
{
    public class CourseBLL : ICourseBLL
    {
        protected readonly ICourseDAL courseDAL;
        public CourseBLL()
        {
            this.courseDAL = new CourseDAL();
        }

        public IEnumerable<Course> GetAll()
        {
            return courseDAL.GetAll();
        }

        public SearchResult<Course> GetAllWithJoin(SearchParameter search)
        {
            return courseDAL.GetCourseJoin(search);
        }
    }
}
