using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ESN.Dal.Infrastructure;
using ESN.Model;
using ESN.Util.Handler;

namespace ESN.Dal
{
    public class CategoryManagementDAL : Repository<MSCategory>, ICategoryManagementDAL
    {
        protected readonly IDBFactory DbFactory;

        protected readonly IDBFactory SubDbFactory;
        public CategoryManagementDAL() : this(new DBFactory())
        {
            MSCategory category = new MSCategory();
        }

        public CategoryManagementDAL(IDBFactory dbFactory) : base(dbFactory.Connection)
        {
            this.DbFactory = dbFactory;
        }

        public long AddMsCategoryDAL(MSCategory data)
        {
            return base.Insert(data);
        }

        public List<MSCategory> GetMsCategoryAll()
        {
            return base.GetAll().ToList();
        }

        public SearchResult<MSCategory> GetMSCategoryBySearch(SearchParameter search)
        {
            const string column = @"SELECT MSCATEGORY.ID
                                  ,MSCATEGORY.NAME_L1 AS NAME_L1
                            	  ,MSCATEGORY.NAME_L2 AS NAME_L2
                            	  ,MSCATEGORY.NAME_L3 AS NAME_L3
                            	  ,MSCATEGORY.NAME_L4 AS NAME_L4
                            	  ,MSCATEGORY.DESCRIPTION_L1 AS DESCRIPTION_L1
                            	  ,MSCATEGORY.DESCRIPTION_L2 AS DESCRIPTION_L2
                            	  ,MSCATEGORY.DESCRIPTION_L3 AS DESCRIPTION_L3
                            	  ,MSCATEGORY.DESCRIPTION_L4 AS DESCRIPTION_L4
                                  ,MSCATEGORY.EFFDATE AS EFFDATE
                                  ,MSCATEGORY.EXPDATE AS EXPDATE
                            	  ,CONVERT(VARCHAR, MSCATEGORY.EFFDATE, 101) AS EffDateShow
                            	  ,CONVERT(VARCHAR, MSCATEGORY.EXPDATE, 101) AS ExpDateShow
                            	  ,CONVERT(VARCHAR, MSCATEGORY.UPDATEDATE, 101) AS UpdateDate
                                  ,EMPLOYEE.Id AS EmpId
                            	  ,(EMPLOYEE.FIRSTNAME_L1 + EMPLOYEE.LASTNAME_L1) AS UpdateBy_L1
                            	  ,(EMPLOYEE.FIRSTNAME_L2 + EMPLOYEE.LASTNAME_L2) AS UpdateBy_L2
                            	  ,(EMPLOYEE.FIRSTNAME_L3 + EMPLOYEE.LASTNAME_L3) AS UpdateBy_L3
                            	  ,(EMPLOYEE.FIRSTNAME_L4 + EMPLOYEE.LASTNAME_L4) AS UpdateBy_L4";

            const string source = @"  FROM MSCATEGORY
                                    LEFT JOIN EMPLOYEE
	                                ON MSCATEGORY.UPDATEBY = EMPLOYEE.ID";
            var result = new SearchResult<MSCategory>();
            var query = search.CreateQuery(column, source);
            try
            {
                using (var multi = this.DbFactory.Connection.QueryMultiple(query))
                {
                    var count = multi.Read<int>().FirstOrDefault();
                    var resultList = multi.Read<MSCategory, Employee, MSCategory>((masterCategory, Employee) =>
                    {
                        return masterCategory;
                    }, "EmpId");
                    result.ResultList = resultList.AsQueryable();
                    result.TotalRecord = count;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }

        public MSCategory GetMSCategoryByIdDAL(int id)
        {
            return base.GetById(id);
        }

        public int UpdateMSCategoryDAL(MSCategory data)
        {
            return base.Update(data);
        }

        public int UpdatePriorityDAL(MSCategory data)
        {
            return base.Update(data);
        }
    }
}
