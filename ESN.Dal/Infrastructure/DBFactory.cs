using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESN.Dal.Infrastructure
{
    public interface IDBFactory
    {
        IDbConnection Connection { get; }
    }
    public class DBFactory : IDBFactory
    {
        private IDbConnection _connection;

        public IDbConnection Connection
        {
            get { return this._connection ?? (this._connection = this.CreateClientConnection()); }
        }
        public IDbConnection CreateClientConnection()
        {
            const string connectionStringName = "DefaultConnection";
            return CreateConnection(connectionStringName);
        }
        private static IDbConnection CreateConnection(string connectionStringName)
        {
            if (string.IsNullOrEmpty(connectionStringName))
                throw new System.ArgumentNullException("connectionStringName");

            var connectionString = Util.Helpers.ConfigurationHelper.GetConnectString(connectionStringName);

            if (string.IsNullOrEmpty(connectionString))
                throw new System.NullReferenceException("The 'database connection string' argument cannot be null or empty.");

            IDbConnection result = new SqlConnection(connectionString);
            return result;
        }
    }
}
