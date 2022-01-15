using System;

namespace WebAutopark.Models
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public int VehicleId { get; set; }
        public DateTime Date { get; set; }
    }
}
