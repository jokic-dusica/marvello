using Marvello.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marvello.Repository.Interfaces
{
    public interface ITaskRepository : IRepository<Task>
    {
        public System.Threading.Tasks.Task<List<Task>> GetTaskByProject(long id);
    }
}
