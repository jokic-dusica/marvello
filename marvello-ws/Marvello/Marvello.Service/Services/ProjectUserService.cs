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
    public class ProjectUserService : IProjectUserService
    {
        private readonly IProjectUserRepository _projectUserRepository;
        private readonly IMapper _mapper;
        public ProjectUserService(IProjectUserRepository projectUserRepository, IMapper mapper)
        {
            _projectUserRepository = projectUserRepository;
            _mapper = mapper;
        }
    
        public async Task <ResponseWrapper<List<ProjectUserDTO>>> GetAll()
        {
            try
            {
                var listProjectUser = await _projectUserRepository.GetAll();
                var listDTOs = _mapper.Map<List<ProjectUserDTO>>(listProjectUser);
                var response = new ResponseWrapper<List<ProjectUserDTO>>()
                {
                    ResponseData = listDTOs,
                    IsSuccess = true
                };
                return response;
            }
            catch
            {
                var response = new ResponseWrapper<List<ProjectUserDTO>>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.ServerError),
                    IsSuccess = false
                };
                return response;
            }           
        }

        public async Task <ResponseWrapper<ProjectUserDTO>> GetOne(int id)
        {
            try
            {
                var oneProjectUser = await _projectUserRepository.GetOne(id);
                var DTOs = _mapper.Map<ProjectUserDTO>(oneProjectUser);
                var response = new ResponseWrapper<ProjectUserDTO>()
                {
                    ResponseData = DTOs,
                    IsSuccess = true
                };
                return response;
            }
            catch
            {
                var response = new ResponseWrapper<ProjectUserDTO>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.ServerError),
                    IsSuccess = false
                };
                return response;
            }           
        }

        public async Task <ResponseWrapper<ProjectUserDTO>> Save(ProjectUserDTO entity)
        {
            try
            {
                var projectUser = _mapper.Map<ProjectUser>(entity);
                projectUser.CreatedOn = DateTime.UtcNow;
                await _projectUserRepository.Save(projectUser);

                entity = _mapper.Map<ProjectUserDTO>(projectUser);
                var response = new ResponseWrapper<ProjectUserDTO>()
                {
                    ResponseData = entity,
                    IsSuccess = true
                };
                return response;
            }
            catch
            {
                var response = new ResponseWrapper<ProjectUserDTO>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.ServerError),
                    IsSuccess = false
                };
                return response;
            }
           
        }

        public async Task <ResponseWrapper<ProjectUserDTO>> Update(ProjectUserDTO entity)
        {
            try
            {
                var updateUser = _mapper.Map<ProjectUser>(entity);
                updateUser.ModifiedOn = DateTime.UtcNow;
                await _projectUserRepository.Update(updateUser);

                entity = _mapper.Map<ProjectUserDTO>(updateUser);
                var response = new ResponseWrapper<ProjectUserDTO>()
                {
                    ResponseData = entity,
                    IsSuccess = true
                };
                return response;
            }
            catch
            {
                var response = new ResponseWrapper<ProjectUserDTO>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.ServerError),
                    IsSuccess = false
                };
                return response;
            }
            
        }
        public async System.Threading.Tasks.Task <ResponseWrapper<ProjectUserDTO>> Delete(ProjectUserDTO entity)
        {
            try
            {
                var deleteUser = _mapper.Map<ProjectUser>(entity);
                await _projectUserRepository.Delete(deleteUser);
                var response = new ResponseWrapper<ProjectUserDTO>()
                {
                    ResponseData = _mapper.Map<ProjectUserDTO>(deleteUser),
                    IsSuccess = true
                };
                return response;
            }
            catch
            {
                var response = new ResponseWrapper<ProjectUserDTO>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.ServerError),
                    IsSuccess = false
                };
                return response;
            }
            
        }
    }
}
