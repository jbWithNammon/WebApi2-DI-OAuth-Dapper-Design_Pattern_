using ESN.Bll;
using ESN.Model;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;

namespace ESN.Api.Areas.CategoryManagement
{
    [RoutePrefix("api/examination")]
    public class ExaminationController : ApiController
    {
        public IExaminationBLL examinationBLL;
        public ExaminationController (IExaminationBLL _examinationBLL)
        {
            this.examinationBLL = _examinationBLL;
        }
        [Route("getListData")]
        [HttpGet]
        [AllowAnonymous]
        public List<Examination> Get()
        {
            List<Examination> results = examinationBLL.GETExaminationAllDAL();
            return results;
        }

        //[Route("getByID")]
        //[HttpGet]
        //[AllowAnonymous]
        //public MSCategory Get(int id)
        //{
        //    MSCategory result = new MSCategory();
        //    if (id != 0)
        //    {
        //        result = CatManagebll.GetById(id);
        //    }
        //    return result;
        //}

        //// POST api/values
        //[Route("addMSCategory")]
        //[HttpPost]
        //[AllowAnonymous]
        //public long Add([FromBody]MSCategory value)
        //{
        //    return CatManagebll.Insert(value);
        //}
    }
}
