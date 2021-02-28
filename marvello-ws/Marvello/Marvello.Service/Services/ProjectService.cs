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
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }
        public async Task<List<ProjectDTO>> GetAll()
        {
            var listProject = await _projectRepository.GetAll();
            var listProjectDTO = _mapper.Map<List<ProjectDTO>>(listProject);
            return listProjectDTO;
        }

        public async Task<ProjectDTO> GetOne(long id)
        {
            var oneProject = await _projectRepository.GetOne(id);
            var oneProjectDTO = _mapper.Map<ProjectDTO>(oneProject);
            return oneProjectDTO;
        }

        public async Task<ProjectDTO> Save(ProjectDTO entity)
        {
            var projectEntity = _mapper.Map<Project>(entity);
            projectEntity.CreatedOn = DateTime.UtcNow;
            await _projectRepository.Save(projectEntity);
            entity = _mapper.Map<ProjectDTO>(projectEntity);
            return entity;
        }

        public async Task<ProjectDTO> Update(ProjectDTO entity)
        {
            var updateProject = _mapper.Map<Project>(entity);
            updateProject.ModifiedOn = DateTime.UtcNow;
            await _projectRepository.Update(updateProject);
            entity = _mapper.Map<ProjectDTO>(updateProject);
            return entity;
        }
        public async System.Threading.Tasks.Task Delete(ProjectDTO entity)
        {
            var deleteProject = _mapper.Map<Project>(entity);
            await _projectRepository.Delete(deleteProject);
        }

    }
}
