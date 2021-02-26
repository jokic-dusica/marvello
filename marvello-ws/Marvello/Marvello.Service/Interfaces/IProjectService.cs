using Marvello.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marvello.Service.Interfaces
{
    public interface IProjectService
    {
        Task<List<Project>> GetAll();
        Task<Project> GetOne(long id);
        Task<Project> Save(Project entity);
        Task<Project> Update(Project entity);
        System.Threading.Tasks.Task Delete(Project entity);
    }
}
