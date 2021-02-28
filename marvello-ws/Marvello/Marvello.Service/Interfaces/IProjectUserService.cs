using Marvello.Data.Entities;
using Marvello.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marvello.Service.Interfaces
{
    public interface IProjectUserService
    {
        Task<List<ProjectUserDTO>> GetAll();
        Task<ProjectUserDTO> GetOne(int id);
        Task<ProjectUserDTO> Save(ProjectUserDTO entity);
        Task<ProjectUserDTO> Update(ProjectUserDTO entity);
        System.Threading.Tasks.Task Delete(ProjectUserDTO entity);
    }
}
