using ESN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESN.Dal
{
    public interface IWorkExperienceDAL : IRepository<MSWorkExperience>
    {
        SearchResult<MSWorkExperience> GetWorkExp(SearchParameter search);
        void Dispose();
    }
}