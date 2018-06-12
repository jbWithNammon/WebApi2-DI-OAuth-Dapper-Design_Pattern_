using Dapper;
using ESN.Model.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ESN.Dal
{
    public static class QueryFactory
    {
        public static TModel SelectById<TModel, TKey>(this IDbConnection idb, TKey id, IDbTransaction tran)
        {
            try
            {
                string query = id.QuerySelectById<TModel, TKey>();
                return idb.QueryFirst<TModel>(query, null, tran);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Task<TModel> SelectByIdAsync<TModel, TKey>(this IDbConnection idb, TKey id, IDbTransaction tran)
        {
            try
            {
                string query = id.QuerySelectById<TModel, TKey>();
                return idb.QueryFirstAsync<TModel>(query, null, tran);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static IEnumerable<TModel> SelectList<TModel>(this IDbConnection idb, IDbTransaction tran)
        {
            try
            {
                string query = QuerySelectList<TModel>();
                return idb.Query<TModel>(query, null, tran);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static Task<IEnumerable<TModel>> SelectListAsync<TModel>(this IDbConnection idb, IDbTransaction tran)
        {
            try
            {
                string query = QuerySelectList<TModel>();
                return idb.QueryAsync<TModel>(query, null, tran);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static long AddModel<TModel>(this IDbConnection idb, TModel model, IDbTransaction tran)
        {
            try
            {
                string str = model.QueryInsert();
                return idb.Query<long>(str, null, tran).Single();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static Task<long> AddModelAsync<TModel>(this IDbConnection idb, TModel model, IDbTransaction tran)
        {
            try
            {
                string str = model.QueryInsert();
                return idb.QueryFirstAsync<long>(str, null, tran);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static int UpdateModel<TModel>(this IDbConnection idb, TModel model, IDbTransaction tran)
        {
            try
            {
                string str = model.QueryUpdate();
                return idb.Query<int>(str, null, tran).Single();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Task<bool> UpdateModelAsync<TModel>(this IDbConnection idb, TModel model, IDbTransaction tran)
        {
            try
            {
                string str = model.QueryUpdate();
                return idb.QueryFirstAsync<bool>(str, null, tran);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool DeleteById<TModel>(this IDbConnection idb, int id, IDbTransaction tran)
        {
            try
            {
                string str = id.QueryDeleteById<TModel>();
                idb.Query(str, null, tran);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Task<bool> DeleteByIdAsync<TModel>(this IDbConnection idb, int id, IDbTransaction tran)
        {
            try
            {
                string str = id.QueryDeleteById<TModel>();
                return idb.QueryFirstAsync<bool>(str);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool DeleteList<TModel>(this IDbConnection idb, TModel model, IDbTransaction tran)
        {
            try
            {
                string str = model.QueryDeleteList();
                idb.Query(str, null, tran);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static Task<bool> DeleteListAsync<TModel>(this IDbConnection idb, TModel model, IDbTransaction tran)
        {
            try
            {
                string str = model.QueryDeleteList();
                return idb.QueryFirstAsync<bool>(str, null, tran);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static int ExecNoResult(this IDbConnection idb, string query, IDbTransaction tran, object param = null)
        {
            try
            {
                return idb.Execute(query, param, tran);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Task<int> ExecNoResultAsync(this IDbConnection idb, string query, IDbTransaction tran, object param = null)
        {
            try
            {
                return idb.ExecuteAsync(query, param, tran);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static string QuerySelectById<TModel, TKey>(this TKey id)
        {
            string table = typeof(TModel).Name, condition = string.Empty;
            var properties = PrepareModel<TModel>();
            foreach (var item in properties)
            {
                condition = string.Format("{0} AND {1} = {2} ", condition, item.Key, id.ToString());
            }
            return string.Format("SELECT * FROM {0} WHERE 1=1 {1} ", table, condition);
        }
        private static string QuerySelectList<TModel>()
        {
            string table = typeof(TModel).Name, condition = string.Empty, value = string.Empty, key = string.Empty;
            try
            {
                //var properties = PrepareModel<TModel>();
                //foreach (var item in properties)
                //{
                //    if (item.Key == Constants.Keys)
                //    {
                //        var arr = item.Value.Split(Constants.split);
                //        condition = string.Format("{0} AND {1} = {2} ", condition, arr[0], arr[1]);
                //    }
                //    else
                //    {
                //        condition = string.Format("{0} AND {1} = {2} ", condition, item.Key, item.Value);
                //    }
                //}
                return string.Format("SELECT * FROM {0} WHERE 1=1 {1} ", table, condition);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        private static string QueryInsert<TModel>(this TModel model)
        {
            string table = typeof(TModel).Name, column = string.Empty, value = string.Empty;
            var properties = PrepareModel(model);
            foreach (var item in properties)
            {
                if (item.Key == Constants.Keys)
                {
                    var arr = item.Value.Split(Constants.split);
                    column = string.Concat(column, arr[0], ",");
                    value = string.Concat(value, arr[1], ",");
                }
                else
                {
                    column = string.Concat(column, item.Key, ",");
                    value = string.Concat(value, item.Value, ",");
                }
            }
            column = column.TrimEnd(',');
            value = value.TrimEnd(',');
            return string.Format("INSERT INTO {0} ({1}) VALUES ({2}) ;SELECT CAST(SCOPE_IDENTITY() as int) ", table, column, value);
        }
        private static string QueryUpdate<TModel>(this TModel model)
        {
            string table = typeof(TModel).Name, column = string.Empty, key = string.Empty;
            var listKey = new List<string>();
            var properties = PrepareModel(model);
            foreach (var item in properties)
            {
                if (item.Key == Constants.Keys)
                {
                    var arr = item.Value.Split(Constants.split);
                    key = string.Format("{0} AND {1} = {2} ", key, arr[0], arr[1]);
                    listKey.Add(arr[0]);
                }
                else
                {
                    bool fact = true;
                    foreach (string k in listKey)
                    {
                        if (item.Key == k)
                            fact = false;
                    }
                    if (fact)
                        column = string.Format("{0},{1} = {2} ", column, item.Key, item.Value);
                }
                column = column.TrimStart(',');
            }
            if (string.IsNullOrEmpty(key))
            {

                return string.Format("UPDATE {0} SET {1} WHERE 1=1 {2} ;SELECT CAST(COUNT(*) as int) FROM {0} WHERE 1=1 {2}", table, column, string.Format(" AND {0}=0", GetKey<TModel>()));
            }
            else
            {
                return string.Format("UPDATE {0} SET {1} WHERE 1=1 {2} ;SELECT CAST(COUNT(*) as int) FROM {0} WHERE 1=1 {2}", table, column, key);
            }
        }
        private static string QueryDeleteById<TModel>(this int id)
        {
            string table = typeof(TModel).Name, condition = string.Empty;
            var properties = PrepareModel<TModel>();
            foreach (var item in properties)
            {
                condition = string.Format("{0} AND {1} = {2} ", condition, item.Key, id.ToString());
            }
            return string.Format("DELETE FROM {0} WHERE 1=1 {1} ", table, condition);
        }
        private static string QueryDeleteList<TModel>(this TModel model)
        {
            string table = typeof(TModel).Name, condition = string.Empty, value = string.Empty, key = string.Empty;
            var properties = PrepareModel(model);
            foreach (var item in properties)
            {
                if (item.Key == Constants.Keys)
                {
                    var arr = item.Value.Split(Constants.split);
                    condition = string.Format("{0} AND {1} = {2} ", condition, arr[0], arr[1]);
                }
                else
                {
                    condition = string.Format("{0} AND {1} = {2} ", condition, item.Key, item.Value);
                }
            }
            return string.Format("DELETE FROM {0} WHERE 1=1 {1} ", table, condition);
        }
        private static Dictionary<string, string> PrepareModel<TModel>()
        {
            var result = new Dictionary<string, string>();
            try
            {
                PropertyInfo[] properties = typeof(TModel).GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    var attribute = Attribute.GetCustomAttribute(property, typeof(KeyAttribute))
                        as KeyAttribute;

                    if (attribute != null) // This property has a KeyAttribute
                    {
                        result.Add(property.Name, "");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }
        private static Dictionary<string, string> PrepareModel<TModel>(TModel model)
        {
            var result = new Dictionary<string, string>();
            string typeName = string.Empty;
            string[] type = { "DateTime", "Int32", "String", "Boolean" };
            try
            {
                PropertyInfo[] properties = model.GetType().GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    var attribute = Attribute.GetCustomAttribute(property, typeof(KeyAttribute))
                        as KeyAttribute;

                    if (attribute != null) // This property has a KeyAttribute
                    {
                        var key = property.GetValue(model);
                        if (property.PropertyType.Name == "Int32")
                        {
                            if ((int)key != 0)
                            {
                                result.Add(Constants.Keys, string.Format("{0}{2}{1}", property.Name, property.GetValue(model), Constants.split));
                            }
                        }
                        else if (property.PropertyType.Name == "String")
                        {
                            if (!string.IsNullOrEmpty((string)key))
                            {
                                result.Add(Constants.Keys, string.Format("{0}{2}{1}", property.Name, property.GetValue(model), Constants.split));
                            }
                        }
                    }
                    if (property.PropertyType.Name == "Nullable`1")
                    {
                        string _type = property.PropertyType.FullName.Split(',')[0];
                        typeName = _type.Split('[').Last().Replace("System.", "");
                    }
                    else
                    {
                        typeName = property.PropertyType.Name;
                    }
                    if (type.Any(t => t == typeName))
                    {
                        var value = property.GetValue(model);
                        if (typeName == "DateTime")
                        {
                            if (Convert.ToDateTime(value) != DateTime.MinValue && value != null)
                            {
                                result.Add(property.Name, string.Format("'{0}'", Convert.ToDateTime(value).ToString("yyyy-MM-dd HH:mm:ss")));
                            }
                        }
                        else if (property.PropertyType.Name == "Int32")
                        {
                            if ((int)value != 0)
                            {
                                result.Add(property.Name, Convert.ToInt32(value).ToString());
                            }

                        }
                        else if (typeName == "String")
                        {
                            if (!string.IsNullOrEmpty((string)value))
                            {
                                result.Add(property.Name, string.Format("'{0}'", value.ToString()));
                            }

                        }
                        else if (typeName == "Boolean")
                        {
                            //(bool)_value)

                            //    column = string.Concat(column, item.Name, ",");
                            //    value = string.Concat(value, _value.ToString(), ",");
                            //}

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
        private static string GetKey<TModel>()
        {
            PropertyInfo[] properties = typeof(TModel).GetProperties();
            string key = "ID";
            foreach (PropertyInfo property in properties)
            {
                var attribute = Attribute.GetCustomAttribute(property, typeof(KeyAttribute))
                    as KeyAttribute;
                if (attribute != null) // This property has a KeyAttribute
                {
                    key = property.Name;
                    break;
                }
            }
            return key;
        }
    }
}
