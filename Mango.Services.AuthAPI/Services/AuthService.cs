using Mango.Services.AuthAPI.Data;
using Mango.Services.AuthAPI.DTOs;
using Mango.Services.AuthAPI.Models;
using Mango.Services.AuthAPI.Services.IServices;
using Microsoft.AspNetCore.Identity;

namespace Mango.Services.AuthAPI.Services
{
    public class AuthService : IAuthService
    {

        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(AppDbContext context, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> Register(RegistrationRequestDto registrationRequestDto)
        {
            ApplicationUser user = new()
            {
                UserName = registrationRequestDto.Email,
                Email = registrationRequestDto.Email,
                Name = registrationRequestDto.Name,
                PhoneNumber = registrationRequestDto.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);

            if(!result.Succeeded)
            {
                throw new ApplicationException(string.Join("; ", result.Errors.Select(e => e.Description)));
            }

            return new UserDto
            {
                Email = user.Email,
                Name = user.Name,
                Id = user.Id,
                PhoneNumber = user.PhoneNumber
            };
        }
    }
}
