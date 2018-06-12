using ESN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESN.Dal
{
    public interface IPositionDAL : IRepository<MSPosition>
    {
        SearchResult<MSPosition> GetPosition(SearchParameter search);
        void Dispose();
    }
}