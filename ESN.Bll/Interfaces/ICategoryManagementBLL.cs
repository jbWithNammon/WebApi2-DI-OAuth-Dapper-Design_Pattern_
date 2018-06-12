using ESN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESN.Bll
{
    public interface ICategoryManagementBLL
    {
        SearchResult<MSCategory> GetMSCategoryBySearch(SearchParameter search);

        List<MSCategory> GetMSCategoriesAll();
        MSCategory GetMSCategoryByIdBLL(int id);
        long AddMsCategoryBLL(MSCategory data);
        int UpdateMSCategoryBLL(MSCategory data);
        int UpdatePriorityBLL(MSCategory data);
    }
}
