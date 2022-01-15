using WebAutopark.Core.Interfaces;
using WebAutopark.Core.Entities;
using Dapper;
using System.Collections.Generic;

namespace WebAutopark.DatabaseAccess.Repositories
{
    public class VehicleRepository : BaseRepository, IRepository<Vehicle>
    {
        private const string QueryCreate = "INSERT INTO Vehicles (VehicleTypeId, Model, RegistrationNumber, Weight, YearIssue, Mileage, Color, FuelConsumption) " +
                                             "VALUES (@VehicleTypeId, @Model, @RegistrationNumber, @Weight, @YearIssue, @Mileage, @Color, @FuelConsumption)";

        private const string QueryDelete = "DELETE FROM Vehicles WHERE VehicleId = @id";

        private const string QueryGetById = "SELECT * FROM Vehicles WHERE VehicleId = @id";

        private const string QueryGetAll = "SELECT * FROM Vehicles";

        private const string QueryUpdate = "UPDATE Vehicles SET " +
                                              "VehicleTypeId = @VehicleTypeId, " +
                                              "Model = @Model, " +
                                              "RegistrationNumber = @RegistrationNumber, " +
                                              "Weight = @Weight, " +
                                              "YearIssue = @YearIssue, " +
                                              "Mileage = @Mileage, " +
                                              "Color = @Color, " +
                                              "FuelConsumption = @FuelConsumption " +
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
