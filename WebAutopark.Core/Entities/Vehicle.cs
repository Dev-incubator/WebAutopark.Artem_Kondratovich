using WebAutopark.Core.Enums;

namespace WebAutopark.Core.Entities
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }
        public string Model { get; set; }
        public string RegistrationNumber { get; set; }
        public double Weight { get; set; }
        public int YearIssue { get; set; }
        public double Mileage { get; set; }
        public CarColor Color { get; set; }
        public double FuelConsumption { get; set; }
        public double TankCapacity { get; set; }
    }
}
