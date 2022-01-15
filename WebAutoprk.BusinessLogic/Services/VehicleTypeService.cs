using AutoMapper;
using WebAutopark.BusinessLogic.Dto;
using WebAutopark.Core.Entities;
using WebAutopark.Core.Interfaces;

namespace WebAutopark.BusinessLogic.Services
{
    public class VehicleTypeService : BaseService<VehicleTypeDto, VehicleType>
    {
        public VehicleTypeService(IMapper mapper, IRepository<VehicleType> repository)
            : base(mapper, repository)
        { }
    }
}
