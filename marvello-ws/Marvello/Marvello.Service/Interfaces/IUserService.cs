using Marvello.Data.Entities;
using Marvello.Service.DTOs;
using Marvello.Service.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marvello.Service.Interfaces
{
    public interface IUserService
    {
        Task <ResponseWrapper<List<UserDTO>>> GetAll();
        Task<ResponseWrapper<UserDTO>> GetOne(long id);
        Task<ResponseWrapper<UserDTO>> Save(UserDTO entity);
        Task<ResponseWrapper<UserDTO>> Update(UserDTO entity);
        System.Threading.Tasks.Task<ResponseWrapper<UserDTO>> Delete(UserDTO entity);
    }
}
