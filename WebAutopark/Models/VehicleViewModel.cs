﻿using WebAutopark.Core.Enums;

namespace WebAutopark.Models
{
    public class VehicleViewModel
    {
        public int VehicleId { get; set; }
        public int VehicleTypeId { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public double Weight { get; set; }
        public int YearIssue { get; set; }
        public double Mileage { get; set; }
        public CarColor Color { get; set; }
        public double TankCapacity { get; set; }
    }
}
