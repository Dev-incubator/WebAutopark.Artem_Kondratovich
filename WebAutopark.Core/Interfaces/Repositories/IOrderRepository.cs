using WebAutopark.Core.Entities;

namespace WebAutopark.Core.Interfaces.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        int CreateAndReturnId(Order item);
    }
}
