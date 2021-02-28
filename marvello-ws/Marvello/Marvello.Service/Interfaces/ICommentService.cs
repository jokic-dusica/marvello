using Marvello.Data.Entities;
using Marvello.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marvello.Service.Interfaces
{
    public interface ICommentService
    {
        Task<List<CommentDTO>> GetAll();
        Task<CommentDTO> GetOne(int id);
        Task<CommentDTO> Save(CommentDTO entity);
        Task<CommentDTO> Update(CommentDTO entity);
        System.Threading.Tasks.Task Delete(CommentDTO entity);
    }
}
