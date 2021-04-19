using AutoMapper;
using Marvello.Repository.Interfaces;
using Marvello.Service.DTOs;
using Marvello.Service.Enums;
using Marvello.Service.Interfaces;
using Marvello.Service.Utils;
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

        public async Task <ResponseWrapper<List<TaskDTO>>> GetAll()
        {
            try
            {
                var listTask = await _taskRepository.GetAll();
                var taskDTOs = _mapper.Map<List<TaskDTO>>(listTask);
                var response = new ResponseWrapper<List<TaskDTO>>()
                {
                    ResponseData = taskDTOs,
                    IsSuccess = true
                };
                return response;
            }
            catch
            {
                var response = new ResponseWrapper<List<TaskDTO>>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.ServerError),
                    IsSuccess = false
                };
                return response;
            }
        }

        public async Task <ResponseWrapper<TaskDTO>> GetOne(long id)
        {
            try
            {
                var oneTask = await _taskRepository.GetOne(id);
                var oneTaskDTOs = _mapper.Map<TaskDTO>(oneTask);
                var response = new ResponseWrapper<TaskDTO>()
                {
                    ResponseData = oneTaskDTOs,
                    IsSuccess = true
                };
                return response;
            }
            catch
            {
                var response = new ResponseWrapper<TaskDTO>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.ServerError),
                    IsSuccess = false
                };
                return response;
            }
            
        }

        public async Task<ResponseWrapper<List<TaskDTO>>> GetTaskByProject(long id)
        {
            try
            {
                var taskByProject = await _taskRepository.GetTaskByProject(id);
                var taskByProjectDTO = _mapper.Map<List<TaskDTO>>(taskByProject);
                var response = new ResponseWrapper<List<TaskDTO>>()
                {
                    ResponseData = taskByProjectDTO,
                    IsSuccess = true
                };
                return response;

            }
            catch
            {
                var response = new ResponseWrapper<List<TaskDTO>>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.ServerError),
                    IsSuccess = false
                };
                return response;
            }
        }

        public async Task <ResponseWrapper<TaskDTO>> Save(TaskDTO entity)
        {
            try
            {
                var saveTask = _mapper.Map<Marvello.Data.Entities.Task>(entity);
                saveTask.CreatedOn = DateTime.UtcNow;
                await _taskRepository.Save(saveTask);

                entity = _mapper.Map<TaskDTO>(saveTask);
                var response = new ResponseWrapper<TaskDTO>()
                {
                    ResponseData = entity,
                    IsSuccess = true
                };
                return response;
            }
            catch
            {
                var response = new ResponseWrapper<TaskDTO>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.ServerError),
                    IsSuccess = false
                };
                return response;
            }
            
        }

        public async Task <ResponseWrapper<TaskDTO>> Update(TaskDTO entity)
        {
            try
            {
                var updateTask = _mapper.Map<Marvello.Data.Entities.Task>(entity);
                updateTask.ModifiedOn = DateTime.UtcNow;
                await _taskRepository.Update(updateTask);

                entity = _mapper.Map<TaskDTO>(updateTask);
                var response = new ResponseWrapper<TaskDTO>()
                {
                    ResponseData = entity,
                    IsSuccess = true
                };
                return response;
            }
            catch
            {
                var response = new ResponseWrapper<TaskDTO>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.ServerError),
                    IsSuccess = false
                };
                return response;
            }
            
        }
        public async System.Threading.Tasks.Task <ResponseWrapper<TaskDTO>> Delete(TaskDTO entity)
        {
            try
            {
                var deleteTask = _mapper.Map<Marvello.Data.Entities.Task>(entity);
                await _taskRepository.Delete(deleteTask);
                var response = new ResponseWrapper<TaskDTO>()
                {
                    ResponseData = _mapper.Map<TaskDTO>(deleteTask),
                    IsSuccess = true
                };
                return response;
            }
            catch
            {
                var response = new ResponseWrapper<TaskDTO>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.ServerError),
                    IsSuccess = false
                };
                return response;
            }
        
        }

    }
}
