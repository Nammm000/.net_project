using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    public class AppUser : IdentityUser
    {
        // id, username, email, passwordHash, securityStamp, 
        // concurrencyStamp, phoneNumber, phoneNumberConfirmed, 
        // twoFactorEnabled, lockoutEnd, lockoutEnabled, accessFailedCount

        public string? ImageUrl { get; set; }

        public string Status { get; set; } = "Active"; // Active, Inactive, Suspended

        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
    }
}