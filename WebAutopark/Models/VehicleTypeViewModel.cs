using System.ComponentModel.DataAnnotations;

namespace WebAutopark.Models
{
    public class VehicleTypeViewModel
    {
        public int VehicleTypeId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Type name length must be between 2 and 50 characters")]
        public string TypeName { get; set; }

        [Required]
        [Range(0.5, 10, ErrorMessage = "Tax Coefficient must be from 0.5 to 10")]
        public double TaxCoefficient { get; set; }
    }
}
