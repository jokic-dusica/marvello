using Marvello.Data.Entities;
using Marvello.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marvello.Repository.Repositories
{
    public class ProjectUserRepository : Repository<ProjectUser>, IProjectUserRepository
    {
        public ProjectUserRepository(MarvelloDBContext dbContext) : base(dbContext)
        {

        }
    }
}
