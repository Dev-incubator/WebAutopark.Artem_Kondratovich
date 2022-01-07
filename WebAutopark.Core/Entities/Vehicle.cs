using WebAutopark.Core.Enums;

namespace WebAutopark.Core.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
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
