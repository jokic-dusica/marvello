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
    [Route("api/projectUsers")]
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
            var response = await _projectUserService.GetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneProjectUser(int id)
        {
            var response = await _projectUserService.GetOne(id);
            if(response.ResponseData == null && string.IsNullOrEmpty(response.ErrorMessage))
            {
                return NotFound(new ResponseWrapper<ProjectUserDTO>() 
                { 
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.NotFoundError)
                });
            }
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> SaveProjectUser([FromBody] ProjectUserDTO entity)
        {
            if(entity == null)
            {
                return BadRequest(new ResponseWrapper<ProjectUserDTO>() 
                { 
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.BadRequestError)
                });
            }
            var response = await _projectUserService.Save(entity);
            return Created("localhost:8080/api/projectusers/" + response.ResponseData.Id, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProjectUser([FromBody] ProjectUserDTO entity, int id)
        {
            if(entity == null || id == 0)
            {
                return BadRequest(new ResponseWrapper<ProjectUserDTO>() 
                { 
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.BadRequestError)
                });
            }
            var response = await _projectUserService.Update(entity);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProjectUser([FromBody] ProjectUserDTO entity)
        {
            if(entity == null)
            {
                return BadRequest(new ResponseWrapper<ProjectUserDTO>() 
                { 
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.BadRequestError)
                });
            }
            var response = await _projectUserService.Delete(entity);
            return Ok(response);
        }
    }
}
