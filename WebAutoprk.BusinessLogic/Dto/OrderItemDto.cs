using WebAutopark.Core.Entities;

namespace WebAutopark.BusinessLogic.Dto
{
    public class OrderItemDto
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ComponentId { get; set; }
        public Component Component { get; set; }
        public int Quantity { get; set; }
    }
}
