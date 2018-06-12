using ESN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESN.Bll
{
    public interface ICourseContentBLL
    {
        IEnumerable<CourseContent> GetAll();
        SearchResult<CourseContent> GetCourseContentByID(SearchParameter search);
    }
}
