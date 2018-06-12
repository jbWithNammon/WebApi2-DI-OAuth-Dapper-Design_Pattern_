using ESN.Bll;
using ESN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ESN.Api.Areas
{
    [RoutePrefix("api/courseContent")]
    public class CourseContentController : ApiController
    {
        private readonly ICourseContentBLL courseContentbll;
        public CourseContentController(ICourseContentBLL _courseContentbll)
        {
            this.courseContentbll = _courseContentbll;
        }

        [Route("getall")]
        [HttpGet]
        [AllowAnonymous]
        // GET api/<controller>
        public IHttpActionResult GetAll()
        {
            return Ok(courseContentbll.GetAll());
        }

        [Route("getCourseContentByID")]
        [HttpPost]
        [AllowAnonymous]
        public SearchResult<CourseContent> GetByID([FromBody]SearchParameter search)
        {
            SearchResult<CourseContent> results = courseContentbll.GetCourseContentByID(search);
            return results;
        }
    }
}