using Marvello.Data.Entities;
using Marvello.Service.DTOs;
using Marvello.Service.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marvello.Service.Interfaces
{
    public interface ICommentService
    {
        Task<ResponseWrapper<List<CommentDTO>>> GetAll();
        Task<ResponseWrapper<CommentDTO>> GetOne(int id);
        Task<ResponseWrapper<CommentDTO>> Save(CommentDTO entity);
        Task<ResponseWrapper<CommentDTO>> Update(CommentDTO entity);
        System.Threading.Tasks.Task<ResponseWrapper<CommentDTO>> Delete(CommentDTO entity);
    }
}
