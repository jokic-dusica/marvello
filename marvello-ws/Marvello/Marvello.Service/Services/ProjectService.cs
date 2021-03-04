using AutoMapper;
using Marvello.Data.Entities;
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
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }
        public async Task<ResponseWrapper<List<ProjectDTO>>> GetAll()
        {
            try
            {
                var listProject = await _projectRepository.GetAll();
                var listProjectDTO = _mapper.Map<List<ProjectDTO>>(listProject);
                var response = new ResponseWrapper<List<ProjectDTO>>()
                {
                    ResponseData = listProjectDTO,
                    IsSuccess = true
                };
                return response;
            }
            catch {
                var response = new ResponseWrapper<List<ProjectDTO>>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.ServerError),
                    IsSuccess = false
                };
                return response;
            }
        }

        public async Task <ResponseWrapper<ProjectDTO>> GetOne(long id)
        {
            try
            {
                var oneProject = await _projectRepository.GetOne(id);
                var oneProjectDTO = _mapper.Map<ProjectDTO>(oneProject);
                var response = new ResponseWrapper<ProjectDTO>()
                {
                    ResponseData = oneProjectDTO,
                    IsSuccess = true
                };
                return response;
            }
            catch
            {
                var response = new ResponseWrapper<ProjectDTO>()
                {

                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.ServerError),
                    IsSuccess = false
                };
                return response;             
            }
        }

        public async Task<ResponseWrapper<ProjectDTO>> Save(ProjectDTO entity)
        {
            try
            {
                var projectEntity = _mapper.Map<Project>(entity);
                projectEntity.CreatedOn = DateTime.UtcNow;
                await _projectRepository.Save(projectEntity);
                entity = _mapper.Map<ProjectDTO>(projectEntity);
                var response = new ResponseWrapper<ProjectDTO>()
                {
                    ResponseData = entity,
                    IsSuccess = true
                };
                return response;
            }
            catch
            {
                var response = new ResponseWrapper<ProjectDTO>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.ServerError),
                    IsSuccess = false
                };
                return response;
            }                      
        }

        public async Task<ResponseWrapper<ProjectDTO>> Update(ProjectDTO entity)
        {
            try
            {
                var updateProject = _mapper.Map<Project>(entity);
                updateProject.ModifiedOn = DateTime.UtcNow;
                await _projectRepository.Update(updateProject);
                entity = _mapper.Map<ProjectDTO>(updateProject);
                var response = new ResponseWrapper<ProjectDTO>()
                {
                    ResponseData = entity,
                    IsSuccess = true
                };
                return response;
            }
            catch
            {
                var response = new ResponseWrapper<ProjectDTO>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.ServerError),
                    IsSuccess = false
                };
                return response;
            }           
        }
        public async System.Threading.Tasks.Task <ResponseWrapper<ProjectDTO>> Delete(ProjectDTO entity)
        {
            try
            {
                var deleteProject = _mapper.Map<Project>(entity);
                await _projectRepository.Delete(deleteProject);
                var response = new ResponseWrapper<ProjectDTO>()
                {
                    ResponseData = _mapper.Map<ProjectDTO>(deleteProject),
                    IsSuccess = true
                };
                return response;
            }
            catch
            {
                var response = new ResponseWrapper<ProjectDTO>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.ServerError),
                    IsSuccess = false
                };
                return response;
            }           
        }
    }
}
