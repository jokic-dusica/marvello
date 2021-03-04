using Marvello.Data.Entities;
using Marvello.Service.DTOs;
using Marvello.Service.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marvello.Service.Interfaces
{
    public interface IProjectTypeService
    {
        Task <ResponseWrapper<List<ProjectTypeDTO>>> GetAll();
        Task <ResponseWrapper<ProjectTypeDTO>> GetOne(int id);
        Task <ResponseWrapper<ProjectTypeDTO>> Save(ProjectTypeDTO entity);
        Task <ResponseWrapper<ProjectTypeDTO>> Update(ProjectTypeDTO entity);
        System.Threading.Tasks.Task <ResponseWrapper<ProjectTypeDTO>> Delete(ProjectTypeDTO entity);
    }
}
