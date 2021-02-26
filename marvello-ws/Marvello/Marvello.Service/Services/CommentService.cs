using Marvello.Data.Entities;
using Marvello.Repository.Interfaces;
using Marvello.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marvello.Service.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }


        public async Task<List<Comment>> GetAll()
        {
            return (List<Comment>)await _commentRepository.GetAll();
        }

        public async Task<Comment> GetOne(int id)
        {
            return await _commentRepository.GetOne(id);
        }

        public async Task<Comment> Save(Comment entity)
        {
            entity.CreatedOn = DateTime.UtcNow;
             await _commentRepository.Save(entity);
            return entity;
        }

        public async Task<Comment> Update(Comment entity)
        {
            entity.ModifiedOn = DateTime.UtcNow;
            await _commentRepository.Update(entity);
            return entity;

        }
        public async System.Threading.Tasks.Task Delete(Comment entity)
        {
            await _commentRepository.Delete(entity);
        }
    }
}
