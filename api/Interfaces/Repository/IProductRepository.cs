using api.Models;
using api.Dtos.Product;

namespace api.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<List<ProductDto>> GetAllProduct();

        Task<List<ProductDto>> GetByCategory(long id);

        Task<ProductDto?> GetProductById(long id);

        Task<Product?> AddAsync(ProductAERequestDto productAERequestDto);

        Task<Product?> UpdateAsync(long id, ProductAERequestDto productAERequestDto);

        Task<Product?> DeleteAsync(long id);

        Task<int> UpdateProductStatus(string status, long id);
    }
}