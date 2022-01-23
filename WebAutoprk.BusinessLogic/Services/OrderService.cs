using AutoMapper;
using WebAutopark.BusinessLogic.Dto;
using WebAutopark.BusinessLogic.Services.Interfaces;
using WebAutopark.Core.Entities;
using WebAutopark.Core.Interfaces;
using WebAutopark.Core.Interfaces.Repositories;

namespace WebAutopark.BusinessLogic.Services
{
    public class OrderService : BaseService<OrderDto, Order>, IOrderService
    {
        private readonly IOrderRepository _orderRepositry;

        public OrderService(IMapper mapper, IOrderRepository orderRepository)
            : base(mapper, orderRepository)
        {
            _orderRepositry = orderRepository;
        }

        public int CreateAndReturnId(OrderDto item)
        {
            var orderEntity = _mapper.Map<Order>(item);
            var insertedOrderId = _orderRepositry.CreateAndReturnId(orderEntity);

            return insertedOrderId;
        }
    }
}
