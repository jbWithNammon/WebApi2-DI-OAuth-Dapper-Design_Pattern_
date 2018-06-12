using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESN.Dal;
using ESN.Model;

namespace ESN.Bll
{
    public class PositionBLL : IPositionBLL
    {
        protected readonly PositionDAL positionDAL;
        public PositionBLL()
        {
            this.positionDAL = new PositionDAL();
        }
        public SearchResult<MSPosition> GetPosition(SearchParameter search)
        {
            return positionDAL.GetPosition(search);
        }
    }
}