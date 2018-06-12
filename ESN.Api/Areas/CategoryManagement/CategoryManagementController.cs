using ESN.Bll;
using ESN.Model;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;

namespace ESN.Api.Areas.CategoryManagement
{
    [RoutePrefix("api/categortManagement")]
    public class CategoryManagementController : ApiController
    {
        public ICategoryManagementBLL CatManagebll;
        public CategoryManagementController(ICategoryManagementBLL _CatManagebll)
        {
            this.CatManagebll = _CatManagebll;
        }
        [Route("getListData")]
        [HttpPost]
        [AllowAnonymous]
        public SearchResult<MSCategory> Get([FromBody]SearchParameter search)
        {
            SearchResult<MSCategory> results = CatManagebll.GetMSCategoryBySearch(search);
            return results;
        }

        [Route("getListAll")]
        [HttpGet]
        [AllowAnonymous]
        public List<MSCategory> GetListAll()
        {
            List<MSCategory> results = CatManagebll.GetMSCategoriesAll();
            return results;
        }

        [Route("getByID")]
        [HttpGet]
        [AllowAnonymous]
        public MSCategory Get(int id)
        {
            MSCategory result = new MSCategory();
            if (id != 0)
            {
                result = CatManagebll.GetMSCategoryByIdBLL(id);
            }
            return result;
        }

        // POST api/values
        [Route("addMSCategory")]
        [HttpPost]
        [AllowAnonymous]
        public long Add([FromBody]MSCategory value)
        {
            return CatManagebll.AddMsCategoryBLL(value);
        }

        // POST api/values
        [Route("updateMSCategory")]
        [HttpPost]
        [AllowAnonymous]
        public long Update([FromBody]MSCategory value)
        {
            return CatManagebll.UpdateMSCategoryBLL(value);
        }

        // POST api/values
        [Route("piority")]
        [HttpPost]
        [AllowAnonymous]
        public long PriorityUp([FromBody]MSCategory value)
        {
            return CatManagebll.UpdatePriorityBLL(value);
        }
    }
}
