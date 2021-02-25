using Marvello.Data.Entities;
using Marvello.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marvello.Repository.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {

        public ProjectRepository(MarvelloDBContext dbContext) : base(dbContext)
        {

        }
    }
}
