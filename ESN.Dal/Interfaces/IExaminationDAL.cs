using ESN.Model;
using System.Collections.Generic;

namespace ESN.Dal
{
    public interface IExaminationDAL : IRepository<Examination>
    {
        List<Examination> GETExaminationAllDAL();
        void Dispose();
    }
}
