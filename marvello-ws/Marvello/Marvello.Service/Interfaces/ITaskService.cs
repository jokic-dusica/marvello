using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marvello.Service.Interfaces
{
    public interface ITaskService
    {
        Task<List<Marvello.Data.Entities.Task>> GetAll();
        Task<Marvello.Data.Entities.Task> GetOne(long id);
        Task<Marvello.Data.Entities.Task> Save(Marvello.Data.Entities.Task entity);
        Task<Marvello.Data.Entities.Task> Update(Marvello.Data.Entities.Task entity);
        System.Threading.Tasks.Task Delete(Marvello.Data.Entities.Task entity);
    }
}
