using WebAutopark.Core.Enums;

namespace WebAutopark.BusinessLogic.Dto
{
    public class VehicleDto
    {
        public int VehicleId { get; set; }
        public int VehicleTypeId { get; set; }
        public string Model { get; set; }
        public string RegistrationNumber { get; set; }
        public double Weight { get; set; }
        public int YearIssue { get; set; }
        public double Mileage { get; set; }
        public CarColor Color { get; set; }
        public double FuelConsumption { get; set; }
    }
}
