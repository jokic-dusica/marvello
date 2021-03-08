using Marvello.Data.Entities;
using Marvello.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marvello.Repository.Repositories
{
    public class RefreshTokenRepository : Repository<RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(MarvelloDBContext dbContext) : base(dbContext)
        {

        }
    }
}
