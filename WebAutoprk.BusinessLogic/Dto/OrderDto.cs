using System;
using System.Collections.Generic;
using WebAutopark.Core.Entities;

namespace WebAutopark.BusinessLogic.Dto
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public DateTime Date { get; set; }
    }
}
