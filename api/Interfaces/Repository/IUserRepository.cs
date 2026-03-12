using api.DTOs;
using api.Models;

namespace api.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<AppUser?> FindFirstByEmail(string email);

        Task<List<UserDto>> GetAllUser();

        Task<int> UpdateStatus(string status, string id);
    }
}