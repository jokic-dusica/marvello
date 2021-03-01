using Marvello.Service.DTOs;
using Marvello.Service.Interfaces;
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
            var listUsers = await _userService.GetAll();
            return Ok(listUsers);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetOneUser(long id)
        {   
            var oneUser = await _userService.GetOne(id);
            if(oneUser == null)
            {
                return NotFound();
            }
            return Ok(oneUser);
        }

        [HttpPost]
        public async Task<IActionResult> SaveUser([FromBody] UserDTO entity)
        {
            if(entity == null) {
                return BadRequest();
            }
            var saveUser = await _userService.Save(entity);
            return Created("localhost:8080/api/users" + saveUser.Id, saveUser);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserDTO entity, long id)
        {
            if (entity == null || id == 0)
            {
                return BadRequest();
            }
            var updateUser = await _userService.Update(entity);
            return Ok(updateUser);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromBody] UserDTO entity)
        {
            if(entity == null)
            {
                return BadRequest();
            }
            await _userService.Delete(entity);
            return Ok();
        }
    }
}
