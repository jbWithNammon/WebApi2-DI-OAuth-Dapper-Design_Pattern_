using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESN.Dal
{
    public interface IRepository<T> : IRepository<T, object>
 where T : class
    {
    }
    public interface IRepository<T, in TKey>
        where T : class
    {

        IEnumerable<T> GetAll();

        Task<IEnumerable<T>> GetAllAsync();

        T GetById(TKey id);

        Task<T> GetByIdAsync(TKey id);

        long Insert(T model);

        Task<long> InsertAsync(T model);

        int Update(T model);

        Task<bool> UpdateAsync(T model);

        bool DeleteById(int id);

        Task<bool> DeleteByIdAsync(int id);

        bool DeleteList(T model);

        Task<bool> DeleteListAsync(T model);

        int ExecNoResult(string query, object param = null);

        Task<int> ExecNoResultAsync(string query, object param = null);
    }

    public class Repository<T> : Repository<T, object>, IRepository<T> where T : class
    {
        public Repository(IDbConnection connection)
            : this(connection, null)
        {
        }

        public Repository(IDbConnection connection, IDbTransaction transaction = null)
            : base(connection, transaction)
        {
        }
    }

    public class Repository<T, TKey> : IRepository<T, TKey>, IDisposable where T : class
    {
        private const string DapperExecutionTimeout = "DapperExecutionTimeout";

        private readonly IDbConnection _connection;

        private readonly IDbTransaction _transaction;

        public string ExceptionMessage
        {
            get;
            set;
        }

        public Repository(IDbConnection connection)
            : this(connection, null)
        {
        }

        public Repository(IDbConnection connection, IDbTransaction transaction = null)
        {
            _connection = connection;
            _transaction = transaction;

            // Load value of DapperCommandTimeout from appSettings.
            var dapperTimeout = GetAppSettingValue<int>(DapperExecutionTimeout);

            // Set the command timeout for execution to 60 minutes, if have no app setting for DapperExecutionTimeout.
            if (dapperTimeout <= 0)
                dapperTimeout = 3600;

            // Specifies the default Command Timeout for all Queries. 
            SqlMapper.Settings.CommandTimeout = dapperTimeout;
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                EnsureDBOpen();
                return _connection.SelectList<T>(_transaction);
            }
            finally
            {
                EnsureDBClose();
            }
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                EnsureDBOpen();
                return _connection.SelectListAsync<T>(_transaction);
            }
            finally
            {
                EnsureDBClose();
            }
        }

        public T GetById(TKey id)
        {
            try
            {
                EnsureDBOpen();
                return _connection.SelectById<T, TKey>(id, _transaction);
            }
            finally
            {
                EnsureDBClose();
            }
        }

        public Task<T> GetByIdAsync(TKey id)
        {
            try
            {
                EnsureDBOpen();
                return _connection.SelectByIdAsync<T, TKey>(id, _transaction);
            }
            finally
            {
                EnsureDBClose();
            }
        }

        public long Insert(T model)
        {
            try
            {
                EnsureDBOpen();
                return _connection.AddModel(model, _transaction);
            }
            finally
            {
                EnsureDBClose();
            }
        }

        public Task<long> InsertAsync(T model)
        {
            try
            {
                EnsureDBOpen();
                return _connection.AddModelAsync(model, _transaction);
            }
            finally
            {
                EnsureDBClose();
            }
        }

        public int Update(T model)
        {
            try
            {
                EnsureDBOpen();
                return _connection.UpdateModel(model, _transaction);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<bool> UpdateAsync(T model)
        {
            try
            {
                EnsureDBOpen();
                return _connection.UpdateModelAsync(model, _transaction);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteById(int id)
        {
            try
            {
                EnsureDBOpen();
                return _connection.DeleteById<T>(id, _transaction);
            }
            finally
            {
                EnsureDBClose();
            }
        }

        public Task<bool> DeleteByIdAsync(int id)
        {
            try
            {
                EnsureDBOpen();
                return _connection.DeleteByIdAsync<T>(id, _transaction);
            }
            finally
            {
                EnsureDBClose();
            }
        }

        public bool DeleteList(T model)
        {
            try
            {
                EnsureDBOpen();
                return _connection.DeleteList(model, _transaction);
            }
            finally
            {
                EnsureDBClose();
            }
        }

        public Task<bool> DeleteListAsync(T model)
        {
            try
            {
                EnsureDBOpen();
                return _connection.DeleteListAsync(model, _transaction);
            }
            finally
            {
                EnsureDBClose();
            }
        }

        public int ExecNoResult(string query, object param = null)
        {
            try
            {
                EnsureDBOpen();
                return _connection.ExecNoResult(query, _transaction, param);
            }
            finally
            {
                EnsureDBClose();
            }
        }

        public Task<int> ExecNoResultAsync(string query, object param = null)
        {
            try
            {
                EnsureDBOpen();
                return _connection.ExecNoResultAsync(query, _transaction, param);
            }
            finally
            {
                EnsureDBClose();
            }
        }
        #region IDisposable Support
        /// <summary>
        /// The disposed value.
        /// </summary>
        private bool _disposedValue; // To detect redundant calls
        /// <summary>
        /// The dispose.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue) return;
            if (disposing)
            {
                if (_connection != null && _connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                }
            }

            // free unmanaged resources (unmanaged objects) and override a finalizer below.
            // set large fields to null.
            _disposedValue = true;
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);

            // uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }

        #endregion

        private string GetAppSetting(string settingName)
        {
            string result = string.Empty;

            try
            {
                if (ConfigurationManager.AppSettings[settingName] != null)
                    result = ConfigurationManager.AppSettings[settingName];
            }
            catch (Exception)
            {
                result = string.Empty;
            }

            return result;
        }


        private TValue GetAppSettingValue<TValue>(string settingName)
        {
            try
            {
                var appSettingValue = GetAppSetting(settingName);
                var converter = TypeDescriptor.GetConverter(typeof(TValue));

                if (!string.IsNullOrEmpty(appSettingValue))
                    return (TValue)converter.ConvertFromInvariantString(appSettingValue);

                return default(TValue);
            }
            catch (Exception)
            {
                return default(TValue);
            }
        }

        private void EnsureDBOpen()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
        }
        private void EnsureDBClose()
        {
            if (_connection.State != ConnectionState.Closed)
            {
                _connection.Close();
            }
        }

    }
}
