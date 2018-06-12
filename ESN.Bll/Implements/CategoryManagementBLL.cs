using ESN.Dal;
using ESN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESN.Bll
{
    public class CategoryManagementBLL: ICategoryManagementBLL
    {
        protected readonly ICategoryManagementDAL CategoryManagementDAL;
        public CategoryManagementBLL()
        {
            this.CategoryManagementDAL = new CategoryManagementDAL();
        }

        public long AddMsCategoryBLL(MSCategory data)
        {
            return this.CategoryManagementDAL.AddMsCategoryDAL(data);
        }

        public List<MSCategory> GetMSCategoriesAll()
        {
            return this.CategoryManagementDAL.GetMsCategoryAll();
        }

        public SearchResult<MSCategory> GetMSCategoryBySearch(SearchParameter search)
        {
            return this.CategoryManagementDAL.GetMSCategoryBySearch(search);
        }

        public MSCategory GetMSCategoryByIdBLL(int id)
        {
            return this.CategoryManagementDAL.GetMSCategoryByIdDAL(id);
        }

        public int UpdateMSCategoryBLL(MSCategory data)
        {
            return this.CategoryManagementDAL.UpdateMSCategoryDAL(data);
        }

        public int UpdatePriorityBLL(MSCategory data)
        {
            return this.CategoryManagementDAL.UpdatePriorityDAL(data);
        }
    }
}
