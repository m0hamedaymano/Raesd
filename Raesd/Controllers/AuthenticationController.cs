using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Rased.Services_Abstraction;
using Rased.Shared.DTOs.Identity_DTOs;

namespace Raesd.Web.Controllers
{
    //[ApiController]
    //[Route("api/[Controller]")]
    public class AuthenticationController 
    {
        //private readonly IAuthenticationServices _authenticationServices;

        //public AuthenticationController(IAuthenticationServices authenticationServices)
        //{
        //    _authenticationServices = authenticationServices;
        //}

        //// Login
        //// Post : BaseUrl/api/Authentication/Login

        //[HttpPost("Login")]
        //public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        //{
        //    var Result = await _authenticationServices.LoginAsync(loginDTO);
        //    return HandleResult(Result);
        //}

        //// Register
        //// Post : BaseUrl/api/Authentication/Register

        //[HttpPost("Register")]
        //public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
        //{
        //    var Result = await _authenticationServices.RegisterAsync(registerDTO);
        //    return HandleResult(Result);
        //}



    }
}
