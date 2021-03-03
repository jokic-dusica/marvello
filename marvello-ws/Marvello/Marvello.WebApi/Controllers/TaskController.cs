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
            var listTasks = await _taskService.GetAll();
            return Ok(listTasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(long id)
        {
            var oneTask = await _taskService.GetOne(id);
            if(oneTask == null)
            {
                return NotFound();
            }
            return Ok(oneTask);
        }

        [HttpPost]
        public async Task<IActionResult> SaveTask([FromBody] TaskDTO entity)
        {
            if(entity == null)
            {
                return BadRequest();
            }
            var saveTask = await _taskService.Save(entity);
            return Created("localhost:8080/api/tasks/" + saveTask.Id, saveTask);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask([FromBody] TaskDTO entity, long id)
        {
            if(entity == null  || id == 0)
            {
                return BadRequest();
            }
            var updateTask = await _taskService.Update(entity);
            return Ok(updateTask);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTask([FromBody] TaskDTO entity)
        {
            if(entity == null)
            {
                return BadRequest();
            }
            await _taskService.Delete(entity);
            return Ok();
        }
    }
}
