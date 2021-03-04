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
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await _userService.GetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneUser(long id)
        {   
            var response = await _userService.GetOne(id);
            if(response.ResponseData == null && string.IsNullOrEmpty(response.ErrorMessage))
            {
                return NotFound(new ResponseWrapper<UserDTO>() 
                { 
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.NotFoundError)
                });
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveUser([FromBody] UserDTO entity)
        {
            if(entity == null) {
                return BadRequest(new ResponseWrapper<UserDTO>() 
                { 
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.BadRequestError)
                });
            }
            var response = await _userService.Save(entity);
            return Created("localhost:8080/api/users" + response.ResponseData.Id, response);
        }

        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDTO entity, long id)
        {
            if (entity == null || id == 0)
            {
                return BadRequest(new ResponseWrapper<UserDTO>() 
                { 
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.BadRequestError)
                });
            }
            var response = await _userService.Update(entity);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromBody] UserDTO entity)
        {
            if(entity == null)
            {
                return BadRequest(new ResponseWrapper<UserDTO>() 
                { 
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.BadRequestError)
                });
            }
            var response = await _userService.Delete(entity);
            return Ok(response);
        }
    }
}
