using ESN.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ESN.Api.Areas
{

    [RoutePrefix("api/mediaType")]
    public class MediaTypeController : ApiController
    {
        private readonly IMediaTypeBLL mediaTypebll;

        public MediaTypeController(IMediaTypeBLL _mediaTypebll)
        {
            this.mediaTypebll = _mediaTypebll;
        }

        [Route("getMediaTypeAll")]
        [HttpGet]
        [AllowAnonymous]
        // GET api/<controller>
        public IHttpActionResult GetCourseList()
        {
            return Ok(mediaTypebll.GetAll());
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