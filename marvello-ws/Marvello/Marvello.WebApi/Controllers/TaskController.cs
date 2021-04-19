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
    [Route("api/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTask()
        {
            var response = await _taskService.GetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(long id)
        {
            var response = await _taskService.GetOne(id);
            if(response.ResponseData == null && string.IsNullOrEmpty(response.ErrorMessage))
            {
                return NotFound(new ResponseWrapper<TaskDTO>() 
                { 
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.NotFoundError)
                });
            }
            return Ok(response);
        }

        [HttpGet("/project/{id}")]
        public async Task<IActionResult> GetTaskByProject(long id)
        {
            var response = await _taskService.GetTaskByProject(id);
            if (response.ResponseData == null && string.IsNullOrEmpty(response.ErrorMessage))
            {
                return NotFound(new ResponseWrapper<TaskDTO>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.NotFoundError)
                });
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveTask([FromBody] TaskDTO entity)
        {
            if(entity == null)
            {
                return BadRequest(new ResponseWrapper<TaskDTO>() 
                { 
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.BadRequestError)
                });
            }
            var response = await _taskService.Save(entity);
            return Created("localhost:8080/api/tasks/" + response.ResponseData.Id, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask([FromBody] TaskDTO entity, long id)
        {
            if(entity == null  || id == 0)
            {
                return BadRequest(new ResponseWrapper<TaskDTO>() 
                { 
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.BadRequestError)
                });
            }
            var response = await _taskService.Update(entity);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTask([FromBody] TaskDTO entity)
        {
            if(entity == null)
            {
                return BadRequest(new ResponseWrapper<TaskDTO>() 
                { 
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.BadRequestError)
                });
            }
            var response = await _taskService.Delete(entity);
            return Ok(response);
        }
    }
}
