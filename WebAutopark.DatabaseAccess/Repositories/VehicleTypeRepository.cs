using Dapper;
using System.Collections.Generic;
using WebAutopark.Core.Entities;
using WebAutopark.Core.Interfaces;

namespace WebAutopark.DatabaseAccess.Repositories
{
    public class VehicleTypeRepository : BaseRepository, IRepository<VehicleType>
    {
        private const string QueryCreate = "INSERT INTO VehicleTypes (Name, TaxCoefficient) VALUES (@Name, @TaxCoefficient)";

        private const string QueryDelete = "DELETE FROM VehicleTypes WHERE VehicleTypeId = @id";

        private const string QueryGetById = "SELECT * FROM VehicleTypes WHERE VehicleTypeId = @id";

        private const string QueryGetAll = "SELECT * FROM VehicleTypes";

        private const string QueryUpdate = "UPDATE VehicleTypes SET " +
                                               "Name = @Name, " +
                                               "TaxCoefficient = @TaxCoefficient " +
                                               "WHERE VehicleTypeId = @VehicleTypeId";

        public VehicleTypeRepository(IConnectionStringProvider connectionStringProvider) :
            base(connectionStringProvider)
        { }

        public void Create(VehicleType item) => Connection.Execute(QueryCreate, item);

        public void Delete(int id) => Connection.Execute(QueryDelete, new { id });

        public void Update(VehicleType item) => Connection.Execute(QueryUpdate, item);

        public IEnumerable<VehicleType> GetAllItems() => Connection.Query<VehicleType>(QueryGetAll);

        public VehicleType GetItem(int id) => Connection.QueryFirstOrDefault<VehicleType>(QueryGetById, new { id });
    }
}
