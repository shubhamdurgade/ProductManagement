using ProductManagement.Application.DTOs;
using ProductManagement.Domain.Entites;
using ProductManagement.Domain.Repositories;

namespace ProductManagement.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        
        public ProductService(IProductRepository repository) 
        {
            _repository = repository;
        }

        private ProductDTO MapToDTO(Product product)
        {
            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
            };
        }
        
        public async Task<IEnumerable<ProductDTO>> GetAllProductAsync()
        {
            var products = await _repository.GetAllAsync();
            var dtos = new List<ProductDTO>();
            foreach(var product in products)
            {
                dtos.Add(MapToDTO(product));
            }
            return dtos;
        }
        
        public async Task<ProductDTO?> GetProductByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) {
                return null;
            }
            return MapToDTO(product);
        }

        public async Task<ProductDTO?> AddProductAsync(CreateProductDTO productDto)
        {
            var newProduct = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Stock = productDto.Stock,
            };
            newProduct.validateBusinessRules();
            var product = await _repository.AddAsync(newProduct);
            if (product == null) { return null; }
            return MapToDTO(product); 
        }
        
        public async Task UpdateProductAsync(UpdateProductDTO productDto)
        {
            var getProduct = await _repository.GetByIdAsync(productDto.Id);
            if (getProduct == null) throw new Exception("Product not found.");
            getProduct.Description = productDto.Description;
            getProduct.Price = productDto.Price;
            getProduct.Stock = productDto.Stock;
            getProduct.Name = productDto.Name;

            getProduct.validateBusinessRules();
            await _repository.UpdateAsync(getProduct);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
