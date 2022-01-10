using Dapper;
using System.Collections.Generic;
using WebAutopark.Core.Entities;
using WebAutopark.Core.Interfaces;

namespace WebAutopark.DatabaseAccess.Repositories
{
    public class OrderItemRepository : BaseRepository, IRepository<OrderItem>
    {
        private const string QueryCreate = "INSERT INTO OrderItems (OrderId, ComponentId, Quantity) " +
                                              "VALUES (@OrderId, @ComponentId, @Quantity)";

        private const string QueryDelete = "DELETE FROM OrderItems WHERE OrderItemId = @id";

        private const string QueryGetById = "SELECT * FROM OrderItems WHERE OrderItemId = @id";

        private const string QueryGetAll = "SELECT * FROM OrderItems";

        private const string QueryUpdate = "UPDATE OrderItems SET " +
                                              "OrderId = @OrderId, " +
                                              "ComponentId = @ComponentId, " +
                                              "Quantity = @Quantity " +
                                              "WHERE OrderItemId = @OrderItemId";

        public OrderItemRepository(IConnectionStringProvider connectionStringProvider) :
            base(connectionStringProvider)
        { }

        public void Create(OrderItem item) => Connection.Execute(QueryCreate, item);

        public void Delete(int id) => Connection.Execute(QueryDelete, new { id });

        public void Update(OrderItem item) => Connection.Execute(QueryUpdate, item);

        public IEnumerable<OrderItem> GetAllItems() => Connection.Query<OrderItem>(QueryGetAll);

        public OrderItem GetItem(int id) => Connection.QueryFirstOrDefault<OrderItem>(QueryGetById, new { id });
    }
}
