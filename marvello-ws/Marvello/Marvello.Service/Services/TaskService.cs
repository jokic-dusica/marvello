using Marvello.Repository.Interfaces;
using Marvello.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marvello.Service.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<Data.Entities.Task>> GetAll()
        {
            return (List<Data.Entities.Task>)await _taskRepository.GetAll();
        }

        public async Task<Data.Entities.Task> GetOne(long id)
        {
            return await _taskRepository.GetOne(id);
        }

        public async Task<Data.Entities.Task> Save(Data.Entities.Task entity)
        {
            entity.CreatedOn = DateTime.UtcNow;
            await _taskRepository.Save(entity);
            return entity;
        }

        public async Task<Data.Entities.Task> Update(Data.Entities.Task entity)
        {
            entity.ModifiedOn = DateTime.UtcNow;
            await _taskRepository.Update(entity);
            return entity;
        }
        public async System.Threading.Tasks.Task Delete(Data.Entities.Task entity)
        {
            await _taskRepository.Delete(entity);
        }

    }
}
