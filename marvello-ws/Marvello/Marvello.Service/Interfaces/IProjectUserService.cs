using Marvello.Data.Entities;
using Marvello.Service.DTOs;
using Marvello.Service.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marvello.Service.Interfaces
{
    public interface IProjectUserService
    {
        Task <ResponseWrapper<List<ProjectUserDTO>>> GetAll();
        Task <ResponseWrapper<ProjectUserDTO>> GetOne(int id);
        Task <ResponseWrapper<ProjectUserDTO>> Save(ProjectUserDTO entity);
        Task <ResponseWrapper<ProjectUserDTO>> Update(ProjectUserDTO entity);
        System.Threading.Tasks.Task <ResponseWrapper<ProjectUserDTO>> Delete(ProjectUserDTO entity);
    }
}
