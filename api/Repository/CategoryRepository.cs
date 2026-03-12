using api.Data;
using api.Models;
using api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _context;

        public CategoryRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(long id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task<Category?> UpdateAsync(long id, Category categoryUpdate)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return null;
            }

            category.Name = categoryUpdate.Name;
            category.Description = categoryUpdate.Description;

            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> DeleteAsync(long id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return null;
            }
            else
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return category;
            }
        }
    }
}