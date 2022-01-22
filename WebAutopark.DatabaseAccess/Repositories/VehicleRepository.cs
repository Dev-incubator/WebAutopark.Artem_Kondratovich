using WebAutopark.Core.Interfaces;
using WebAutopark.Core.Entities;
using Dapper;
using System.Collections.Generic;
using WebAutopark.Core.Enums;
using WebAutopark.Core.Interfaces.Repositories;
using System.Linq;

namespace WebAutopark.DatabaseAccess.Repositories
{
    public class VehicleRepository : BaseRepository, IVehicleRepository
    {
        private const string QueryCreate = "INSERT INTO Vehicles (VehicleTypeId, Model, RegistrationNumber, Weight, YearIssue, Mileage, Color, FuelConsumption, TankCapacity) " +
                                              "VALUES (@VehicleTypeId, @Model, @RegistrationNumber, @Weight, @YearIssue, @Mileage, @Color, @FuelConsumption, @TankCapacity)";

        private const string QueryDelete = "DELETE FROM Vehicles WHERE VehicleId = @id";

        private const string QueryGetById = "SELECT v.*, vt.VehicleTypeId as TypeId, vt.TypeName, vt.TaxCoefficient " +
                                              "FROM Vehicles v " +
                                              "INNER JOIN VehicleTypes vt " +
                                              "ON v.VehicleTypeId = vt.VehicleTypeId " +
                                              "WHERE VehicleId = @id";

        private const string QueryGetAll = "SELECT v.*, vt.VehicleTypeId as TypeId, vt.TypeName, vt.TaxCoefficient " +
                                              "FROM Vehicles v " +
                                              "INNER JOIN VehicleTypes vt " +
                                              "ON v.VehicleTypeId = vt.VehicleTypeId";

        private const string QueryUpdate = "UPDATE Vehicles SET " +
                                              "VehicleTypeId = @VehicleTypeId, " +
                                              "Model = @Model, " +
                                              "RegistrationNumber = @RegistrationNumber, " +
                                              "Weight = @Weight, " +
                                              "YearIssue = @YearIssue, " +
                                              "Mileage = @Mileage, " +
                                              "Color = @Color, " +
                                              "FuelConsumption = @FuelConsumption, " +
                                              "TankCapacity = @TankCapacity " +
                                              "WHERE VehicleId = @VehicleId";

        public VehicleRepository(IConnectionStringProvider connectionStringProvider) :
            base(connectionStringProvider)
        { }

        public void Create(Vehicle item) => Connection.Execute(QueryCreate, item);

        public void Delete(int id) => Connection.Execute(QueryDelete, new { id });

        public void Update(Vehicle item) => Connection.Execute(QueryUpdate, item);

        public IEnumerable<Vehicle> GetAllItems() => Connection.Query<Vehicle>(QueryGetAll);

        public IEnumerable<Vehicle> GetAllSortedItems(SortState sortOrder)
        {
            var queryGetAllSortedItems = sortOrder switch
            {
                SortState.ModelDesc => $"{QueryGetAll} ORDER BY Model DESC",
                SortState.VehicleTypeAsc => $"{QueryGetAll} ORDER BY TypeName ASC",
                SortState.VehicleTypeDesc => $"{QueryGetAll} ORDER BY TypeName DESC",
                SortState.MileageAsc => $"{QueryGetAll} ORDER BY Mileage ASC",
                SortState.MileageDesc => $"{QueryGetAll} ORDER BY Mileage DESC",
                _ => $"{QueryGetAll} ORDER BY Model ASC"
            };
            return Connection.Query<Vehicle, VehicleType, Vehicle>(
                queryGetAllSortedItems,
                (vehicle, vehicleType) =>
                {
                    vehicle.VehicleType = vehicleType;
                    vehicleType.VehicleTypeId = vehicle.VehicleTypeId;
                    return vehicle;
                },
                splitOn: "TypeId"
            );
        }

        public Vehicle GetItem(int id)
        {
            var vehicles = Connection.Query<Vehicle, VehicleType, Vehicle>(
                QueryGetById,
                (vehicle, vehicleType) =>
                {
                    vehicle.VehicleType = vehicleType;
                    vehicleType.VehicleTypeId = vehicle.VehicleTypeId;
                    return vehicle;
                },
                new { id },
                splitOn: "TypeId"
            );

            return vehicles.FirstOrDefault();
        }
    }
}
