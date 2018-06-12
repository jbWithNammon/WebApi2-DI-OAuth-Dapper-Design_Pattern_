using ESN.Bll;
using ESN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ESN.Api.Areas
{
    [RoutePrefix("api/department")]
    public class DepartmentController : ApiController
    {
        private readonly IDepartmentBLL departmentbll;
        public DepartmentController(IDepartmentBLL _departmentbll)
        {
            this.departmentbll = _departmentbll;
        }

        [Route("getDepartment")]
        [HttpPost]
        [AllowAnonymous]
        public SearchResult<MSDepartment> GetDepartment([FromBody]SearchParameter search)
        {
            SearchResult<MSDepartment> results = departmentbll.GetDepartment(search);
            return results;
        }
    }
}