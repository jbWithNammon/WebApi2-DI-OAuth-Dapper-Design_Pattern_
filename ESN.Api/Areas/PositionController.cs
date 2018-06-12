using ESN.Bll;
using ESN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ESN.Api.Areas
{
    [RoutePrefix("api/position")]
    public class PositionController : ApiController
    {
        private readonly IPositionBLL positionbll;
        public PositionController(IPositionBLL _positionbll)
        {
            this.positionbll = _positionbll;
        }

        [Route("getPosition")]
        [HttpPost]
        [AllowAnonymous]
        public SearchResult<MSPosition> GetEmployee([FromBody]SearchParameter search)
        {
            SearchResult<MSPosition> results = positionbll.GetPosition(search);
            return results;
        }
    }
}