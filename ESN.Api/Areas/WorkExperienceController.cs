using ESN.Bll;
using ESN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ESN.Api.Areas
{
    [RoutePrefix("api/workExperice")]
    public class WorkExperienceController : ApiController
    {
        private readonly IWorkExperienceBLL workExperiencebll;
        public WorkExperienceController(IWorkExperienceBLL _workExperiencebll)
        {
            this.workExperiencebll = _workExperiencebll;
        }

        [Route("getWorkExperice")]
        [HttpPost]
        [AllowAnonymous]
        public SearchResult<MSWorkExperience> GetWorkExp([FromBody]SearchParameter search)
        {
            SearchResult<MSWorkExperience> results = workExperiencebll.GetWorkExp(search);
            return results;
        }
    }
}