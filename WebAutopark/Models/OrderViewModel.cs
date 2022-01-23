using System;
using WebAutopark.Core.Entities;

namespace WebAutopark.Models
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public DateTime Date { get; set; }
    }
}
