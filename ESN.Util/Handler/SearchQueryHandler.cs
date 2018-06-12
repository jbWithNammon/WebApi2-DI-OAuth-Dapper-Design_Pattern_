using ESN.Model;
using ESN.Model.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESN.Util.Handler
{
    public static class SearchQueryHandler
    {
        public static string CreateCondition(this IEnumerable<SearchCondition> condition)
        {
            string result = condition.Count() > 0 ? " WHERE 1=1 " : "";
            int beginId = 0;
            var group = new Dictionary<int, string>();
            try
            {
                foreach (var item in condition)
                {
                    if (item.GroupId != 0 && !group.ContainsKey(item.GroupId))
                    {
                        group.Add(item.GroupId, string.Empty);
                    }
                }
                foreach (SearchCondition item in condition)
                {
                    if (!group.ContainsKey(Origin.Int))
                    {
                        group.Add(Origin.Int, string.Empty);
                    }
                    
                    bool isJoiner = !string.IsNullOrEmpty(item.JoinerType);
                    string asemble = string.Format("{0} &#40; {1}.{2} ", item.JoinerType, item.TableName, item.FieldName);
                    asemble = string.Format("{0} {1}", asemble, item.OperatorType.CreateCase(item.LikePosition, item.Value));
                    if (item.GroupId.IsZero())
                    {
                        asemble = asemble.Replace("&#40;", string.Empty);
                        group[Origin.Int] = string.Format("{0} {1}", group[Origin.Int], asemble);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(group[item.GroupId]))
                        {
                            if (isJoiner)
                            {
                                beginId = beginId == 0 ? item.GroupId : beginId;
                                group[item.GroupId] = asemble.Replace("&#40;", "(");
                            }
                            else
                            {
                                beginId = beginId == 0 ? item.GroupId : beginId;
                                group[item.GroupId] = asemble.Replace("&#40;", string.Empty);
                            }
                        }
                        else
                        {
                            group[item.GroupId] = string.Format("{0} {1}", group[item.GroupId], asemble.Replace("&#40;", string.Empty));
                        }
                    }

                    ////string asemble = string.Empty;
                    //if (item.OperatorType.ToLower() == OperatorType.Like.GetAttrCode().ToLower())
                    //{
                    //    if(isJoiner&& item.GroupId != 0)
                    //    {
                    //        //bracket
                    //        asemble = string.Format("{0} &#40; {1}.{2} {3} '{4}'", item.JoinerType, item.TableName, item.FieldName, item.OperatorType, item.LikePosition);
                    //    }
                    //    else
                    //    {
                    //        asemble = string.Format("{0} {1}.{2} {3} '{4}'", item.JoinerType, item.TableName, item.FieldName, item.OperatorType, item.LikePosition);
                    //    }                        
                    //    asemble = string.Format(asemble, item.Value);
                    //}
                    //else
                    //{
                    //    if (isJoiner && item.GroupId != 0)
                    //    {
                    //        asemble = string.Format("{0} &#40; {1}.{2} {3} '{4}'", item.JoinerType, item.TableName, item.FieldName, item.OperatorType, item.Value);
                    //    }
                    //    else
                    //    {
                    //        asemble = string.Format("{0} {1}.{2} {3} '{4}'", item.JoinerType, item.TableName, item.FieldName, item.OperatorType, item.Value);
                    //    }                        
                    //}
                    //if (item.GroupId != 0)
                    //{
                    //    if (string.IsNullOrEmpty(group[item.GroupId]) && isJoiner)
                    //    {
                    //        group[item.GroupId] = group[item.GroupId].Replace("&#40;", "(");
                    //    }
                    //    else
                    //    {
                    //        group[item.GroupId] = group[item.GroupId].Replace("&#40;", "");
                    //    }
                    //    group[item.GroupId] = string.Format(" {0} {1}", group[item.GroupId], asemble);
                    //}
                    //else
                    //{
                    //    result = string.Format("{0} {1}", result, asemble);
                    //}                    
                }                
                result = string.Format("{0} {1}", result, group.FirstOrDefault(k => k.Key == beginId).Value);
                //if (!beginId.IsZero())
                //{
                //    result = string.Format("{0} {1}", result, ")");
                //}
                foreach (var item in group)
                {
                    if (item.Key != beginId)
                    {
                        result = string.Format("{0} {1}", result, item.Value);
                        if (!beginId.IsZero())
                        {
                            result = string.Format("{0} {1}", result, ")");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }

        public static string CreateCase(this string _operator, string position, object value)
        {
            string result = string.Empty;
            try
            {
                if (_operator.ToLower() == OperatorType.Like.GetAttrCode().ToLower())
                {
                    result = string.Format("{0} '{1}'", _operator, position);
                    result = string.Format(result, value);
                }
                else
                {
                    result = string.Format("{0} '{1}'", _operator, value);
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string CreateOrdering(this SearchParameter search)
        {
            string result = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(search.SortTable) && !string.IsNullOrEmpty(search.SortColumn))
                {
                    result = string.Format("ORDER BY {0}.{1} {2}", search.SortTable, search.SortColumn, search.SortAscending ? " ASC " : " DESC ");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }

        public static string CreateOffSet(this SearchParameter search)
        {
            string result = string.Format("OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY", search.Page, search.ItemsPerPage);
            return result;
        }
        public static string CreateQuery(this SearchParameter search, string column, string source)
        {
            string result = string.Empty;
            try
            {
                string condition = search.ConditionList.CreateCondition();
                string ordering = search.CreateOrdering();
                string offset = search.CreateOffSet();
                result = string.Format("SELECT COUNT(*) AS TotalRecord {0} {1}; {2} {3} {4} {5} {6}", source, condition, column, source, condition, ordering, offset);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
