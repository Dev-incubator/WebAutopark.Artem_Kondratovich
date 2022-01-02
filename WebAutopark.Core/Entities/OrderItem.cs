namespace WebAutopark.Core.Entities
{
    public class OrderItem
    {
        public int OrderItemId { get; }
        public int OrderId { get; }
        public int ComponentId { get; }
        public int Quantity { get; }
    }
}
