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
    [Route("api/projectTypes")]
    [ApiController]
    public class ProjectTypeController : ControllerBase
    {
        private readonly IProjectTypeService _projectTypeService;
        public ProjectTypeController(IProjectTypeService projectTypeService)
        {
            _projectTypeService = projectTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjectType()
        {
            var listProjectType = await _projectTypeService.GetAll();
            return Ok(listProjectType);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneProjectType(int id)
        {
            var oneProjectType = await _projectTypeService.GetOne(id);
            if(oneProjectType == null)
            {
                return NotFound();
            }
            return Ok(oneProjectType);
        }

        [HttpPost]
        public async Task<IActionResult> SaveProjectType([FromBody] ProjectTypeDTO entity)
        {
            if(entity == null)
            {
                return BadRequest();
            }
            var saveProjectType = await _projectTypeService.Save(entity);
            return Created("localhost:8080/api/projecttypes/" + saveProjectType.Id, saveProjectType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProjectType([FromBody] ProjectTypeDTO entity, int id)
        {
            if(entity == null || id == 0)
            {
                return BadRequest();
            }
            var updateProjectType = await _projectTypeService.Update(entity);
            return Ok(updateProjectType);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProjectType([FromBody] ProjectTypeDTO entity)
        {
            if(entity == null)
            {
                return BadRequest();
            }
            await _projectTypeService.Delete(entity);
            return Ok();
        }
    }
}
