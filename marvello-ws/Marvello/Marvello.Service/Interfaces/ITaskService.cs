using Marvello.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marvello.Service.Interfaces
{
    public interface ITaskService
    {
        Task<List<TaskDTO>> GetAll();
        Task<TaskDTO> GetOne(long id);
        Task<TaskDTO> Save(TaskDTO entity);
        Task<TaskDTO> Update(TaskDTO entity);
        System.Threading.Tasks.Task Delete(TaskDTO entity);
    }
}
