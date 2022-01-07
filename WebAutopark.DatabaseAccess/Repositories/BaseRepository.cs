using Microsoft.Data.SqlClient;
using System.Data.Common;
using WebAutopark.Core.Interfaces;

namespace WebAutopark.DatabaseAccess.Repositories
{
    public abstract class BaseRepository : IDisposable
    {
        protected readonly DbConnection Connection;

        protected BaseRepository(IConnectionStringProvider connectionStringProvider)
        {
            Connection = new SqlConnection(connectionStringProvider.GetConnectionString());
        }

        public void Dispose() => Connection.Dispose();
    }
}
