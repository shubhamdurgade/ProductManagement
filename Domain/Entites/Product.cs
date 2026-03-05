using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProductManagement.Domain.Entites
{
    public class Product
    {
        public int Id { get; set; }

        [Required, StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = null!;

        [StringLength(500)]
        public string? Description { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        [Range(0.01, 1000000, ErrorMessage = "Price must be positive and less than 10 lakh.")]
        public decimal? Price { get; set; }

        [Range(0, 1000, ErrorMessage = "Stack cannot be negative.")]
        public int Stock { get; set; }

        public void validateBusinessRules()
        {
            if (Price <= 0)
                throw new InvalidOperationException("Product price must be positive.");
            if (Stock < 0)
                throw new InvalidOperationException("Product price must be positive.");
        }
    }
}
