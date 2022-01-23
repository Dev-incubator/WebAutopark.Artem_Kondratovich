using AutoMapper;
using System.Collections.Generic;
using WebAutopark.BusinessLogic.Dto;
using WebAutopark.BusinessLogic.Services.Interfaces;
using WebAutopark.Core.Entities;
using WebAutopark.Core.Interfaces.Repositories;

namespace WebAutopark.BusinessLogic.Services
{
    public class OrderItemService : BaseService<OrderItemDto, OrderItem>, IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemService(IMapper mapper, IOrderItemRepository orderItemRepository)
            : base(mapper, orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public IEnumerable<OrderItemDto> GetItemsByOrderId(int orderId)
        {
            var entities = _orderItemRepository.GetItemsByOrderId(orderId);
            var dtoItems = _mapper.Map<IEnumerable<OrderItemDto>>(entities);
            return dtoItems;
        }
    }
}
