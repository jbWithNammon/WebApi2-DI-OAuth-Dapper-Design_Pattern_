using ESN.Model;
using System.Collections.Generic;

namespace ESN.Dal
{
    public interface ICategoryManagementDAL : IRepository<MSCategory>
    {
        SearchResult<MSCategory> GetMSCategoryBySearch(SearchParameter search);

        List<MSCategory> GetMsCategoryAll();
        MSCategory GetMSCategoryByIdDAL(int id);
        long AddMsCategoryDAL(MSCategory data);
        int UpdateMSCategoryDAL(MSCategory data);
        int UpdatePriorityDAL(MSCategory data);

        void Dispose();
    }
}
