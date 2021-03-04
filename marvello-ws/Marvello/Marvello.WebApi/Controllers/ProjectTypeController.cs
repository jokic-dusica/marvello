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
            var response = await _projectTypeService.GetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneProjectType(int id)
        {
            var response = await _projectTypeService.GetOne(id);
            if(response.ResponseData == null && string.IsNullOrEmpty(response.ErrorMessage))
            {
                return NotFound(new ResponseWrapper<ProjectTypeDTO>() { 
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.NotFoundError)
                });
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveProjectType([FromBody] ProjectTypeDTO entity)
        {
            if(entity == null)
            {
                return BadRequest(new ResponseWrapper<ProjectTypeDTO>() { 
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.BadRequestError)
                });
            }
            var response = await _projectTypeService.Save(entity);
            return Created("localhost:8080/api/projecttypes/" + response.ResponseData.Id, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProjectType([FromBody] ProjectTypeDTO entity, int id)
        {
            if(entity == null || id == 0)
            {
                return BadRequest(new ResponseWrapper<ProjectTypeDTO>() 
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.BadRequestError)
                });
            }
            var response = await _projectTypeService.Update(entity);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProjectType([FromBody] ProjectTypeDTO entity)
        {
            if(entity == null)
            {
                return BadRequest(new ResponseWrapper<ProjectTypeDTO>() 
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.BadRequestError)
                });
            }
            var response = await _projectTypeService.Delete(entity);
            return Ok(response);
        }
    }
}
