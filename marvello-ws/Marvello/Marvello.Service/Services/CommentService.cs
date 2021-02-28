using AutoMapper;
using Marvello.Data.Entities;
using Marvello.Repository.Interfaces;
using Marvello.Service.DTOs;
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
        private readonly IMapper _mapper;
        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;

            _mapper = mapper;
        }


        public async Task<List<CommentDTO>> GetAll()
        {
            var commentList = await _commentRepository.GetAll();
            var commentListDTO = _mapper.Map<List<CommentDTO>>(commentList);
            return commentListDTO;
        }

        public async Task<CommentDTO> GetOne(int id)
        {
            var oneComment = await _commentRepository.GetOne(id);
            var oneCommentDTO = _mapper.Map<CommentDTO>(oneComment);
            return oneCommentDTO;
        }

        public async Task<CommentDTO> Save(CommentDTO entity)
        {
            var commentEntity = _mapper.Map<Comment>(entity);
            commentEntity.CreatedOn = DateTime.UtcNow;
            await _commentRepository.Save(commentEntity);
            entity = _mapper.Map<CommentDTO>(commentEntity);
            return entity;
        }

        public async Task<CommentDTO> Update(CommentDTO entity)
        {
            var updateCommentEntity = _mapper.Map<Comment>(entity);
            updateCommentEntity.ModifiedOn = DateTime.UtcNow;
            await _commentRepository.Update(updateCommentEntity);
            entity = _mapper.Map<CommentDTO>(updateCommentEntity);
            return entity;

        }
        public async System.Threading.Tasks.Task Delete(CommentDTO entity)
        {
            var deleteCommentEntity = _mapper.Map<Comment>(entity);
            await _commentRepository.Delete(deleteCommentEntity);
        }
    }
}
