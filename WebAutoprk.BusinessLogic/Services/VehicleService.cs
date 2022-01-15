using AutoMapper;
using WebAutopark.BusinessLogic.Dto;
using WebAutopark.Core.Entities;
using WebAutopark.Core.Interfaces;

namespace WebAutopark.BusinessLogic.Services
{
    public class VehicleService : BaseService<VehicleDto, Vehicle>
    {
        public VehicleService(IMapper mapper, IRepository<Vehicle> repository)
            : base(mapper, repository)
        { }
    }
}
