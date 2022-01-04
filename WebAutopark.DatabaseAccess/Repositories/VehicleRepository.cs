using WebAutopark.Core.Interfaces;
using WebAutopark.Core.Entities;
using Dapper;

namespace WebAutopark.DatabaseAccess.Repositories
{
    internal class VehicleRepository : BaseRepository, IRepository<Vehicle>
    {
        private const string QueryCreate = "INSERT INTO Vehicles (VehicleTypeId, Model, RegistrationNumber, Weight, Year, Mileage, Color) " +
                                             "VALUES (@VehicleTypeId, @Model, @RegistrationNumber, @Weight, @Year, @Mileage, @Color)";

        private const string QueryDelete = "DELETE FROM Vehicles WHERE VehicleId = @id";

        private const string QueryGetById = "SELECT * FROM Vehicles WHERE VehicleId = @id";

        private const string QueryGetAll = "SELECT * FROM Vehicles";

        private const string QueryUpdate = "UPDATE Vehicle SET " +
                                              "VehicleTypeId = @VehicleTypeId, " +
                                              "Model = @Model, " +
                                              "RegistrationNumber = @RegistrationNumber, " +
                                              "Weight = @Weight, " +
                                              "Year = @Year, " +
                                              "Mileage = @Mileage, " +
                                              "Color = @Color" +
                                              "WHERE VehicleId = @VehicleId";

        public VehicleRepository(IConnectionStringProvider connectionStringProvider) :
            base(connectionStringProvider)
        { }

        public void Create(Vehicle item) => Connection.Execute(QueryCreate, item);

        public void Delete(int id) => Connection.Execute(QueryDelete, new { id });

        public void Update(Vehicle item) => Connection.Execute(QueryUpdate, item);

        public IEnumerable<Vehicle> GetAllItems() => Connection.Query<Vehicle>(QueryGetAll);

        public Vehicle GetItem(int id) => Connection.QueryFirstOrDefault<Vehicle>(QueryGetById, new { id });
    }
}
