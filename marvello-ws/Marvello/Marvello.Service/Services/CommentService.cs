using AutoMapper;
using Marvello.Data.Entities;
using Marvello.Repository.Interfaces;
using Marvello.Service.DTOs;
using Marvello.Service.Enums;
using Marvello.Service.Interfaces;
using Marvello.Service.Utils;
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


        public async Task<ResponseWrapper<List<CommentDTO>>> GetAll()
        {
         try
            {
                var commentList = await _commentRepository.GetAll();
                var commentListDTO = _mapper.Map<List<CommentDTO>>(commentList);
                var response = new ResponseWrapper<List<CommentDTO>>()
                {
                    ResponseData = commentListDTO,
                    IsSuccess = true

                };
                return response;
            }
            catch
            {
                var response = new ResponseWrapper<List<CommentDTO>>() {

                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.ServerError),
                    IsSuccess = false
                };
                return response;
            }
        }

        public async Task<ResponseWrapper<CommentDTO>> GetOne(int id)
        {
            try
            {
                var oneComment = await _commentRepository.GetOne(id);
                var oneCommentDTO = _mapper.Map<CommentDTO>(oneComment);
                var response = new ResponseWrapper<CommentDTO>()
                {
                    ResponseData = oneCommentDTO,
                    IsSuccess = true
                };
                return response;
            }
           
            catch
            {
                var response = new ResponseWrapper<CommentDTO>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.ServerError),
                    IsSuccess = false
                };
                return response;
            }           
        }

        public async Task<ResponseWrapper<CommentDTO>> Save(CommentDTO entity)
        {
            try
            {
                var commentEntity = _mapper.Map<Comment>(entity);
                commentEntity.CreatedOn = DateTime.UtcNow;
                await _commentRepository.Save(commentEntity);
                entity = _mapper.Map<CommentDTO>(commentEntity);
                var response = new ResponseWrapper<CommentDTO>()
                {
                    ResponseData = entity,
                    IsSuccess = true
                };
                return response;
            }
            catch
            {
                var response = new ResponseWrapper<CommentDTO>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.ServerError),
                    IsSuccess = false
                };
                return response;
            }         
        }

        public async Task<ResponseWrapper<CommentDTO>> Update(CommentDTO entity)
        {
            try
            {
                var updateCommentEntity = _mapper.Map<Comment>(entity);
                updateCommentEntity.ModifiedOn = DateTime.UtcNow;
                await _commentRepository.Update(updateCommentEntity);
                entity = _mapper.Map<CommentDTO>(updateCommentEntity);
                var response = new ResponseWrapper<CommentDTO>()
                {
                    ResponseData = entity,
                    IsSuccess = true
                };
                return response;
            }
            catch
            {
                var response = new ResponseWrapper<CommentDTO>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.ServerError),
                    IsSuccess = false
                };
                return response;
            }
        }
        public async System.Threading.Tasks.Task<ResponseWrapper<CommentDTO>> Delete(CommentDTO entity)
        {
            try
            {
                var deleteCommentEntity = _mapper.Map<Comment>(entity);
                await _commentRepository.Delete(deleteCommentEntity);
                var response = new ResponseWrapper<CommentDTO>()
                {
                    ResponseData = _mapper.Map<CommentDTO>(deleteCommentEntity),
                    IsSuccess = true
                };
                return response;
            }
            catch
            {
                var response = new ResponseWrapper<CommentDTO>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.ServerError),
                    IsSuccess = false
                };
                return response;
            }

        }
    }
}
