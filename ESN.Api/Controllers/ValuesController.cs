using ESN.Bll;
using ESN.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ESN.Api.Controllers
{
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        private readonly IProductBLL custbll;
        public ValuesController(IProductBLL _custbll)
        {
            this.custbll = _custbll;
        }
        [Route("upload")]
        [HttpPost]
        [AllowAnonymous]
        public void UploadFile()
        {
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                // Get the uploaded image from the Files collection
                var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];

                if (httpPostedFile != null)
                {
                    // Validate the uploaded image(optional)

                    // Get the complete file path
                    var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/UploadedFiles"), httpPostedFile.FileName);

                    // Save the uploaded file to "UploadedFiles" folder
                    httpPostedFile.SaveAs(fileSavePath);
                }
            }
        }

        //[Route("api/values/upload")]
        //[HttpPost]
        //[AllowAnonymous]
        //public IHttpActionResult Upload(byte[] val)
        //{
        //    //var bytes = System.Text.Encoding.UTF8.GetBytes(val);
        //    string path = @"D:\temp\pic.jpeg";
        //    string path1 = @"D:\temp\vid.mp4";
        //    //bool result =  custbll.SaveByteArrayAsImage(path, file.Value);
        //    bool result = custbll.SaveByteArrayAsVideo(path1, val);
        //    var response = "";
        //    return Ok(response);
        //}

        [HttpGet]
        [Route("api/GetUserClaimsValues")]
        public AccountModel GetUserClaims()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;
            AccountModel model = new AccountModel()
            {
                UserName = identityClaims.FindFirst("Username").Value,
                Email = identityClaims.FindFirst("Email").Value,
                FirstName = identityClaims.FindFirst("FirstName").Value,
                LastName = identityClaims.FindFirst("LastName").Value,
                LoggedOn = identityClaims.FindFirst("LoggedOn").Value
            };
            return model;
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            string result = custbll.GetTest();
            return new string[] { result, result };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
