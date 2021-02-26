using Marvello.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marvello.Service.Interfaces
{
    public interface IProjectTypeService
    {
        Task<List<ProjectType>> GetAll();
        Task<ProjectType> GetOne(int id);
        Task<ProjectType> Save(ProjectType entity);
        Task<ProjectType> Update(ProjectType entity);
        System.Threading.Tasks.Task Delete(ProjectType entity);
    }
}
