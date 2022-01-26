using System.Collections.Generic;
using WebAutopark.Core.Entities;

namespace WebAutopark.Core.Interfaces.Repositories
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        IEnumerable<OrderItem> GetItemsByOrderId(int orderId);
    }
}
