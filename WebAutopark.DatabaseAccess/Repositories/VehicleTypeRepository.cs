using Dapper;
using WebAutopark.Core.Entities;
using WebAutopark.Core.Interfaces;

namespace WebAutopark.DatabaseAccess.Repositories
{
    public class VehicleTypeRepository : BaseRepository, IRepository<VehicleType>
    {
        private readonly string QueryCreate = "INSERT INTO VehicleTypes (Name) VALUES (@Name)";

        private readonly string QueryDelete = "DELETE FROM VehicleTypes WHERE VehicleTypeId = @id";

        private readonly string QueryGetById = "SELECT * FROM VehicleTypes WHERE VehicleTypeId = @id";

        private readonly string QueryGetAll = "SELECT * FROM VehicleTypes";

        private readonly string QueryUpdate = "UPDATE VehicleTypes SET Name = @Name WHERE VehicleTypeId = @VehicleTypeId";

        public VehicleTypeRepository(IConnectionStringProvider connectionStringProvider) :
            base(connectionStringProvider)
        { }

        public void Create(VehicleType item) => Connection.Execute(QueryCreate, item);

        public void Delete(int id) => Connection.Execute(QueryDelete, id);

        public void Update(VehicleType item) => Connection.Execute(QueryUpdate, item);

        public IEnumerable<VehicleType> GetAllItems() => Connection.Query<VehicleType>(QueryGetAll);

        public VehicleType GetItem(int id) => Connection.QueryFirstOrDefault<VehicleType>(QueryGetById, new { id });
    }
}
