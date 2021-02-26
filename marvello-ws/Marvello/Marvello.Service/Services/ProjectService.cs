using Marvello.Data.Entities;
using Marvello.Repository.Interfaces;
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

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<List<Project>> GetAll()
        {
            return (List<Project>)await _projectRepository.GetAll();
        }

        public async Task<Project> GetOne(long id)
        {
            return await _projectRepository.GetOne(id);
        }

        public async Task<Project> Save(Project entity)
        {
            entity.CreatedOn = DateTime.UtcNow;
            await _projectRepository.Save(entity);
            return entity;
        }

        public async Task<Project> Update(Project entity)
        {
            entity.ModifiedOn = DateTime.UtcNow;
            await _projectRepository.Update(entity);
            return entity;
        }
        public async System.Threading.Tasks.Task Delete(Project entity)
        {
            await _projectRepository.Delete(entity);
        }

    }
}
