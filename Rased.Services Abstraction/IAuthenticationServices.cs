using FluentResults;
using Rased.Shared.DTOs.Identity_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Rased.Services_Abstraction
{
    public interface IAuthenticationServices
    {
        Task<Result<UserDTO>> LoginAsync(LoginDTO loginDTO);

        Task<Result<UserDTO>> RegisterAsync(RegisterDTO registerDTO);
    }
}
