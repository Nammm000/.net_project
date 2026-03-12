using api.Data;
using api.DTOs;
using api.Models;
using api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;

        private readonly UserManager<AppUser> _userManager;

        public UserRepository(ApplicationDBContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<AppUser?> FindFirstByEmail(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<List<UserDto>> GetAllUser()
        {
            var users = await _userManager.GetUsersInRoleAsync("USER");
            return users.Select(static u => new UserDto
            {
                Id = u.Id,
                Name = u.UserName ?? string.Empty,
                Email = u.Email ?? string.Empty,
                Phone = u.PhoneNumber ?? string.Empty,
                Status = u.Status ?? string.Empty
            }).ToList();
        }

        public async Task<int> UpdateStatus(string status, string id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return 0;

            user.Status = status;

            return await _context.SaveChangesAsync();
        }
    }
}