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
            var listComment = await _commentService.GetAll();
            return Ok(listComment);            
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var oneComment = await _commentService.GetOne(id);
            if(oneComment == null)
            {
                return NotFound();
            }
            return Ok(oneComment);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CommentDTO entity)
        {
            if(entity == null)
            {
                return BadRequest();
            }
            var saveComment = await _commentService.Save(entity);
            return Created("localhost:8080/api/comments/" + saveComment.Id, saveComment);
        }  

        [HttpPut("id")]
        public async Task<IActionResult> UpdateComment([FromBody] CommentDTO entity, int id)
        {
            if(entity == null || id == 0)
            {
                return BadRequest();
            }
            var updateComment = await _commentService.Update(entity);
            return Ok(updateComment);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteComment([FromBody] CommentDTO entity)
        {
            if(entity == null)
            {
                return BadRequest();
            }
            await _commentService.Delete(entity);
            return Ok();
        }
    }
}
