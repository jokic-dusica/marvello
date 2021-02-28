using AutoMapper;
using Marvello.Repository.Interfaces;
using Marvello.Service.DTOs;
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
        private readonly IMapper _mapper;
        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<List<TaskDTO>> GetAll()
        {
            var listTask = await _taskRepository.GetAll();
            var taskDTOs = _mapper.Map<List<TaskDTO>>(listTask);
            return taskDTOs;

        }

        public async Task<TaskDTO> GetOne(long id)
        {
            var oneTask = await _taskRepository.GetOne(id);
            var oneTaskDTOs = _mapper.Map<TaskDTO>(oneTask);
            return oneTaskDTOs;
        }

        public async Task<TaskDTO> Save(TaskDTO entity)
        {
            var saveTask = _mapper.Map<Marvello.Data.Entities.Task>(entity);
            saveTask.CreatedOn = DateTime.UtcNow;
            await _taskRepository.Save(saveTask);

            entity = _mapper.Map<TaskDTO>(saveTask);
            return entity;
        }

        public async Task<TaskDTO> Update(TaskDTO entity)
        {
            var updateTask = _mapper.Map<Marvello.Data.Entities.Task>(entity);
            updateTask.ModifiedOn = DateTime.UtcNow;
            await _taskRepository.Update(updateTask);

            entity = _mapper.Map<TaskDTO>(updateTask);
            return entity;
        }
        public async System.Threading.Tasks.Task Delete(TaskDTO entity)
        {
            var deleteTask = _mapper.Map<Marvello.Data.Entities.Task>(entity);
            await _taskRepository.Delete(deleteTask);
        }

    }
}
