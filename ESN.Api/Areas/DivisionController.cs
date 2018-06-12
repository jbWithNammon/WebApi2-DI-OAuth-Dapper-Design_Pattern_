using ESN.Bll;
using ESN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ESN.Api.Areas
{
    [RoutePrefix("api/division")]
    public class DivisionController : ApiController
    {
        private readonly IDivisionBLL divisionbll;
        public DivisionController(IDivisionBLL _divisionbll)
        {
            this.divisionbll = _divisionbll;
        }

        [Route("getDivision")]
        [HttpPost]
        [AllowAnonymous]
        public SearchResult<MSDivision> GetEmployee([FromBody]SearchParameter search)
        {
            SearchResult<MSDivision> results = divisionbll.GetDivision(search);
            return results;
        }
    }
}