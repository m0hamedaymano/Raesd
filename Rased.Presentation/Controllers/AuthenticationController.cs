using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Rased.Services_Abstraction;
using Rased.Shared.DTOs.Identity_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rased.Persistence.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationServices _authenticationServices;

        public AuthenticationController(IAuthenticationServices authenticationServices)
        {
            _authenticationServices = authenticationServices;
        }

        // Login
        // Post : BaseUrl/api/Authentication/Login

        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            var Result = await _authenticationServices.LoginAsync(loginDTO);
            return HandleResult(Result);
        }

      

        // Register
        // Post : BaseUrl/api/Authentication/Register

        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
        {
            var Result = await _authenticationServices.RegisterAsync(registerDTO);
            return HandleResult(Result);
        }

        private ActionResult HandleResult<T>(Result<T> result)
        {
            if (result.IsSuccess)
                return Ok(result.Value);

            return BadRequest(result.Errors.Select(e => e.Message));
        }

    }
}
