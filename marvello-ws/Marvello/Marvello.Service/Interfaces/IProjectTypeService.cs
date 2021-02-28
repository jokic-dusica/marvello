using Marvello.Data.Entities;
using Marvello.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marvello.Service.Interfaces
{
    public interface IProjectTypeService
    {
        Task<List<ProjectTypeDTO>> GetAll();
        Task<ProjectTypeDTO> GetOne(int id);
        Task<ProjectTypeDTO> Save(ProjectTypeDTO entity);
        Task<ProjectTypeDTO> Update(ProjectTypeDTO entity);
        System.Threading.Tasks.Task Delete(ProjectTypeDTO entity);
    }
}
