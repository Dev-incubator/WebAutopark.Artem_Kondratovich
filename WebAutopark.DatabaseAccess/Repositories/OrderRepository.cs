using Dapper;
using System.Collections.Generic;
using WebAutopark.Core.Entities;
using WebAutopark.Core.Interfaces;
using WebAutopark.Core.Interfaces.Repositories;

namespace WebAutopark.DatabaseAccess.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        private const string QueryCreate = "INSERT INTO Orders (VehicleId, Date) VALUES (@VehicleId, @Date)";

        private const string QueryCreateAndReturnId = "INSERT INTO Orders (VehicleId, Date) VALUES (@VehicleId, @Date) SELECT CAST(SCOPE_IDENTITY() as int)";

        private const string QueryDelete = "DELETE FROM Orders WHERE OrdersId = @id";

        private const string QueryGetById = "SELECT o.*, v.VehicleId as VehId, v.Model, v.RegistrationNumber " +
                                              "FROM Orders o " +
                                              "INNER JOIN Vehicles v " +
                                              "ON o.VehicleId = v.VehicleId " +
                                              "WHERE OrdersId = @id";

        private const string QueryGetAll = "SELECT o.*, v.VehicleId as VehId, v.Model, v.RegistrationNumber " +
                                             "FROM Orders o " +
                                             "INNER JOIN Vehicles v " +
                                             "ON o.VehicleId = v.VehicleId";

        private const string QueryUpdate = "UPDATE Orders " +
                                             "SET VehicleId = @VehicleId, " +
                                             "SET Date = @Date" +
                                             "WHERE OrdersId = @OrdersId";

        public OrderRepository(IConnectionStringProvider connectionStringProvider) :
            base(connectionStringProvider)
        { }

        public void Create(Order item) => Connection.Execute(QueryCreate, item);

        public int CreateAndReturnId(Order item) => Connection.QuerySingle<int>(QueryCreateAndReturnId, item);

        public void Delete(int id) => Connection.Execute(QueryDelete, new { id });

        public void Update(Order item) => Connection.Execute(QueryUpdate, item);

        public IEnumerable<Order> GetAllItems()
        {
            return Connection.Query<Order, Vehicle, Order>(
                QueryGetAll,
                (order, vehicle) =>
                {
                    order.Vehicle = vehicle;
                    vehicle.VehicleId = order.VehicleId;
                    return order;
                },
                splitOn: "VehId"
            );
        }

        public Order GetItem(int id) => Connection.QueryFirstOrDefault<Order>(QueryGetById, new { id });
    }
}
