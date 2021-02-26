using Marvello.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marvello.Service.Interfaces
{
    public interface ICommentService
    {
        Task<List<Comment>> GetAll();
        Task<Comment> GetOne(int id);
        Task<Comment> Save(Comment entity);
        Task<Comment> Update(Comment entity);
        System.Threading.Tasks.Task Delete(Comment entity);
    }
}
