using Marvello.Service.DTOs;
using Marvello.Service.Enums;
using Marvello.Service.Interfaces;
using Marvello.Service.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marvello.WebApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> SignIn([FromBody] LoginDTO entity )
        {
            if(entity == null)
            {
                return BadRequest(new ResponseWrapper<AuthDTO>() 
                { 
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.BadRequestError),
                    IsSuccess = false               
                });
            }
            var response = await _authService.SignIn(entity);
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(10)
            };
            if(response != null && response.ResponseData != null)
            {
                Response.Cookies.Append("refreshToken", response.ResponseData.RefreshToken, cookieOptions);

                return Ok(response);
            }
            return BadRequest(response);

             
        }

        [HttpPost("register")]
        public async Task<IActionResult> SignUp([FromBody] RegisterUserDTO entity)
        {   

            if(entity == null)
            {
                return BadRequest(new ResponseWrapper<AuthDTO>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.BadRequestError),
                    IsSuccess = false
                });
            }
            var response = await _authService.SignUp(entity);
            return Ok(response);
        }


        [HttpPost("refreshToken")]
        public async Task<IActionResult> RefreshToken()
        {
            var token = Request.Cookies["refreshToken"];
            if(token != null)
            {
                var response = await _authService.RefreshToken(token);
                if(response.ResponseData.RefreshToken != null)
                {
                    var cookieOptions = new CookieOptions
                    {
                        HttpOnly = true,
                        Expires = DateTime.UtcNow.AddDays(10)
                    };
                    Response.Cookies.Append("refreshToken", response.ResponseData.RefreshToken, cookieOptions);
                }
                return Ok(response);

            }
            return BadRequest();
        }
    }
}
