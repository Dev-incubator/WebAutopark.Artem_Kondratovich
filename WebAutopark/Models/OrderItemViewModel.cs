﻿namespace WebAutopark.Models
{
    public class OrderItemViewModel
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ComponentId { get; set; }
        public int Quantity { get; set; }
    }
}
