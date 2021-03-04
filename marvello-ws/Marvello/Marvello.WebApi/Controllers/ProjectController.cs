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
            var response = await _projectService.GetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneProject(long id)
        {
            var response = await _projectService.GetOne(id);
            if(response.ResponseData == null && string.IsNullOrEmpty(response.ErrorMessage))
            {
                return NotFound(new ResponseWrapper<ProjectDTO>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.NotFoundError)
                });
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveProject([FromBody] ProjectDTO entity)
        {
            if(entity == null)
            {
                return BadRequest(new ResponseWrapper<ProjectDTO>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.BadRequestError)
                });
            }
            var response = await _projectService.Save(entity);
            return Created("localhost:8080/api/projects/" + response.ResponseData?.Id, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject([FromBody] ProjectDTO entity, long id)
        {
            if (entity == null || id == 0)
            {
                return BadRequest(new ResponseWrapper<ProjectDTO>() 
                { 
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.BadRequestError)
                });
            }
            var response = await _projectService.Update(entity);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProject([FromBody] ProjectDTO entity)
        {
           if(entity == null)
            {
                return BadRequest(new ResponseWrapper<ProjectDTO>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.BadRequestError)
                });
            }
            var response = await _projectService.Delete(entity);
            return Ok(response);
        }
    }
}
