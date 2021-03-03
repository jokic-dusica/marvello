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
    [Route("api/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProject()
        {
            var listProject = await _projectService.GetAll();
            return Ok(listProject);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneProject(long id)
        {
            var oneProject = await _projectService.GetOne(id);
            if(oneProject == null)
            {
                return NotFound();
            }
            return Ok(oneProject);
        }

        [HttpPost]
        public async Task<IActionResult> SaveProject([FromBody] ProjectDTO entity)
        {
            if(entity == null)
            {
                return BadRequest();
            }
            var saveProject = await _projectService.Save(entity);
            return Created("localhost:8080/api/projects/" + saveProject.Id, saveProject);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject([FromBody] ProjectDTO entity, long id)
        {
            if (entity == null || id == 0)
            {
                return BadRequest();
            }
            var updateProject = await _projectService.Update(entity);
            return Ok(updateProject);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProject([FromBody] ProjectDTO entity)
        {
           if(entity == null)
            {
                return BadRequest();
            }
            await _projectService.Delete(entity);
            return Ok();
        }
    }
}
