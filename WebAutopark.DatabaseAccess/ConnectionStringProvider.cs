using Microsoft.Extensions.Configuration;
using WebAutopark.Core.Interfaces;

namespace WebAutopark.DatabaseAccess
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private readonly string _connectionString;

        public ConnectionStringProvider(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("WebAutoparkDbConnection");
        }

        public string GetConnectionString() => _connectionString;
    }
}
