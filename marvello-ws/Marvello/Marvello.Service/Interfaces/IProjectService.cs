using Marvello.Data.Entities;
using Marvello.Service.DTOs;
using Marvello.Service.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marvello.Service.Interfaces
{
    public interface IProjectService
    {
        Task <ResponseWrapper<List<ProjectDTO>>> GetAll();
        Task <ResponseWrapper<ProjectDTO>> GetOne(long id);
        Task<ResponseWrapper<ProjectDTO>> Save(ProjectDTO entity);
        Task <ResponseWrapper<ProjectDTO>> Update(ProjectDTO entity);
        System.Threading.Tasks.Task <ResponseWrapper<ProjectDTO>>Delete(ProjectDTO entity);
    }
}
