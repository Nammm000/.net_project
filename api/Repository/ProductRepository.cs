using api.Data;
using api.Dtos.Product;
using api.Models;
using api.Mappers;
using api.Interfaces.Repositories;

using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _context;

        public ProductRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDto>> GetAllProduct()
        {
            return await _context.Products
                .Include(p => p.Category)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price ?? 0,
                    Status = p.Status,
                    CategoryId = p.Category.Id,
                    CategoryName = p.Category.Name
                })
                .ToListAsync();
        }

        public async Task<List<ProductDto>> GetByCategory(long id)
        {
            return await _context.Products
                .Where(p => p.CategoryId == id)
                .Include(p => p.Category)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price ?? 0,
                    Status = p.Status,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category.Name
                })
                .ToListAsync();
        }

        public async Task<ProductDto?> GetProductById(long id)
        {
            return await _context.Products
                .Where(p => p.Id == id)
                .Include(p => p.Category)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price ?? 0,
                    Status = p.Status,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category.Name
                })
                .FirstOrDefaultAsync();
        }

        public async Task<Product?> AddAsync(ProductAERequestDto productAERequestDto)
        {
            var categoryExists = await _context.Categories
                .AnyAsync(c => c.Id == productAERequestDto.CategoryId);
            if (!categoryExists)
            {
                return null;
            }

            var product = productAERequestDto.ToProductFromCreateDTO();
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> UpdateAsync(long id, ProductAERequestDto productAERequestDto)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }

            product.Name = productAERequestDto.Name;
            product.Description = productAERequestDto.Description;
            product.Price = productAERequestDto.Price;
            product.Status = productAERequestDto.Status;
            product.CategoryId = productAERequestDto.CategoryId;

            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> DeleteAsync(long id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }
            else
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return product;
            }
        }

        public async Task<int> UpdateProductStatus(string status, long id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return 0;

            product.Status = status;

            return await _context.SaveChangesAsync();
        }
    }
}