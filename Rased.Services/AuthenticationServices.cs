
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Rased.Domain.Entitys.IdentityModule;
using Rased.Services_Abstraction;
using Rased.Shared.DTOs.Identity_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


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
            var User = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (User == null)
                return Error.InvalidCrendentials("User.InvalidCrendentials");
            var IsPasswordValid = await _userManager.CheckPasswordAsync(User, loginDTO.Password);
            if (!IsPasswordValid)
                return Error.InvalidCrendentials("User.InvalidCrendentials");
            return new UserDTO(User.Email, User.FullName, "Token");

        }

        public async Task<Result<UserDTO>> RegisterAsync(RegisterDTO registerDTO)
        {
            var User = new ApplicationUser()
            {
                Email = registerDTO.Email,
                FullName = registerDTO.FullName,
                PhoneNumber = registerDTO.PhoneNumber,
                UserName = registerDTO.UserName,
            };

            var IdentityResult = await _userManager.CreateAsync(User, registerDTO.Password);
            if (IdentityResult.Succeeded)
                return new UserDTO(User.Email, User.FullName, "Token");
            return IdentityResult.Errors.Select(E => Error.Validation(E.Code, E.Description)).ToList();
        }
    }
}
