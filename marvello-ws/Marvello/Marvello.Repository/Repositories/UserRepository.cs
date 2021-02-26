using Marvello.Data.Entities;
using Marvello.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvello.Repository.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MarvelloDBContext dbContext) : base(dbContext)
        {

        }

        public async Task<User> GetByUsername(string username)
        {
            return await FirstOrDefault(user => user.Username == username);
        }

    }
}
