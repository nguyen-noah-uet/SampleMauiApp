using System.ComponentModel.DataAnnotations;

namespace SampleMauiApp.Domain
{
    public class ProductGroup : BaseModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = default!;

        // Navigation properties
        public List<Product> Products { get; set; } = new();

    }
}
