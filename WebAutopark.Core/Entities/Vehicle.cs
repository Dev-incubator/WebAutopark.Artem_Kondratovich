using WebAutopark.Core.Enums;

namespace WebAutopark.Core.Entities
{
    public class Vehicle
    {
        public int Id { get; }
        public int VehicleTypeId { get; }
        public string Model { get; }
        public string LicensePlate { get; }
        public double Weight { get; }
        public int YearIssue { get; }
        public double Mileage { get; }
        public CarColor Color { get; }
        public double TankCapacity { get; }
    }
}
