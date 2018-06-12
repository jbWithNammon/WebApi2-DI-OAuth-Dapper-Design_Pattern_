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
    [RoutePrefix("api/courseList")]
    public class CourseListController : ApiController
    {
        private readonly ICourseListBLL courseListbll;

        public CourseListController(ICourseListBLL _courseListbll)
        {
            this.courseListbll = _courseListbll;
        }

        [Route("getCourseListByID")]
        [HttpPost]
        [AllowAnonymous]
        public SearchResult<CourseList> GetByID([FromBody]SearchParameter search)
        {
            SearchResult<CourseList> results = courseListbll.GetCourseListByID(search);
            return results;
        }

        [Route("getCourseListSingle")]
        [HttpPost]
        [AllowAnonymous]
        public SearchResult<CourseList> GetAllSingle([FromBody]SearchParameter search)
        {
            SearchResult<CourseList> results = courseListbll.GetCourseListSingle(search);
            return results;
        }

        [Route("getTotalTopic")]
        [HttpGet]
        [AllowAnonymous]
        public SearchResult<CourseList> GetTotalTopic()
        {
            SearchResult<CourseList> results = courseListbll.GetTotalTopic();
            return results;
        }

        [Route("getCourseList")]
        [HttpGet]
        [AllowAnonymous]
        // GET api/<controller>
        public IHttpActionResult GetCourseList(string id)
        {
            return Ok(courseListbll.GetAll());
        }

        [Route("deleteCourseList")]
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult DeleteCourseList([FromBody]int id)
        {
            return Ok(courseListbll.deleteCourseList(id));
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