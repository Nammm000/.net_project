// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using System.Security.Claims;
// using api.Models;

namespace api.Interfaces.Service
{
    public interface ICurrentUserService
    {
        string GetCurrentUsername();

        bool IsAdmin();

        bool IsUser();
    }
}