using Marvello.Data.Entities;
using Marvello.Repository.Interfaces;
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
        public ProjectTypeService(IProjectTypeRepository projectTypeRepository)
        {
            _projectTypeRepository = projectTypeRepository;

        }
    
        public async Task<List<ProjectType>> GetAll()
        {
            return (List<ProjectType>)await _projectTypeRepository.GetAll();
        }

        public async Task<ProjectType> GetOne(int id)
        {
            return await _projectTypeRepository.GetOne(id);
        }

        public async Task<ProjectType> Save(ProjectType entity)
        {
            entity.CreatedOn = DateTime.UtcNow;
            await _projectTypeRepository.Save(entity);
            return entity;
               
        }

        public async Task<ProjectType> Update(ProjectType entity)
        {
            entity.ModifiedOn = DateTime.UtcNow;
            await _projectTypeRepository.Update(entity);
            return entity;

        }
        public async System.Threading.Tasks.Task Delete(ProjectType entity)
        {
            await _projectTypeRepository.Delete(entity);
        }

    }
}
