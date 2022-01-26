using AutoMapper;
using WebAutopark.BusinessLogic.Dto;
using WebAutopark.Core.Entities;
using WebAutopark.Core.Interfaces;

namespace WebAutopark.BusinessLogic.Services
{
    public class ComponentService : BaseService<ComponentDto, Component>
    {
        public ComponentService(IMapper mapper, IRepository<Component> repository)
            : base(mapper, repository)
        { }
    }
}
