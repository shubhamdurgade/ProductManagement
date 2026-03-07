using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Application.DTOs
{
    public class UpdateProductDTO : CreateProductDTO
    {
        [Required]
        public int Id { get; set; }
    }
}
