using AutoMapper;
using Marvello.Data.Entities;
using Marvello.Repository.Interfaces;
using Marvello.Service.DTOs;
using Marvello.Service.Interfaces;
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

        public async Task<List<ProjectTypeDTO>> GetAll()
        {
            var listProjectType = await _projectTypeRepository.GetAll();
            var listDTOs = _mapper.Map<List<ProjectTypeDTO>>(listProjectType);
            return listDTOs;
        }

        public async Task<ProjectTypeDTO> GetOne(int id)
        {
            var oneProjectType = await _projectTypeRepository.GetOne(id);
            var oneProjectTypeDTO = _mapper.Map<ProjectTypeDTO>(oneProjectType);
            return oneProjectTypeDTO;
        }

        public async Task<ProjectTypeDTO> Save(ProjectTypeDTO entity)
        {

            var saveProjectType = _mapper.Map<ProjectType>(entity);
            saveProjectType.CreatedOn = DateTime.UtcNow;
            await _projectTypeRepository.Save(saveProjectType);

            entity = _mapper.Map<ProjectTypeDTO>(saveProjectType);
            return entity;               
        }

        public async Task<ProjectTypeDTO> Update(ProjectTypeDTO entity)
        {
            var updateProjectType = _mapper.Map<ProjectType>(entity);
            updateProjectType.ModifiedOn = DateTime.UtcNow;
            await _projectTypeRepository.Update(updateProjectType);

            entity = _mapper.Map<ProjectTypeDTO>(updateProjectType);
            return entity;
        }

        public async System.Threading.Tasks.Task Delete(ProjectTypeDTO entity)
        {
            var deleteProjectType = _mapper.Map<ProjectType>(entity);
            await _projectTypeRepository.Delete(deleteProjectType);
        }
    }
}
