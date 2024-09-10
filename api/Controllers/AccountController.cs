using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Account;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signinManager;
        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signinManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == loginDto.Email);

            if (user == null) return Unauthorized("Invalid username!");

            var result = await _signinManager.CheckPasswordSignInAsync(user, loginDto.Password!, false);

            if (!result.Succeeded) return Unauthorized("Username not found and/or password incorrect");
            var roles = await _userManager.GetRolesAsync(user);
            // Console.WriteLine("Role Result: " + roles[0]);

            return Ok(
                new NewUserDto
                {
                    // UserName = user.UserName!,
                    // Email = user.Email!,
                    Token = _tokenService.CreateToken(user, roles[0])
                }
            );
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var appUser = new AppUser
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email
                };

                var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password!);


                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "USER");

                    if (roleResult.Succeeded)
                    {
                        var roles = await _userManager.GetRolesAsync(appUser);
                        Console.WriteLine("roleResult: " + roles[0]);
                        return Ok(
                            new NewUserDto
                            {
                                // UserName = appUser.UserName,
                                // Email = appUser.Email,
                                Token = _tokenService.CreateToken(appUser, roles[0])
                            }
                        );
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}