using Marvello.Data.Entities;
using Marvello.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marvello.Repository.Repositories
{
    public class ProjectTypeRepository : Repository<ProjectType>, IProjectTypeRepository
    {
        public ProjectTypeRepository(MarvelloDBContext dbContext) : base(dbContext)
        {

        }
    }
}
