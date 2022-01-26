using System.Collections.Generic;
using WebAutopark.Core.Entities;
using WebAutopark.Core.Enums;

namespace WebAutopark.Core.Interfaces.Repositories
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        IEnumerable<Vehicle> GetAllSortedItems(SortState sortOrder);
    }
}
