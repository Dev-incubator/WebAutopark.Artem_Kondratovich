using System.Collections.Generic;
using WebAutopark.BusinessLogic.Dto;
using WebAutopark.Core.Interfaces;

namespace WebAutopark.BusinessLogic.Services.Interfaces
{
    public interface IOrderItemService : IDataService<OrderItemDto>
    {
        IEnumerable<OrderItemDto> GetItemsByOrderId(int orderId);
    }
}
