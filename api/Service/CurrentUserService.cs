using System.Security.Claims;
using api.Interfaces.Service;

namespace api.Service
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor accessor)
        {
            _httpContextAccessor = accessor;
        }

        public string GetCurrentUsername()
        {
            return _httpContextAccessor.HttpContext?.User?
                .FindFirst(ClaimTypes.Name)?.Value ?? string.Empty;
        }

        public bool IsAdmin()
        {
            return _httpContextAccessor.HttpContext?.User?
                .IsInRole("ADMIN") ?? false;
        }

        public bool IsUser()
        {
            return _httpContextAccessor.HttpContext?.User?
                .IsInRole("USER") ?? false;
        }
    }
}