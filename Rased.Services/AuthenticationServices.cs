using FluentResults;
using Microsoft.AspNetCore.Identity;
using Rased.Domain.Entitys.IdentityModule;
using Rased.Services_Abstraction;
using Rased.Shared.DTOs.Identity_DTOs;

namespace Rased.Services
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthenticationServices(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Result<UserDTO>> LoginAsync(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);

            if (user == null)
                return Result.Fail(new Error("User.InvalidCredentials"));

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginDTO.Password);

            if (!isPasswordValid)
                return Result.Fail(new Error("User.InvalidCredentials"));

            return Result.Ok(new UserDTO(user.Email, user.FullName, "Token"));
        }


        public async Task<Result<UserDTO>> RegisterAsync(RegisterDTO registerDTO)
        {
            var user = new ApplicationUser
            {
                Email = registerDTO.Email,
                FullName = registerDTO.FullName,
                PhoneNumber = registerDTO.PhoneNumber,
                UserName = registerDTO.UserName,
            };

            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if (result.Succeeded)
                return Result.Ok(new UserDTO(user.Email, user.FullName, "Token"));

            return Result.Fail(
                 result.Errors.Select(e => new Error(e.Description).WithMetadata("Code", e.Code)).ToList()
            );

        }
    }
}
