using System.Collections.Generic;
using WebAutopark.BusinessLogic.Dto;
using WebAutopark.Core.Enums;
using WebAutopark.Core.Interfaces;

namespace WebAutopark.BusinessLogic.Services.Interfaces
{
    public interface IVehicleService : IDataService<VehicleDto>
    {
        IEnumerable<VehicleDto> GetAllSortedItems(SortState sortOrder);
    }
}
