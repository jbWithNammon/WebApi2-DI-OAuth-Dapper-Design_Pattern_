using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESN.Dal;
using ESN.Model;

namespace ESN.Bll
{
    public class WorkExperienceBLL : IWorkExperienceBLL
    {
        protected readonly WorkExperienceDAL workExpDAL;
        public WorkExperienceBLL()
        {
            this.workExpDAL = new WorkExperienceDAL();
        }
        public SearchResult<MSWorkExperience> GetWorkExp(SearchParameter search)
        {
            return workExpDAL.GetWorkExp(search);
        }
    }
}