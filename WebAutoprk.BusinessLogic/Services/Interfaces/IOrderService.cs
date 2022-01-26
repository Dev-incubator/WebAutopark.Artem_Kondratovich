using WebAutopark.BusinessLogic.Dto;
using WebAutopark.Core.Interfaces;

namespace WebAutopark.BusinessLogic.Services.Interfaces
{
    public interface IOrderService : IDataService<OrderDto>
    {
        int CreateAndReturnId(OrderDto item);
    }
}
