using AutoMapper;
using System.Collections.Generic;
using WebAutopark.BusinessLogic.Dto;
using WebAutopark.BusinessLogic.Services.Interfaces;
using WebAutopark.Core.Entities;
using WebAutopark.Core.Enums;
using WebAutopark.Core.Interfaces.Repositories;

namespace WebAutopark.BusinessLogic.Services
{
    public class VehicleService : BaseService<VehicleDto, Vehicle>, IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IMapper mapper, IVehicleRepository vehicleRepository)
            : base(mapper, vehicleRepository)
        { 
            _vehicleRepository = vehicleRepository;
        }

        public IEnumerable<VehicleDto> GetAllSortedItems(SortState sortOrder)
        {
            var entities = _vehicleRepository.GetAllSortedItems(sortOrder);
            var dtoItems = _mapper.Map<IEnumerable<VehicleDto>>(entities);
            return dtoItems;
        }
    }
}
