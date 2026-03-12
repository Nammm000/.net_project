// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
using System.Security.Claims;
using api.Models;

namespace api.Interfaces.Service
{
    public interface ITokenService
    {
        string CreateToken(AppUser user, string role);

        string ExtractUsername(string token);

        IEnumerable<Claim> ExtractAllClaims(string token);

        string? ExtractRole(string token);
    }
}