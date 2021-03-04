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
    public class ProjectTypeService : IProjectTypeService 
    {
        private readonly IProjectTypeRepository _projectTypeRepository;
        private readonly IMapper _mapper;


        public ProjectTypeService(IProjectTypeRepository projectTypeRepository, IMapper mapper)
        {
            _mapper = mapper;
            _projectTypeRepository = projectTypeRepository;
        }

        public async Task <ResponseWrapper<List<ProjectTypeDTO>>> GetAll()
        {
            try
            {
                var listProjectType = await _projectTypeRepository.GetAll();
                var listDTOs = _mapper.Map<List<ProjectTypeDTO>>(listProjectType);
                var response = new ResponseWrapper<List<ProjectTypeDTO>>()
                {
                    ResponseData = listDTOs,
                    IsSuccess = true
                };
                return response;
            }
            catch
            {
                var response = new ResponseWrapper<List<ProjectTypeDTO>>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.ServerError),
                    IsSuccess = false
                };
                return response;
            }
            
        }

        public async Task <ResponseWrapper<ProjectTypeDTO>> GetOne(int id)
        {
            try
            {
                var oneProjectType = await _projectTypeRepository.GetOne(id);
                var oneProjectTypeDTO = _mapper.Map<ProjectTypeDTO>(oneProjectType);
                var response = new ResponseWrapper<ProjectTypeDTO>()
                {
                    ResponseData = oneProjectTypeDTO,
                    IsSuccess = true
                };
                return response;
            }
            catch
            {
                var response = new ResponseWrapper<ProjectTypeDTO>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.ServerError),
                    IsSuccess = false
                };
                return response;
            }
            
        }

        public async Task <ResponseWrapper<ProjectTypeDTO>> Save(ProjectTypeDTO entity)
        {
            try
            {
                var saveProjectType = _mapper.Map<ProjectType>(entity);
                saveProjectType.CreatedOn = DateTime.UtcNow;
                await _projectTypeRepository.Save(saveProjectType);

                entity = _mapper.Map<ProjectTypeDTO>(saveProjectType);
                var response = new ResponseWrapper<ProjectTypeDTO>()
                {
                    ResponseData = entity,
                    IsSuccess = true
                };
                return response;
            }
            catch
            {
                var response = new ResponseWrapper<ProjectTypeDTO>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.ServerError),
                    IsSuccess = false
                };
                return response;
            }
                        
        }

        public async Task <ResponseWrapper<ProjectTypeDTO>> Update(ProjectTypeDTO entity)
        {
            try
            {
                var updateProjectType = _mapper.Map<ProjectType>(entity);
                updateProjectType.ModifiedOn = DateTime.UtcNow;
                await _projectTypeRepository.Update(updateProjectType);

                entity = _mapper.Map<ProjectTypeDTO>(updateProjectType);
                var response = new ResponseWrapper<ProjectTypeDTO>()
                {
                    ResponseData = entity,
                    IsSuccess = true
                };
                return response;
            }
            catch
            {
                var response = new ResponseWrapper<ProjectTypeDTO>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.ServerError),
                    IsSuccess = false
                };
                return response;
            }
            
        }

        public async System.Threading.Tasks.Task <ResponseWrapper<ProjectTypeDTO>> Delete(ProjectTypeDTO entity)
        {
            try
            {
                var deleteProjectType = _mapper.Map<ProjectType>(entity);
                await _projectTypeRepository.Delete(deleteProjectType);
                var response = new ResponseWrapper<ProjectTypeDTO>()
                {
                    ResponseData = _mapper.Map<ProjectTypeDTO>(deleteProjectType),
                    IsSuccess = true
                };
                return response;
            }
            catch
            {
                var response = new ResponseWrapper<ProjectTypeDTO>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.ServerError),
                    IsSuccess = false
                };
                return response;
            }
        }
    }
}
