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
    [RoutePrefix("api/course")]
    public class CourseController : ApiController
    {
        private readonly ICourseBLL coursebll;
        public CourseController(ICourseBLL _coursebll)
        {
            this.coursebll = _coursebll;
        }
        [Route("getall")]
        [HttpGet]
        [AllowAnonymous]
        // GET api/<controller>
        public IHttpActionResult GetAll()
        {
            return Ok(coursebll.GetAll());
        }

        [Route("getDataWithJoin")]
        [HttpPost]
        [AllowAnonymous]
        public SearchResult<Course> Get([FromBody]SearchParameter search)
        {
            SearchResult<Course> results = coursebll.GetAllWithJoin(search);
            return results;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}