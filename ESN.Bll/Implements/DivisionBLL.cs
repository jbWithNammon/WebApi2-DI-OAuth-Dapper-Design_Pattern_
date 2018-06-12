using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESN.Dal;
using ESN.Model;

namespace ESN.Bll
{
    public class DivisionBLL : IDivisionBLL
    {
        protected readonly DivisionDAL divisionDAL;
        public DivisionBLL()
        {
            this.divisionDAL = new DivisionDAL();
        }
        public SearchResult<MSDivision> GetDivision(SearchParameter search)
        {
            return divisionDAL.GetDivision(search);
        }
    }
}