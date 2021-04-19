using Marvello.Service.DTOs;
using Marvello.Service.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marvello.Service.Interfaces
{
    public interface ITaskService
    {
        Task <ResponseWrapper<List<TaskDTO>>> GetAll();
        Task <ResponseWrapper<TaskDTO>> GetOne(long id);
        Task<ResponseWrapper<List<TaskDTO>>> GetTaskByProject(long id);
        Task <ResponseWrapper<TaskDTO>> Save(TaskDTO entity);
        Task <ResponseWrapper<TaskDTO>> Update(TaskDTO entity);
        System.Threading.Tasks.Task <ResponseWrapper<TaskDTO>> Delete(TaskDTO entity);
    }
}
