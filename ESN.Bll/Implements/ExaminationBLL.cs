using ESN.Dal;
using ESN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESN.Bll
{
    public class ExaminationBLL : IExaminationBLL
    {
        protected readonly ExaminationDAL examinationDAL;
        public ExaminationBLL()
        {
            this.examinationDAL = new ExaminationDAL();
        }
        public List<Examination> GETExaminationAllDAL()
        {
            return this.examinationDAL.GETExaminationAllDAL();
        }
    }
}
