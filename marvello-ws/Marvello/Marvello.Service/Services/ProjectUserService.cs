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
    public class ProjectUserService : IProjectUserService
    {
        private readonly IProjectUserRepository _projectUserRepository;
        private readonly IMapper _mapper;
        public ProjectUserService(IProjectUserRepository projectUserRepository, IMapper mapper)
        {
            _projectUserRepository = projectUserRepository;
            _mapper = mapper;
        }
    
        public async Task<List<ProjectUserDTO>> GetAll()
        {
            var listProjectUser = await _projectUserRepository.GetAll();
            var listDTOs = _mapper.Map<List<ProjectUserDTO>>(listProjectUser);
            return listDTOs;
        }

        public async Task<ProjectUserDTO> GetOne(int id)
        {
            var oneProjectUser = await _projectUserRepository.GetOne(id);
            var DTOs = _mapper.Map<ProjectUserDTO>(oneProjectUser);
            return DTOs;
        }

        public async Task<ProjectUserDTO> Save(ProjectUserDTO entity)
        {
            var projectUser = _mapper.Map<ProjectUser>(entity);
            projectUser.CreatedOn = DateTime.UtcNow;
            await _projectUserRepository.Save(projectUser);

            entity = _mapper.Map<ProjectUserDTO>(projectUser);
            return entity;
        }

        public async Task<ProjectUserDTO> Update(ProjectUserDTO entity)
        {
            var updateUser = _mapper.Map<ProjectUser>(entity);
            updateUser.ModifiedOn = DateTime.UtcNow;
            await _projectUserRepository.Update(updateUser);

            entity = _mapper.Map<ProjectUserDTO>(updateUser);
            return entity;
        }
        public async System.Threading.Tasks.Task Delete(ProjectUserDTO entity)
        {
            var deleteUser = _mapper.Map<ProjectUser>(entity);
            await _projectUserRepository.Delete(deleteUser);
        }
    }
}
