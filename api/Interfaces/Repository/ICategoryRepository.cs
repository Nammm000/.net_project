using api.Models;

namespace api.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category?> GetByIdAsync(long id);
        Task AddAsync(Category category);
        Task<Category?> UpdateAsync(long id, Category categoryUpdate);
        Task<Category?> DeleteAsync(long id);
    }
}