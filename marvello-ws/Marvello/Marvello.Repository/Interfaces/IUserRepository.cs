using Marvello.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marvello.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        System.Threading.Tasks.Task<User> GetByUsername(string username);
    }
}
