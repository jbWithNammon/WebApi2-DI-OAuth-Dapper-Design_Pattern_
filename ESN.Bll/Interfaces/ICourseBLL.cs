using ESN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESN.Bll
{
    public interface ICourseBLL
    {
        IEnumerable<Course> GetAll();
        SearchResult<Course> GetAllWithJoin(SearchParameter search);
    }
}
