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
    [Route("api/projectusers")]
    [ApiController]
    public class ProjectUserController : ControllerBase
    {
        private readonly IProjectUserService _projectUserService;
        public ProjectUserController(IProjectUserService projectUserService)
        {
            _projectUserService = projectUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjectUser()
        {
            var listProjectUser = await _projectUserService.GetAll();
            return Ok(listProjectUser);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneProjectUser(int id)
        {
            var oneProjectUser = await _projectUserService.GetOne(id);
            if(oneProjectUser == null)
            {
                return NotFound();
            }
            return Ok(oneProjectUser);
        }
        [HttpPost]
        public async Task<IActionResult> SaveProjectUser([FromBody] ProjectUserDTO entity)
        {
            if(entity == null)
            {
                return BadRequest();
            }
            var saveProjectUser = await _projectUserService.Save(entity);
            return Created("localhost:8080/api/projectusers/" + saveProjectUser.Id, saveProjectUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProjectUser([FromBody] ProjectUserDTO entity, int id)
        {
            if(entity == null || id == 0)
            {
                return BadRequest();
            }
            var updateProjectUser = await _projectUserService.Update(entity);
            return Ok(updateProjectUser);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProjectUser([FromBody] ProjectUserDTO entity)
        {
            if(entity == null)
            {
                return BadRequest();
            }
            await _projectUserService.Delete(entity);
            return Ok();
        }
    }
}
