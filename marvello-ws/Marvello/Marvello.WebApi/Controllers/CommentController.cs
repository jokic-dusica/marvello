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
    [Route("api/comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService) 
        {
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _commentService.GetAll();
            return Ok(response);            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _commentService.GetOne(id);
            if(response.ResponseData == null && string.IsNullOrEmpty(response.ErrorMessage))
            {
                return NotFound(new ResponseWrapper<CommentDTO>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.NotFoundError)
                });
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CommentDTO entity)
        {
            if(entity == null)
            {
                return BadRequest(new ResponseWrapper<CommentDTO>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.BadRequestError)
                });
            }
            var response = await _commentService.Save(entity);
            return Created("localhost:8080/api/comments/" + response.ResponseData?.Id, response);
        }  

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment([FromBody] CommentDTO entity, int id)
        {
            if(entity == null || id == 0)
            {
                return BadRequest(new ResponseWrapper<CommentDTO>() 
                { 
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.BadRequestError)
                });
            }
            var response = await _commentService.Update(entity);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteComment([FromBody] CommentDTO entity)
        {
            if(entity == null)
            {
                return BadRequest(new ResponseWrapper<CommentDTO>() 
                { 
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.BadRequestError)
                });
            }
            var response = await _commentService.Delete(entity);
            return Ok(response);
        }
    }
}
