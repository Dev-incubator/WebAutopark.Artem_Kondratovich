using System.ComponentModel.DataAnnotations;
using WebAutopark.Core.Entities;

namespace WebAutopark.Models
{
    public class OrderItemViewModel
    {
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }

        public int ComponentId { get; set; }

        public Component Component { get; set; }

        [Required]
        [Range(1d, 100d, ErrorMessage = "Quantity must be between 1 and 100")]
        public int? Quantity { get; set; }
    }
}
