using ESN.Bll;
using ESN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ESN.Api.Areas
{
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeBLL employeebll;
        public EmployeeController(IEmployeeBLL _employeebll)
        {
            this.employeebll = _employeebll;
        }

        [Route("getEmployee")]
        [HttpPost]
        [AllowAnonymous]
        public SearchResult<Employee> GetEmployee([FromBody]SearchParameter search)
        {
            SearchResult<Employee> results = employeebll.GetEmployee(search);
            return results;
        }
    }
}