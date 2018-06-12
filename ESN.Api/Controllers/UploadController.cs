using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ESN.Api.Controllers
{
    public class UploadController : ApiController
    {
        [Route("api/upload/uploadlarge")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IHttpActionResult> UploadLarge()
        {
            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);

            // extract file name and file contents
            var fileNameParam = provider.Contents[0].Headers.ContentDisposition.Parameters;
            bool result = true;
            return Ok(result);
        }

        [Route("api/upload/uploadrequest")]
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult UploadRequest(string data)
        {

            var file = Request.Content;
            bool result = true;
            return Ok(result);
        }

        [Route("api/upload/getrequest")]
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetRequest()
        {

            var file = Request.Content;
            bool result = true;
            return Ok(result);
        }
    }
}
