using ESN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESN.Dal
{
    public interface IDivisionDAL : IRepository<MSDivision>
    {
        SearchResult<MSDivision> GetDivision(SearchParameter search);
        void Dispose();
    }
}