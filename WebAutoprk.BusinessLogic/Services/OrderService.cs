using AutoMapper;
using WebAutopark.BusinessLogic.Dto;
using WebAutopark.Core.Entities;
using WebAutopark.Core.Interfaces;

namespace WebAutopark.BusinessLogic.Services
{
    public class OrderService : BaseService<OrderDto, Order>
    {
        public OrderService(IMapper mapper, IRepository<Order> repository)
            : base(mapper, repository)
        { }
    }
}
