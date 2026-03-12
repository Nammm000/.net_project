using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using api.Service;

namespace api.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TokenService _jwtService;

        public JwtMiddleware(RequestDelegate next, TokenService jwtService)
        {
            _next = next;
            _jwtService = jwtService;
        }

        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine("JwtMiddleware invoked");

            var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();
            string token = null;

            if (authHeader != null && authHeader.StartsWith("Bearer "))
            {
                token = authHeader.Substring(7);
            }

            if (token != null)
            {
                try
                {
                    var username = _jwtService.ExtractUsername(token);
                    var role = _jwtService.ExtractRole(token);

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, username),
                        new Claim(ClaimTypes.Role, role)
                    };

                    var identity = new ClaimsIdentity(claims, "jwt");
                    context.User = new ClaimsPrincipal(identity);
                }
                catch
                {
                    context.User = null;
                }
            }

            await _next(context);
        }
    }
}