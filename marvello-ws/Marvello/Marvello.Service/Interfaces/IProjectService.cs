using Marvello.Data.Entities;
using Marvello.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marvello.Service.Interfaces
{
    public interface IProjectService
    {
        Task<List<ProjectDTO>> GetAll();
        Task<ProjectDTO> GetOne(long id);
        Task<ProjectDTO> Save(ProjectDTO entity);
        Task<ProjectDTO> Update(ProjectDTO entity);
        System.Threading.Tasks.Task Delete(ProjectDTO entity);
    }
}
