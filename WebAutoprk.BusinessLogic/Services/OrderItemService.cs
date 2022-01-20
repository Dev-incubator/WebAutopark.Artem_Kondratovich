using AutoMapper;
using WebAutopark.BusinessLogic.Dto;
using WebAutopark.Core.Entities;
using WebAutopark.Core.Interfaces;

namespace WebAutopark.BusinessLogic.Services
{
    public class OrderItemService : BaseService<OrderItemDto, OrderItem>
    {
        public OrderItemService(IMapper mapper, IRepository<OrderItem> repository)
            : base(mapper, repository)
        { }
    }
}
