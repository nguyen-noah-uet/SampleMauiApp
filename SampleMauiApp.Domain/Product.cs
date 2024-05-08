using System.ComponentModel.DataAnnotations;

namespace SampleMauiApp.Domain
{
    public class Product : BaseModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = default!;
        [MaxLength(500)]
        public string? Description { get; set; }
        public double Price { get; set; }

        public Guid ProductGroupId { get; set; }

        // Navigation properties
        //public ProductGroup ProductGroup { get; set; } = default!;
    }
}
