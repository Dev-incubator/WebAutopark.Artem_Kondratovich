using Dapper;
using System.Collections.Generic;
using WebAutopark.Core.Entities;
using WebAutopark.Core.Interfaces;

namespace WebAutopark.DatabaseAccess.Repositories
{
    public class OrderRepository : BaseRepository, IRepository<Order>
    {
        private const string QueryCreate = "INSERT INTO Orders (VehicleId) VALUES (@VehicleId)";

        private const string QueryDelete = "DELETE FROM Orders WHERE OrdersId = @id";

        private const string QueryGetById = "SELECT * FROM Orders WHERE OrdersId = @id";

        private const string QueryGetAll = "SELECT * FROM Orders";

        private const string QueryUpdate = "UPDATE Orders SET VehicleId = @VehicleId WHERE OrdersId = @OrdersId";

        public OrderRepository(IConnectionStringProvider connectionStringProvider) :
            base(connectionStringProvider)
        { }

        public void Create(Order item) => Connection.Execute(QueryCreate, item);

        public void Delete(int id) => Connection.Execute(QueryDelete, new { id });

        public void Update(Order item) => Connection.Execute(QueryUpdate, item);

        public IEnumerable<Order> GetAllItems() => Connection.Query<Order>(QueryGetAll);

        public Order GetItem(int id) => Connection.QueryFirstOrDefault<Order>(QueryGetById, new { id });
    }
}
