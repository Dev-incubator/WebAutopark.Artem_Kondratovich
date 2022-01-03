using Dapper;
using WebAutopark.Core.Entities;
using WebAutopark.Core.Interfaces;

namespace WebAutopark.DatabaseAccess.Repositories
{
    internal class ComponentRepository : BaseRepository, IRepository<Component>
    {
        private const string QueryCreate = "INSERT INTO Components (Name) VALUES (@Name)";

        private const string QueryDelete = "DELETE FROM Components WHERE ComponentId = @id";

        private const string QueryGetById = "SELECT * FROM Components WHERE ComponentId = @id";

        private const string QueryGetAll = "SELECT * FROM Components";

        private const string QueryUpdate = "UPDATE Components SET Name = @Name WHERE ComponentId = @ComponentId";

        public ComponentRepository(IConnectionStringProvider connectionStringProvider) :
            base(connectionStringProvider)
        { }

        public void Create(Component item) => Connection.Execute(QueryCreate, item);

        public void Delete(int id) => Connection.Execute(QueryDelete, id);

        public void Update(Component item) => Connection.Execute(QueryUpdate, item);

        public IEnumerable<Component> GetAllItems() => Connection.Query<Component>(QueryGetAll);

        public Component GetItem(int id) => Connection.QueryFirstOrDefault<Component>(QueryGetById, new { id });

    }
}
