using System.ComponentModel.DataAnnotations;
using WebAutopark.Core.Entities;
using WebAutopark.Core.Enums;

namespace WebAutopark.Models
{
    public class VehicleViewModel
    {
        private const double WeightCoefficient = 0.0013d;
        private const double TaxCoefficient = 30d;
        private const double TaxPerMonthAddition = 5d;

        public int VehicleId { get; set; }

        public int VehicleTypeId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Model name length must be between 2 and 50 characters")]
        public string Model { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Registration number length must be between 3 and 20 characters")]
        public string RegistrationNumber { get; set; }

        [Required]
        [Range(0d, 100000d, ErrorMessage = "Weight must be between 0 and 100000")]
        public double? Weight { get; set; }

        [Required]
        [Range(0d, 2500d, ErrorMessage = "YearIssue must be between 0 and 2500")]
        public int? YearIssue { get; set; }

        [Required]
        [Range(0d, 1000000d, ErrorMessage = "Mileage must be between 0 and 100000")]
        public double? Mileage { get; set; }

        [Required]
        public CarColor? Color { get; set; }

        [Required]
        [Range(0d, 100d, ErrorMessage = "FuelConsumption must be between 0 and 100")]
        public double? FuelConsumption { get; set; }

        [Required]
        [Range(0d, 1000d, ErrorMessage = "TankCapacity must be between 0 and 100")]
        public double? TankCapacity { get; set; }

        public VehicleType VehicleType { get; set; }

        public double? GetCalcTaxPerMonth()
            => (Weight * WeightCoefficient) + (VehicleType.TaxCoefficient * TaxCoefficient) + TaxPerMonthAddition;

        public double? GetCalcMaxKm() => FuelConsumption != 0
            ? TankCapacity / FuelConsumption
            : TankCapacity;
    }
}
