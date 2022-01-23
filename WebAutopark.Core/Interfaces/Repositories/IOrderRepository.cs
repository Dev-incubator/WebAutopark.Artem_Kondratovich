using WebAutopark.Core.Entities;

namespace WebAutopark.Core.Interfaces.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        public int CreateAndReturnId(Order item);
    }
}
