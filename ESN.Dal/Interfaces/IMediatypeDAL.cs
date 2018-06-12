using ESN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESN.Dal
{
    public interface IMediaTypeDAL : IRepository<MSMediaType>
    {
        IEnumerable<MSMediaType> GetMediaTypeAll();
        void Dispose();
    }
}
