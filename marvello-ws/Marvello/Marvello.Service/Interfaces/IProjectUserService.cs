using Marvello.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marvello.Service.Interfaces
{
    public interface IProjectUserService
    {
        Task<List<ProjectUser>> GetAll();
        Task<ProjectUser> GetOne(int id);
        Task<ProjectUser> Save(ProjectUser entity);
        Task<ProjectUser> Update(ProjectUser entity);
        System.Threading.Tasks.Task Delete(ProjectUser entity);
    }
}
