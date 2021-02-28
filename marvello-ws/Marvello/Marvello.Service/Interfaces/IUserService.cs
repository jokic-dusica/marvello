using Marvello.Data.Entities;
using Marvello.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marvello.Service.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAll();
        Task<UserDTO> GetOne(long id);
        Task<UserDTO> Save(UserDTO entity);
        Task<UserDTO> Update(UserDTO entity);
        System.Threading.Tasks.Task Delete(UserDTO entity);
    }
}
