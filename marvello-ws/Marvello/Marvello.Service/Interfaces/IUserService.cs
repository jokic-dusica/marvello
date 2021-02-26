using Marvello.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marvello.Service.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
        Task<User> GetOne(long id);
        Task<User> Save(User entity);
        Task<User> Update(User entity);
        System.Threading.Tasks.Task Delete(User entity);
    }
}
