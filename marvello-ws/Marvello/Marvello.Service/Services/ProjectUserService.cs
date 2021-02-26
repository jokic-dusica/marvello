using Marvello.Data.Entities;
using Marvello.Repository.Interfaces;
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
        public ProjectUserService(IProjectUserRepository projectUserRepository)
        {
            _projectUserRepository = projectUserRepository;
        }
    
        public async Task<List<ProjectUser>> GetAll()
        {
            return (List<ProjectUser>)await _projectUserRepository.GetAll();
        }

        public async Task<ProjectUser> GetOne(int id)
        {
            return await _projectUserRepository.GetOne(id);
        }

        public async Task<ProjectUser> Save(ProjectUser entity)
        {
            entity.CreatedOn = DateTime.UtcNow;
            await _projectUserRepository.Save(entity);
            return entity;
        }

        public async Task<ProjectUser> Update(ProjectUser entity)
        {
            entity.ModifiedOn = DateTime.UtcNow;
            await _projectUserRepository.Update(entity);
            return entity;
        }
        public async System.Threading.Tasks.Task Delete(ProjectUser entity)
        {
            await _projectUserRepository.Delete(entity);
        }
    }
}
