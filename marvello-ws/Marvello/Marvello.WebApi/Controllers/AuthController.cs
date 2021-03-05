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
            return Ok(response);
             
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
    }
}
