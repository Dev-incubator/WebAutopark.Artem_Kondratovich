using System.ComponentModel.DataAnnotations;

namespace WebAutopark.Models
{
    public class ComponentViewModel
    {
        public int ComponentId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Detail name length must be between 2 and 50 characters")]
        public string Name { get; set; }
    }
}
