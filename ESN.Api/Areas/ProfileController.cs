using ESN.Bll;
using ESN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ESN.Api.Areas
{
    [RoutePrefix("api/profile")]
    public class ProfileController : ApiController
    {
        public IProfileBLL profileBLL;
        public ProfileController(IProfileBLL _profilebll)
        {
            this.profileBLL = _profilebll;
        }
        [Route("getCourseListListData")]
        [HttpPost]
        [AllowAnonymous]
        public SearchResult<MSCourseSort> getCourseSortList([FromBody]SearchParameter search)
        {
            SearchResult<MSCourseSort> results = profileBLL.GetMSCourseSortList(search);
            return results;
        }

        [Route("getCategoryListData")]
        [HttpPost]
        [AllowAnonymous]
        public SearchResult<MSCategory> getCategoryList([FromBody]SearchParameter search)
        {
            SearchResult<MSCategory> results = profileBLL.GetMSCategoryList(search);
            return results;
        }


    }
}